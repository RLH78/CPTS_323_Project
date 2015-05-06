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
        void Kill(double phi, double theta);
        void realKill(int phi, int theta, int currentPhi, int currentTheta);
        void Reset();
        void Status();
        void getName();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();

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
            
            statusPhi = 0;
            statusTheta = 0;

        }
        public string launcherName;

        

        public int statusPhi;

        public int statusTheta;

        public void Fire()
        {
           MissileLauncher test = new MissileLauncher();
           test.command_Fire();            
        }

        public void MoveUp()
        {
            MissileLauncher test = new MissileLauncher();
            test.command_Up(45);
        }
        public void MoveDown()
        {
            MissileLauncher test = new MissileLauncher();
            test.command_Down(45);
        }
        public void MoveLeft()
        {
            MissileLauncher test = new MissileLauncher();
            test.command_Left(45);
        }
        public void MoveRight()
        {
            MissileLauncher test = new MissileLauncher();
            test.command_Right(45);
        }

        public void Move(double phi, double theta)
        {
            int degrees = 0;
            int degrees2 = 0;
            MissileLauncher test = new MissileLauncher();

            if (phi <= 0 && phi >= -90 && theta <= 0 && theta >= -10)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Left(degrees);
                test.command_Down(degrees2);
            }

            else if (phi <= 0 && phi <= -90 && theta >= 0 && theta <= 60)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Left(degrees);
                test.command_Up(degrees2);
            }

            else if (phi >= 0 && phi <= 90 && theta <= 0 && theta >= -10)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Right(degrees);
                test.command_Down(degrees2);
            }

            else if (phi >= 0 && phi <= 90 && theta >= 0 && theta <= 60)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Right(degrees);
                test.command_Up(degrees2);
            }

            else
            {
                Console.WriteLine("Invalid Parameters: phi = -90 to 90 and theta = -10 to 60");
            }
        }

        public void MoveBy(double phi, double theta)
        {
            int degrees = 0;
            int degrees2 = 0;
            MissileLauncher test = new MissileLauncher();

            if (phi <= 0 && phi >= -90 && theta <= 0 && theta >= -10)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_Left(degrees);
                test.command_Down(degrees2);
            }

            else if (phi <= 0 && phi <= -90 && theta >= 0 && theta <= 60)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_Left(degrees);
                test.command_Up(degrees2);
            }

            else if (phi >= 0 && phi <= 90 && theta <= 0 && theta >= -10)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_Right(degrees);
                test.command_Down(degrees2);
            }

            else if (phi >= 0 && phi <= 90 && theta >= 0 && theta <= 60)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_Right(degrees);
                test.command_Up(degrees2);
            }

            else
            {
                Console.WriteLine("Invalid Parameters: phi = -90 to 90 and theta = -10 to 60");
            }


        }

        public void Reset()
        {
            MissileLauncher test = new MissileLauncher();
            test.command_reset();
        }
        public void Reload(/*int missileCount*/)
        {
            //int missileAmt = 4;
            // MissileLauncher test = new MissileLauncher();
            // missileCount = missileAmt;
        }
        public void realKill(int phi, int theta, int currentPhi, int currentTheta)
        {                    
            int degrees = phi;
            int degrees2 = theta;

        //    degrees = degrees - currentPhi;
         //+   degrees2 = degrees2 - currentTheta;

            currentPhi = degrees;
            currentTheta = degrees2;

            MissileLauncher test = new MissileLauncher();
            
            if (phi <= 0 && theta <= 0)
            {            
                test.command_Left(degrees * 22);
                test.command_Down(degrees2 * 22);
                test.command_Fire();
            }
            else if (phi <= 0 && theta >= 0)
            {
                test.command_Left(degrees * 22);
                test.command_Up(degrees2 * 22);
                test.command_Fire();
            }
            else if (phi >= 0 && theta <= 0)
            {               
                test.command_Right(degrees * 22);
                test.command_Down(degrees2 * 22);
                test.command_Fire();
            }

            else if (phi >= 0 && theta >= 0)
            {
                test.command_Right(degrees * 22);
                test.command_Up(degrees2 * 22);
                test.command_Fire();
            }
            
        }
        public void Kill(double phi, double theta)
        {
            int degrees = 0;
            int degrees2 = 0;
            MissileLauncher test = new MissileLauncher();

            if (phi <= 0 && theta <= 0)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Left(degrees);
                test.command_Down(degrees2);
                test.command_Fire();
            }

            else if (phi <= 0 && theta >= 0)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Left(degrees);
                test.command_Up(degrees2);
                test.command_Fire();
            }

            else if (phi >= 0 && theta <= 0)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Right(degrees);
                test.command_Down(degrees2);
                test.command_Fire();
            }

            else if (phi >= 0 && theta >= 0)
            {
                degrees = Convert.ToInt32(Math.Abs(phi * 22));
                degrees2 = Convert.ToInt32(Math.Abs(theta * 22));
                test.command_reset();
                test.command_Right(degrees);
                test.command_Up(degrees2);
                test.command_Fire();
            }

            else
            {
                Console.WriteLine("Invalid Parameters: phi = -90 to 90 and theta = -10 to 60");
            }
        }
        public void Status()
        {
            Console.WriteLine("{0}", launcherName);
        }


        public void getName()
        {

            Console.WriteLine("{0} what", launcherName);
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
        public void Kill(double phi, double theta) { ;}
        public void realKill(int phi, int theta, int currentPhi, int currentTheta) { ;}
        public void Status() { ;}
        public void Reset() { ;}
        public void MoveUp() { ;}
        public void MoveDown() { ;}
        public void MoveLeft() { ;}
        public void MoveRight() { ;}
        public void getName()
        {
            Console.WriteLine(launcherName);
        }
    }




}
