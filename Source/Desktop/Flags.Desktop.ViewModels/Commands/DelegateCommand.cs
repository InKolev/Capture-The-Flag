namespace Flags.Desktop.ViewModels.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action action)
        {
            this.Action = action;
        }

        private Action Action { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Action();
        }
    }
}