using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dice_3D.ViewModels.Base
{
    class RelayCommand : ICommand
    {
        public RelayCommand(Action _action)
        {
            action = _action;
        }
        public event EventHandler CanExecuteChanged;
        private Action action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
