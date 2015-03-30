using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GUI.Annotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAD.core.Devices;
using System.Windows;
using SAD.core.Factories;
using System.Windows.Input;

namespace GUI
{  

    public class mainViewModel : ViewModelBase
    {
        public mainViewModel()
        {
           // LauncherSelect launcher = new LauncherSelect();
           // myLauncher = launcher.aLauncher;
        }
        private IMissileLauncher myLauncher;

        string LoadServerMessage = "This option is unavailable at this time";

        myServerMessage showServerMessage;

        public ICommand _Show_Server_Message
        {
            get
            {
                if (showServerMessage == null)
                {
                    showServerMessage = new myServerMessage(param => MessageBox.Show(_Load_Server_Message));
                }
                return showServerMessage;
            }
        }

        public string _Load_Server_Message
        {
            get { return LoadServerMessage; }
        }   
    }

    
  






    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class myServerMessage : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public myServerMessage(Action<object> inActionToExecute) 
            : this(inActionToExecute, null)
        {
           // m_model = model;
        }

        public myServerMessage(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
        {
            if (inActionToExecute == null)
                throw new ArgumentNullException("execute");

            _ActionToExecute = inActionToExecute;
            _ActionCanExecute = inActionCanExecute;
        }

        public bool CanExecute(object parameter)
        {
           // throw new NotImplementedException();
            return _ActionCanExecute == null ? true : _ActionCanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
           // throw new NotImplementedException();
            _ActionToExecute(parameter);
        }
    }


}
