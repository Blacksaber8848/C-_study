using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task37.ViewModels
{
    public class homeViewModels : BindableBase
    {
        private string _title = "Prism home";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public homeViewModels()
        {

        }
    }
}
