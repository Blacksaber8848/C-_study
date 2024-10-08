using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // 启动服务端
        Task serverTask = Task.Run(() => StartServer());

        // 启动客户端
        Task clientTask = Task.Run(() => StartClient());

        // 等待任务完成
        await Task.WhenAll(serverTask, clientTask);
    }

    static void StartServer()
    {
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress ipAddress = IPAddress.Any;
        listener.Bind(new IPEndPoint(ipAddress, 11000));
        listener.Listen(100);
        Console.WriteLine("Server listening...");

        using (Socket handler = listener.Accept())
        {
            using (FileStream fileStream = new FileStream("receivedFile.txt", FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = handler.Receive(buffer, 0, buffer.Length, 0)) != 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }
        listener.Close();
        Console.WriteLine("File received and saved.");
    }

    static void StartClient()
    {
        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sender.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
        Console.WriteLine("Connected to server.");

        using (FileStream fileStream = new FileStream("sendFile.txt", FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                sender.Send(buffer, 0, bytesRead, 0);
            }
        }

        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
        Console.WriteLine("File sent.");
    }
}