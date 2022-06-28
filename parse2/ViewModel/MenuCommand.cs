using System;
using System.Windows.Input;

namespace parse2.ViewModel
{
    public class MenuCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public AppViewModel avm { get; set; }

        public MenuCommand(AppViewModel a)
        {
            avm = a;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            avm.OnExecute(parameter);
        }
    }
}
