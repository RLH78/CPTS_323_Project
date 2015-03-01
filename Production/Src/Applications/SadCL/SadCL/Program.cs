using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core;
using SAD.core.Factories;
using SAD.core.Devices;
using SAD.Core.Algorithms;
using SAD.Core.Data;

namespace SadCL
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            IMissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC); 
            // can be set to mock instead of dreamC               

            Console.WriteLine("Ready to Fire Ze Missiles, Captain!!!!!!!");

            CommandLine mine = new CommandLine(myLauncher);
            mine.runCommandPrompt();           
        }
    }
}
