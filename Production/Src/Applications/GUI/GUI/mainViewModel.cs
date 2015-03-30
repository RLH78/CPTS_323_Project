using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GUI.Annotations;
using System.Text;
using System.Threading.Tasks;
using SAD.core.Devices;
using System.Windows;
using SAD.core.Factories;

using System.Windows.Input;

namespace GUI
{  

    public class mainViewModel : ViewModelMediator
    {
        mainViewModel()
        {
            LauncherSelect launcher = new LauncherSelect();
            myLauncher = launcher.aLauncher;
        }

        private IMissileLauncher myLauncher;

    
    }

    
  


    /// <summary>
    /// mediator outline
    /// </summary>
    abstract class Colleague
    {

    }
    class ConcreteColleague1 : Colleague
    {

    }
    class ConcreteColleague2 : Colleague
    {

    }




    public abstract class ViewModelMediator : INotifyPropertyChanged
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

    public class MyCommand : ICommand
    {
        private Action m_action;

        public MyCommand(Action someAction)
        {
            m_action = someAction;
        }

        #region Implementation of ICommand
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            m_action();
        }
        public event EventHandler CanExecuteChanged;
        #endregion
    }

    public class ACommand : ICommand
    {
        private mainViewModel m_model;

        public ACommand(mainViewModel model)
        {
            m_model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
           // m_model.Dream_Cheeky_Checked();
        }
    }


}
