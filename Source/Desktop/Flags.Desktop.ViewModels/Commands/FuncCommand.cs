namespace Flags.Desktop.ViewModels.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class FuncCommand : ICommand
    {
        private Func<int, bool> funky;

        public FuncCommand(Func<int, bool> funky)
        {
            this.funky = funky;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var argument = int.Parse(parameter.ToString());
            this.funky(argument);
        }
    }
}