using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Markup;
using Al25.Infrastuctura.Commands;
using Al25.Models;
using Al25.ViewModels.Base;

namespace Al25.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region DatatPoint
        private IEnumerable<DataPoint> _points;
        public IEnumerable<DataPoint> Points { get => _points; set => Set(ref _points, value); }
        

        #endregion

        #region Constructor 
        public MainWindowViewModel()
        {
            // Инициализация команд
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            var data_point = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                var y = Math.Sin(x * Math.PI / 180);
                data_point.Add(new DataPoint { XValue = x, YValue = y });
            }

            Points = data_point;
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
