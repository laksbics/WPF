using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_mvvm.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public Action<object> _Execute { get; set; }
        public Predicate<object> _CanExute { get; set; }

        public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod) {
                _Execute = ExcuteMethod;
                _CanExute = CanExcuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}
