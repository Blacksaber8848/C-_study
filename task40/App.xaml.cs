using Module40;
using Module39;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using task40.Views;


namespace task40
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Module40Module>();
            moduleCatalog.AddModule<Module39Module>();
        }
    }
}
