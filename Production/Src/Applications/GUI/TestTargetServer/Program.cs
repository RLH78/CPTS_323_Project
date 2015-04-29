using System;
using TargetServerCommunicator.Data;
using TargetServerCommunicator.Servers;

namespace TestTargetServer
{
    class Program
    {      
        static void PrintTarget(Target target)
        {
            Console.WriteLine();
            Console.WriteLine("\tName: " + target.name);
            Console.WriteLine("\t\tHits: " + target.hit);
            Console.WriteLine("\t\tDuty Cycle: " + target.dutyCycle);
				Console.WriteLine("\t\tLED: " + target.led);
				Console.WriteLine("\t\tInput: " + target.input);
				Console.WriteLine("\t\tScore: " + target.score);
        }
        static void Main(string[] args)
        {           

            // Create a client to server interface
            string teamName = "sqrtdos";
            var serverType  = GameServerType.Mock;
            serverType      = GameServerType.WebClient; // if you want the real server ... otherwise this will do

            // make sure you have a way to specify the IP address and port dynamically at run time, e.g. through a GUI
            var gameServer  = GameServerFactory.Create(serverType, teamName, "192.168.1.80", 3000);
            var data        = gameServer.RetrieveGameList();
            
            // kill anything that is running...make sure you handle WebExceptions
            gameServer.StopRunningGame();

            // Display the games retrieved from the server
            Console.WriteLine("Available Games:");
            foreach(var game in data)
            {
                Console.WriteLine("\t" + game);
            }

            // Starts a game
            Console.WriteLine("Start Game [Enter Name]?");
            var gameName = Console.ReadLine();
            var targets = gameServer.RetrieveTargetList(gameName);
            gameServer.StartGame(gameName);
             
            // Make sure the user can stop the stupid game....
            Console.WriteLine("Type stop to stop [stop] other for target list");
            var input = Console.ReadLine();

            while (input != "stop")
            {
                // Then print out the target data as it was "hit"
                Console.WriteLine("Printing target data...");
                targets = gameServer.RetrieveTargetList(gameName);
                foreach (var target in targets)
                {
                    PrintTarget(target);
                }
                input = Console.ReadLine();
            }
            // Then call to stop the game 
            Console.WriteLine("Stopping Game");
            gameServer.StopRunningGame();
            
            // and let the user gaulk
            Console.WriteLine("Any key to exit...");
            Console.ReadLine();
        }
    }
}
