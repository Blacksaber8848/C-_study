using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module42.PubEvent;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Module42.ViewModels
{
    public class ViewBViewModel:BindableBase
    {
        private string _message = "Prism Unity Application";
        public string Messageb
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private readonly IEventAggregator _eventAggregator;

        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<clickevent>().Subscribe(OnMyEventOccurred);
        }

       

        private void OnMyEventOccurred(string eventData)
        {
           Messageb= eventData;
        }



    }
}
