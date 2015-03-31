using System;
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

        myCommand createDC;
        myCommand createMock;
        myCommand fire;
        myCommand reload;

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
                    createDC = new myCommand(param => DreamCheekyCreate());
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
                    createMock = new myCommand(param => MockCreate());
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
                    fire = new myCommand(param => fireZeMissile());
                }
                return fire;
            }
        }

        public ICommand _Reload_Missiles
        {
            get
            {
                if (reload == null)
                {
                    reload = new myCommand(param => reloadLauncher());
                }
                return reload;
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
        
        public void reloadLauncher()
        {
            missileCount = 4;
            OnPropertyChanged("missileCount");
        }
    }


   
}
