using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parse2.ViewModel
{
    internal class MenuCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public AppViewModel avm { get; set; }

        public MenuCommand(AppViewModel avm)
        {
            this.avm = avm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            avm.OnExecute();
        }
    }
}
