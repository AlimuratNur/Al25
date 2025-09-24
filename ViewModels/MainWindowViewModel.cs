using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Markup;
using Al25.Infrastuctura.Commands;
using Al25.Models;
using Al25.Models.Decanat;
using Al25.ViewModels.Base;
using Newtonsoft.Json.Converters;
using OxyPlot;
using OxyPlot.Series;


namespace Al25.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region SelectedPage

        private int _SelectedPageIndex;
        public int SelectedPageIndex { 
            get => _SelectedPageIndex; 
            set => Set(ref _SelectedPageIndex, value); }

        #endregion

        #region PlotModel
        public PlotModel MyPlotModel { get;  }
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

        #region Student and Groups

        public Collection<Group> Groups { get;  }

        #endregion

        /*--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        #region Commands

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            
            System.Windows.Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true; // Здесь можно добавить логику проверки, если нужно

        #endregion

        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommnadExecute(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);

        }
        #endregion

        #endregion

        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public MainWindowViewModel()
        {
            #region Команды
            // Инициализация команд
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommnadExecute, CanChangeTabIndexCommandExecute);
            #endregion
            
            #region OxyPLotInit
            MyPlotModel = new PlotModel();
            MyPlotModel.Series.Add(new FunctionSeries(Math.Sin, 0, 10 ,0.1 , "Sin"));

            #endregion

            var studentIndex = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {studentIndex}",
                Surname = $"Surname {studentIndex}",
                Patronymic = $"Patronomic {studentIndex++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var group = Enumerable.Range(1, 20).Select(g => new Group
            {
                Name = $"Name {g}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(group);
        }
    }
}
