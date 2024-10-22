using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module42.PubEvent;

namespace Module42.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public DelegateCommand Click { get; private set; }
        private readonly IEventAggregator _eventAggregator;

        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            Click =new DelegateCommand(buttonclicked);
        }
        public void buttonclicked()
        {
          
            _eventAggregator.GetEvent<clickevent>().Publish(Message);
        }

      
    }
}
