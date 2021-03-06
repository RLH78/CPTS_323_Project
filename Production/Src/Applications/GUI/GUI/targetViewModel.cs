﻿using System;
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

        ~targetViewModel() { }        

        private Target m_target;

        public IMissileLauncher target_view_Launcher;

        public launcherViewModel model;

        myCommand kill;
        myCommand killAll;
        myCommand killFoes;
        myCommand killFriends;
        myCommand killBlinkingFoes;
        myCommand killBlinky;

        public Target Target
        {
            get { return m_target; }
        }
        public bool getFriend()
        {
            return m_target.friend;
        }

        public ICommand _kill_all_target
        {
            get
            {
                if (killAll == null)
                {
                    killAll = new myCommand(param => KillAllTargets());
                }
                return killAll;
            }
        }
        public ICommand _kill_all_foes
        {
            get
            {
                if (killFoes == null)
                {
                    killFoes = new myCommand(param => KillFoes());
                }
                return killFoes;
            }
        }
        public ICommand _kill_all_friends
        {
            get
            {
                if (killFriends == null)
                {
                    killFriends = new myCommand(param => KillFriends());
                }
                return killFriends;
            }
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
        public ICommand _kill_blinkers
        {
            get
            {
                if (killBlinkingFoes == null)
                {
                    killBlinkingFoes = new myCommand(param => KillBlinkingEnemies());
                }
                return killBlinkingFoes;
            }
        }
        public ICommand _kill_mr_blinky
        {
            get
            {
                if (killBlinky == null)
                {
                    killBlinky = new myCommand(param => KillAllBlinking());
                }
                return killBlinky;
            }
        }
        public void KillAllBlinking()
        {
            launcherVars newVars = launcherVars.Instance;
            if (m_target.isBlinking == true)
            {
                try
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

                    target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

                    m_target.alive = false;
                    launcherVars missilez = launcherVars.Instance;
                    missilez.missileCount = missilez.missileCount - 1;
                    missilez.phi = degrees;
                    missilez.theta = degrees2;
                    OnPropertyChanged("m_target");

                }
                catch { }
            }
        }
        public void KillBlinkingEnemies()
        {
            launcherVars newVars = launcherVars.Instance;
            if (m_target.friend == false && m_target.isBlinking == true)
            {
                try
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

                    target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

                    m_target.alive = false;
                    launcherVars missilez = launcherVars.Instance;
                    missilez.missileCount = missilez.missileCount - 1;
                    missilez.phi = degrees;
                    missilez.theta = degrees2;
                    OnPropertyChanged("m_target");

                }
                catch { }
            }
        }
        public void KillTarget()
        {
            try
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
                        launcherVars newVars = launcherVars.Instance;

                        place_hold = m_target.xCoord / m_target.yCoord;
                        place_hold2 = Math.Sqrt((m_target.xCoord * m_target.xCoord) + (m_target.yCoord * m_target.yCoord));
                        realPhi = Math.Atan(place_hold);
                        realTheta = Math.Atan(m_target.zCoord / place_hold2);
                        degrees = Convert.ToInt32(realPhi * (180 / Math.PI));
                        degrees2 = Convert.ToInt32(realTheta * (180 / Math.PI));

                        target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

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
            catch { }
        }
        public void KillAllTargets()
        {
            launcherVars newVars = launcherVars.Instance;
            try
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

                    target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

                    m_target.alive = false;
                    launcherVars missilez = launcherVars.Instance;
                    missilez.missileCount = missilez.missileCount - 1;
                    missilez.phi = degrees;
                    missilez.theta = degrees2;
                    OnPropertyChanged("m_target");
                
            }
            catch { }
        }
        public void KillFoes()
        {
            try
            {
                if (m_target.friend == false)
                {
                   
                        double place_hold = 0;
                        double place_hold2 = 0;
                        double realPhi = 0;
                        double realTheta = 0;
                        int degrees = 0;
                        int degrees2 = 0;

                        launcherVars newVars = launcherVars.Instance;

                        place_hold = m_target.xCoord / m_target.yCoord;
                        place_hold2 = Math.Sqrt((m_target.xCoord * m_target.xCoord) + (m_target.yCoord * m_target.yCoord));
                        realPhi = Math.Atan(place_hold);
                        realTheta = Math.Atan(m_target.zCoord / place_hold2);
                        degrees = Convert.ToInt32(realPhi * (180 / Math.PI));
                        degrees2 = Convert.ToInt32(realTheta * (180 / Math.PI));

                        target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

                        m_target.alive = false;
                        launcherVars missilez = launcherVars.Instance;
                        missilez.missileCount = missilez.missileCount - 1;
                        missilez.phi = degrees;
                        missilez.theta = degrees2;
                        OnPropertyChanged("m_target");
                   
                }
            }
            catch { }
        }
        public void KillFriends()
        {
            try
            {
                if (m_target.friend == true)
                {
                    
                        double place_hold = 0;
                        double place_hold2 = 0;
                        double realPhi = 0;
                        double realTheta = 0;
                        int degrees = 0;
                        int degrees2 = 0;

                        launcherVars newVars = launcherVars.Instance;

                        place_hold = m_target.xCoord / m_target.yCoord;
                        place_hold2 = Math.Sqrt((m_target.xCoord * m_target.xCoord) + (m_target.yCoord * m_target.yCoord));
                        realPhi = Math.Atan(place_hold);
                        realTheta = Math.Atan(m_target.zCoord / place_hold2);
                        degrees = Convert.ToInt32(realPhi * (180 / Math.PI));
                        degrees2 = Convert.ToInt32(realTheta * (180 / Math.PI));

                        target_view_Launcher.realKill(degrees, degrees2, newVars.phi, newVars.theta);

                        m_target.alive = false;
                        launcherVars missilez = launcherVars.Instance;
                        missilez.missileCount = missilez.missileCount - 1;
                        missilez.phi = degrees;
                        missilez.theta = degrees2;
                        OnPropertyChanged("m_target");
                    

                }
            }
            catch { }
        }

        public double getScore()
        {
            return m_target.score;
        }
        
    }
}

