using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildDefender;

namespace SAD.core.Devices
{

    /// <summary>
    /// The Target Class
    /// </summary>
    public interface IMissileLauncher
    {
        
        void Fire();
        void Move(double phi, double theta);
        void MoveBy(double phi, double theta);
        void Reload();
        void Kill(string targetName);
        void Status();
        void getName();
     }

    /// <summary>
    /// Adapter class for DreamCheeky Missile Launcher
    /// Implementation of DreamCheeky goes here
    /// Use adaptee found in MissileLauncher.cs
    /// </summary>
    public sealed class DreamCheeky : IMissileLauncher
    {
        public DreamCheeky()
        {
            launcherName = "KillShotLauncher!";

        }
        public string launcherName;
        public void Fire() 
        {
            MissileLauncher test = new MissileLauncher();
            test.command_Fire();
        }

        public void Move(double phi, double theta)
        {
            int degrees = 0;
            int degrees2 = 0;
            
            if (phi < 0 && theta < 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));                
                test.command_Left(degrees);
                test.command_Down(degrees2);
            }

            else if (phi < 0 && theta > 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));                
                test.command_Left(degrees);
                test.command_Up(degrees2);
            }

            else if (phi > 0 && theta < 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));                
                test.command_Right(degrees);
                test.command_Down(degrees2);
            }
            
            else if (phi > 0 && theta > 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));                
                test.command_Right(degrees);
                test.command_Up(degrees2);
            }
        }

        public void MoveBy(double phi, double theta)
        {
            int degrees = 0;
            int degrees2 = 0;

            if (phi < 0 && theta < 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(phi * 22);
                degrees2 = Convert.ToInt32(theta * 22);
                test.command_Left(degrees);
                test.command_Down(degrees2);
            }

            else if (phi < 0 && theta > 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(phi * 22);
                degrees2 = Convert.ToInt32(theta * 22);                
                test.command_Left(degrees);
                test.command_Up(degrees2);
            }

            else if (phi > 0 && theta < 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(phi * 22);
                degrees2 = Convert.ToInt32(theta * 22);
                test.command_Right(degrees);
                test.command_Down(degrees2);
            }

            else if (phi > 0 && theta > 0)
            {
                MissileLauncher test = new MissileLauncher();
                degrees = Convert.ToInt32(phi * 22);
                degrees2 = Convert.ToInt32(theta * 22);
                test.command_Right(degrees);
                test.command_Up(degrees2);
            }
        }
        public void Reload() { ;}
        public void Kill(string targetName) { ;}
        public void Status() { ;}
        public void getName()
        {
            Console.WriteLine(launcherName);
        }
    }

    /// <summary>
    /// Adapter Class for Mock Launcher
    /// Implement test functions
    /// </summary>
    public sealed class Mock : IMissileLauncher
    {
        public Mock()
        {
            launcherName = "Boring-Mock-Launcher";
        }
        public string launcherName;
        public void Fire()
        {
            ;
        }
        public void Move(double phi, double theta) { ;}
        public void MoveBy(double phi, double theta) { ;}
        public void Reload() { ;}
        public void Kill(string targetName) { ;}
        public void Status() { ;}
        public void getName()
        {
            Console.WriteLine(launcherName);
        }
    }




}
