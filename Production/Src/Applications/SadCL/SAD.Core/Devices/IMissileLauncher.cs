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
