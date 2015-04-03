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
            launcherViewModel model = new launcherViewModel();
            target_view_Launcher = model.returnLauncher();
        }

        private Target m_target;

        public IMissileLauncher target_view_Launcher;

        myCommand kill;

        public Target Target
        {
            get { return m_target; }
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
        private void KillTarget()
        {
            if (m_target.friend == false)
            {
                if (m_target.alive == true)
                {
                    target_view_Launcher.realKill(m_target.xCoord, m_target.yCoord, m_target.zCoord);
                    m_target.alive = false;
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

