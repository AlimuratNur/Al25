using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al25.ViewModels
{
    internal class MainWindowViewModel
    {
        private string _title = "Тестовый проект Али";
        public string Title
        {
            get { return _title; }
            set {
                if (_title.Equals(value)) return;
                _title = value; 
            }
        }
    }
}
