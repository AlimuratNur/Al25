using System.Windows;
using Al25.Infrastuctura.Commands.Base;

namespace Al25.Infrastuctura.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object paramenter) => Application.Current.Shutdown();
    }
}
