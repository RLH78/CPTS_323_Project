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
            l_phi = 0;
            l_theta = 0;
            position_incrementer = 5;
            Name = teamName;
                   
        }

        public int l_phi {get; set;}
        public int l_theta { get; set; }
        public int position_incrementer { get; set; }
        internal static IMissileLauncher launcher_view_Launcher { get; private set; }
        public int missileCount { get; set; }
        
        private string m_name{get; set;}
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
            if (missileCount > 0)
            {
              launcher_view_Launcher.Fire();
                
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
            missileCount = 4;
          //  launcher_view_Launcher.Reload();
            OnPropertyChanged("missileCount");
        }
        public void resetLauncher()
        {
            launcher_view_Launcher.Reset();
            l_theta = 0;
            OnPropertyChanged("l_theta");
            l_phi = 0;
            OnPropertyChanged("l_phi");
        }
        public void moveLauncherUp()
        {
            launcher_view_Launcher.MoveUp();
            l_theta = l_theta + position_incrementer;
            OnPropertyChanged("l_theta");
        }
        public void moveLauncherDown()
        {
            launcher_view_Launcher.MoveDown();
            l_theta = l_theta - position_incrementer;
            OnPropertyChanged("l_theta");
        }
        public void moveLauncherLeft()
        {
            launcher_view_Launcher.MoveLeft();
            l_phi = l_phi - position_incrementer;
            OnPropertyChanged("l_phi");
        }
        public void moveLauncherRight()
        {
            launcher_view_Launcher.MoveRight();
            l_phi = l_phi + position_incrementer;
            OnPropertyChanged("l_phi");
        }
    }


   
}
