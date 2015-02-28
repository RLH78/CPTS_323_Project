using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.core.Devices;
using SAD.Core.Data;

namespace SAD.Core.Algorithms
{
    public class CommandLine
    {
        IMissileLauncher myLauncher;
        Target[] targets;
        public CommandLine(IMissileLauncher Launcher, Target[] targetz)
        {
            myLauncher = Launcher;
            targets = targetz;
        }

        public void runCommandPrompt()
        {
            string command = "start"; // string that holds the user's command
            int exit = 0; // exit flag
            char[] delimiters = { ' ' };
            string[] words;
            double phi = 0;
            double theta = 0;
            int i = 0; //iterator
            while (exit == 0)
            {
                Console.WriteLine("\nList of Commands: ");
                Console.WriteLine("1. Fire");
                Console.WriteLine("2. Move <phi, theta>");
                Console.WriteLine("3. Moveby <phi, theta>");
                Console.WriteLine("4. Friends");
                Console.WriteLine("5. Scoundrels");
                Console.WriteLine("6. Kill <targetName>");
                Console.WriteLine("7. Status");
                Console.WriteLine("8. Reload");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Please type in one of the commands");
                Console.WriteLine("Example --> Command: Kill targetOne");
                Console.Write("Command: ");
                command = Console.ReadLine();

               int caseNum = determineCaseNumber(command); // determine which case to switch to
               
                switch (caseNum)
                {
                    case 1: // Fire
                        myLauncher.Fire();          
                        break;
                    case 2: // Move <phi, theta>
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        phi = Convert.ToDouble(words[1]);
                        theta = Convert.ToDouble(words[2]);
                        myLauncher.Move(phi, theta);
                        break;
                    case 3: // Moveby <phi, theta>
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        phi = Convert.ToDouble(words[1]);
                        theta = Convert.ToDouble(words[2]);
                        myLauncher.MoveBy(phi, theta);
                        break;
                    case 4: // Friends
                        //    areYouMyFriend(targets, targetCount, command);
                        for (i = 0; i < targets[0].targetCount; i++)
                        {
                            if(targets[i].friend == true)
                            {
                                Console.WriteLine("\nTarget: {0}", targets[i].name);
                                Console.WriteLine("Friend: DO NOT KILL!");
                                Console.WriteLine("Position: x={0}, y={0}, z={0}", targets[i].xCoord, targets[i].yCoord, targets[i].zCoord);
                                Console.WriteLine("Points: {0}", targets[i].points);
                                Console.WriteLine("Status: {0}\n", targets[i].status);
                            }
                        }
                        break;
                    case 5: // scoundrels
                        exit = 1;
                        break;
                    // pass coordinates
                    default:
                        Console.WriteLine("Make sure to enter a correct command");
                        break;
                }
            }

        }

        //Function: determineCaseNumber
        //Input: user command string
        //Return: int, the case number to use in a switch statement 
        //Determines which command the user entered and assigns it a case number
        public static int determineCaseNumber(string userCommand)
        {
            int num = 0;
            userCommand = userCommand.ToUpper();

            if (userCommand == "FIRE" && userCommand.Length == 4)
            {
                num = 1;
            }
            else if (userCommand.Length > 4 && userCommand.Substring(0, 4) == "MOVE")
            {
                num = 2;
            }
            else if (userCommand.Length >= 6 && userCommand.Substring(0, 6) == "MOVEBY")
            {
                num = 3;
            }
            else if (userCommand.Length == 7 && userCommand.Substring(0, 7) == "FRIENDS")
            {
                num = 4;
            }
            else if (userCommand.Length == 4 && userCommand.Substring(0, 4) == "EXIT")
            {
                num = 5;
            }
            else
            {
                num = 0;
            }
            return num;
        }

    }
}
