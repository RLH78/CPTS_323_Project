using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI
{
    public class myCommand : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public myCommand(Action<object> inActionToExecute)
            : this(inActionToExecute, null)
        {
            // m_model = model;
        }

        public myCommand(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
        {
            if (inActionToExecute == null)
                throw new ArgumentNullException("execute");

            _ActionToExecute = inActionToExecute;
            _ActionCanExecute = inActionCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _ActionCanExecute == null ? true : _ActionCanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _ActionToExecute(parameter);
        }
    }
}
