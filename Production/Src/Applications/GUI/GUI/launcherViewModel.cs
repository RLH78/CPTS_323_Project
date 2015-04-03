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
            position_incrementer = 5;
            Name = teamName;          
        }       

        public int position_incrementer { get; set; }
        internal static IMissileLauncher launcher_view_Launcher { get; set; }

        public IMissileLauncher returnLauncher()
        {
            return launcher_view_Launcher;
        }

        private static launcherViewModel launcherInstance;

        public static launcherViewModel getInstance()
        {
            if (launcherInstance == null)
                launcherInstance = new launcherViewModel();

            return launcherInstance;
        }      


        private string m_name { get; set; }
        private string m_modifiedName { get; set; }
        internal static string teamName { get; set; }

        public string settingMessage { get; set; }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string ModifiedName
        {
            get { return m_modifiedName; }
            set
            {
                m_modifiedName = value;
                teamName = m_modifiedName;
                OnPropertyChanged("m_modifiedName");
                OnPropertyChanged("finalName");
            }
        }

        myCommand createDC;
        myCommand createMock;
        myCommand fire;
        myCommand reload;
        myCommand moveUp;
        myCommand moveDown;
        myCommand moveLeft;
        myCommand moveRight;
        myCommand okay;
        myCommand reset;

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
        public ICommand _Reset_Launcher
        {
            get
            {
                if (reset == null)
                {
                    reset = new myCommand(param => resetLauncher());
                }
                return reset;
            }
        }
        public ICommand _Move_Up
        {
            get
            {
                if (moveUp == null)
                {
                    moveUp = new myCommand(param => moveLauncherUp());
                }
                return moveUp;
            }
        }
        public ICommand _Move_Down
        {
            get
            {
                if (moveDown == null)
                {
                    moveDown = new myCommand(param => moveLauncherDown());
                }
                return moveDown;
            }
        }
        public ICommand _Move_Left
        {
            get
            {
                if (moveLeft == null)
                {
                    moveLeft = new myCommand(param => moveLauncherLeft());
                }
                return moveLeft;
            }
        }
        public ICommand _Move_Right
        {
            get
            {
                if (moveRight == null)
                {
                    moveRight = new myCommand(param => moveLauncherRight());
                }
                return moveRight;
            }
        }

        public ICommand _change_Team_Name
        {
            get
            {
                if (okay == null)
                {
                    okay = new myCommand(param => setTeamName());
                }
                return okay;
            }
        }
        /// <summary>
        /// Implementation Functions
        /// </summary>
        /// 
        public void setTeamName()
        {
            ModifiedName = Name;
            teamName = "Team " + ModifiedName;
            OnPropertyChanged("teamName");
            settingMessage = "Name set to " + teamName;
            OnPropertyChanged("settingMessage");
        }
        public void fireZeMissile()
        {
            launcherVars launchv = launcherVars.Instance;            

            if (launchv.missileCount > 0)
            {
                launcher_view_Launcher.Fire();
                launchv.missileCount = launchv.missileCount - 1;               
            }
            else if (launchv.missileCount < 1)
            {
                MessageBox.Show("I just can't do it captain! I don't have the fire power!");
            }

        }
        public void DreamCheekyCreate()
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            launcher_view_Launcher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC);
            //       OnPropertyChanged("launcher_view_Launcher");
            OnPropertyChanged("finalName");
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
            OnPropertyChanged("launcher_view_Launcher");

            MessageBox.Show("Mock Launcher created");
            MainWindow win2 = new MainWindow();
            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "LauncherSelectName");
            win.Close();
            win2.Show();
        }
        public void reloadLauncher()
        {
            launcherVars missilez = launcherVars.Instance;            
            missilez.missileCount = 4;
            launcher_view_Launcher.Reload();            
        }
        public void resetLauncher()
        {
            launcherVars l_vars = launcherVars.Instance; 
            launcher_view_Launcher.Reset();
            l_vars.theta = 0;
            l_vars.phi = 0;
        }
        public void moveLauncherUp()
        {
            launcher_view_Launcher.MoveUp();
            launcherVars l_vars = launcherVars.Instance; 
            l_vars.theta = l_vars.theta + position_incrementer;            
        }
        public void moveLauncherDown()
        {
            launcher_view_Launcher.MoveDown();
            launcherVars l_vars = launcherVars.Instance; 
            l_vars.theta = l_vars.theta - position_incrementer;            
        }
        public void moveLauncherLeft()
        {
            launcherVars l_vars = launcherVars.Instance; 
            launcher_view_Launcher.MoveLeft();
            l_vars.phi = l_vars.phi - position_incrementer;            
        }
        public void moveLauncherRight()
        {
            launcher_view_Launcher.MoveRight();
            launcherVars l_vars = launcherVars.Instance; 
            l_vars.phi = l_vars.phi + position_incrementer;
            OnPropertyChanged("l_phi");
        }
     }

   
    public sealed class launcherVars: ViewModelBase
    {
        public launcherVars()
        {
            l_missiles = 4;
            l_phi = 0;
            l_theta = 0;
        }

        public static launcherVars Instance
        {
            get { return thisInstance; }
        }

        private static launcherVars thisInstance = new launcherVars();

        private int l_missiles;

        public int missileCount
        {
            get { return l_missiles; }
            set 
            {
                l_missiles = value;
                OnPropertyChanged("missileCount");
            }
        }

        private double l_phi;

        public double phi
        {
            get { return l_phi; }
            set
            {
                l_phi = value;
                OnPropertyChanged("phi");
            }
        }

        private double l_theta;

        public double theta
        {
            get { return l_theta; }
            set
            {
                l_theta = value;
                OnPropertyChanged("theta");
            }
        }

    }



}
