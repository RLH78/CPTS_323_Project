using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core;
using SAD.core.Factories;
using SAD.core.Devices;

namespace SadCL
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            IMissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC); 
            // can be set to mock instead of dreamC

            FileReaderFactory readerFactory = new FileReaderFactory();
            FileReader myReader = readerFactory.createFileReader(SAD.core.Factories.fileReaderType.INI);
            
            myLauncher.getName(); // test print
            Console.WriteLine(myReader.readerName);

            IMissileLauncher myMockLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.mock);
            myMockLauncher.getName();

            Console.ReadLine();


        }
    }


}
