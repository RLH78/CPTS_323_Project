using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core;
using SAD.core.Factories;
using SAD.core.Devices;
using SAD.Core.Algorithms;

namespace SadCL
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            IMissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC); 
            // can be set to mock instead of dreamC
            
            myLauncher.getName(); // test print         

            //making a mock launcher
            IMissileLauncher myMockLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.mock);
            myMockLauncher.getName();

            //NOTE TO SELF: reader stuff needs to go in the LOAD command when command prompt is built
            //making a file reader
            FileReaderFactory readerFactory = new FileReaderFactory();
            FileReader myReader = readerFactory.createFileReader(SAD.core.Factories.fileReaderType.INI);

            Console.WriteLine(myReader.readerName);

            //test reading a INI file
            //
            //myReader.readFile("C:\\Users\\Rebecca\\Source\\targets.ini");

            //test reading a mock file
            FileReader myReader2 = readerFactory.createFileReader(SAD.core.Factories.fileReaderType.mock);
            myReader2.readFile("apath");

            Console.WriteLine("Ready to Fire Ze Missiles, Captain!!!!!!!");

            Console.WriteLine("firing????");
            myLauncher.Move(10, 4);
            //myLauncher.Fire();

            CommandLine mine = new CommandLine(myLauncher);

            mine.runCommandPrompt();
            Console.ReadLine();
        }
    }


}
