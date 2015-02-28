using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core;
using SAD.core.Factories;

namespace SadCL
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            MissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC); 
            // can be set to mock instead of dreamC
            
            Console.WriteLine(myLauncher.launcherName); // test print
            Console.ReadLine();

        }
    }


}
