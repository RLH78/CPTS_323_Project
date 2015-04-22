using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core.Data;
using System.Windows;
using System.Collections.ObjectModel;
using SAD.core.Data;
using System.Windows.Input;
using SAD.core.Devices;
namespace GUI
{
    /// <summary>
    /// View of a single target
    /// </summary>
    public class targetViewModel : ViewModelBase
    {

        public targetViewModel(Target aSingleTarget)
        {
            m_target = aSingleTarget;
            OnPropertyChanged("m_target");
            this.model = launcherViewModel.getInstance();
            target_view_Launcher = model.returnLauncher();            
        }
        

        private Target m_target;

        public IMissileLauncher target_view_Launcher;

        public launcherViewModel model;

        myCommand kill;

        public Target Target
        {
            get { return m_target; }
        }
        public bool getFriend()
        {
            return m_target.friend;
        }

        public ICommand _kill_target
        {
            get
            {
                if (kill == null)
                {
                    kill = new myCommand(param => KillTarget());
                }
                return kill;
            }
        }
        public void KillTarget()
        {
            if (m_target.friend == false)
            {
                if (m_target.alive == true)
                {
                    double place_hold = 0;
                    double place_hold2 = 0;
                    double realPhi = 0;
                    double realTheta = 0;
                    int degrees = 0;
                    int degrees2 = 0;

                    place_hold = m_target.xCoord / m_target.yCoord;
                    place_hold2 = Math.Sqrt((m_target.xCoord * m_target.xCoord) + (m_target.yCoord * m_target.yCoord));
                    realPhi = Math.Atan(place_hold);
                    realTheta = Math.Atan(m_target.zCoord / place_hold2);
                    degrees = Convert.ToInt32(realPhi * (180 / Math.PI));
                    degrees2 = Convert.ToInt32(realTheta * (180 / Math.PI));

                    target_view_Launcher.realKill(degrees, degrees2);

                    m_target.alive = false;                    
                    launcherVars missilez = launcherVars.Instance;
                    missilez.missileCount = missilez.missileCount - 1;
                    missilez.phi = degrees;
                    missilez.theta = degrees2;
                    OnPropertyChanged("m_target");                    
                }
                else
                {
                    MessageBox.Show("It's already dead, Captain! Don't waste our missiles!");
                }
            }
            else
            {
                MessageBox.Show("Don't shoot our friends!!");
            }
        }
    }
}

