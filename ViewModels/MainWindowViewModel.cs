using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Al25.Infrastuctura.Commands;
using Al25.ViewModels.Base;

namespace Al25.ViewModels
{
    internal class MainWindowViewModel
    {
        #region Constructor 
        public MainWindowViewModel()
        {
            // Инициализация команд
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
        #endregion

        #region Title string :
        private string _title = "Тестовая программа Al25";
        public string Title
        {
            get => _title;
            set { if (_title.Equals(value)) return; 
                _title = value; }
        }
        #endregion
        
        #region Status string : 
        /// <summary>
        /// состояние программы
        /// </summary>
        private string _status = "Готов!";
        /// <summary> состояние программы </summary>
        public string Status
        {
            get => _status;
            set
            {
                if (_status.Equals(value)) return;
                _status = value;
            }
        }
        #endregion

        #region Commands
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            
            System.Windows.Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true; // Здесь можно добавить логику проверки, если нужно

        #endregion

    }
}
