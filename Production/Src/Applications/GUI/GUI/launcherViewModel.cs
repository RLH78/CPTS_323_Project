﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAD.core.Factories;
using SAD.core.Devices;
using System.Windows;

namespace GUI
{
    public class launcherViewModel : ViewModelBase
    {
        public launcherViewModel()
        {
            missileCount = 4;
        }

        myDCCreator createDC;
        myMockCreator createMock;
        myFire fire;

        public IMissileLauncher launcher_view_Launcher { get; private set; }

        public int missileCount { get; set; }

        /// <summary>
        /// ICommands
        /// </summary>
        public ICommand _create_DC_Command
        {
            get
            {
                if (createDC == null)
                {
                    createDC = new myDCCreator(param => DreamCheekyCreate());
                }
                return createDC;
            }
        }
        public ICommand _create_Mock_Command
        {
            get
            {
                if (createMock == null)
                {
                    createMock = new myMockCreator(param => MockCreate());
                }
                return createMock;
            }
        }

        public ICommand _Fire_Missile
        {
            get
            {
                if (fire == null)
                {
                    fire = new myFire(param => fireZeMissile());
                }
                return fire;
            }
        }

        
       /// <summary>
        /// Implementation Functions
        /// </summary>
        public void fireZeMissile()
        {
            if (missileCount > 0)
            {
              //  launcher_view_Launcher.Fire();
                
                missileCount = missileCount - 1;
                OnPropertyChanged("missileCount");
            }
            else if (missileCount < 1)
            {
                MessageBox.Show("I just can't do it captain! I don't have the fire power!");
            }
            
        }
        public void DreamCheekyCreate()
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            launcher_view_Launcher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC);
            MessageBox.Show("DreamCheeky created");
            MainWindow win2 = new MainWindow();            
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "LauncherSelectName");
            win.Close();  
            win2.Show(); 
        }  
        public void MockCreate()
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            launcher_view_Launcher = factory.createMissileLauncher(SAD.core.Factories.launcherType.mock);
            MessageBox.Show("Mock Launcher created");
            MainWindow win2 = new MainWindow();
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "LauncherSelectName");
            win.Close();
            win2.Show();
        }
     
    }

    public class myDCCreator : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public myDCCreator(Action<object> inActionToExecute)
            : this(inActionToExecute, null)
        {
            // m_model = model;
        }

        public myDCCreator(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
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

    public class myMockCreator : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public myMockCreator(Action<object> inActionToExecute)
            : this(inActionToExecute, null)
        {
            // m_model = model;
        }

        public myMockCreator(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
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

    public class myFire : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public myFire(Action<object> inActionToExecute)
            : this(inActionToExecute, null)
        {
            // m_model = model;
        }

        public myFire(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
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
