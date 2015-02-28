using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.core.Devices;

namespace SAD.Core.Algorithms
{
    public class CommandLine
    {
        IMissileLauncher myLauncher;
        public CommandLine(IMissileLauncher Launcher)
        {
            myLauncher = Launcher;
        }

        public void runCommandPrompt()
        {
            string command = "start"; // string that holds the user's command
            int exit = 0; // exit flag
            char[] delimiters = { ' ' };
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
                        string[] words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                      //  Console.WriteLine("Printing Stuff");
                      //  Console.WriteLine(words[0]); Console.WriteLine(words[1]);//, words[2]);
                        double phi = Convert.ToDouble(words[1]);
                        double theta = Convert.ToDouble(words[2]);
                        myLauncher.Move(phi, theta);
                        //printTargetData(targets, targetCount, command);
                        break;
                    case 3: // convert <file name>
                        //string path = determinePath(command);
                        //  convertToPig(path);
                        break;
                    case 4: // isfriend <file name>
                        //    areYouMyFriend(targets, targetCount, command);
                        break;
                    case 5: //exit
                        exit = 1;
                        break;
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
            else if (userCommand.Length >= 7 && userCommand.Substring(0, 7) == "CONVERT")
            {
                num = 3;
            }
            else if (userCommand.Length >= 8 && userCommand.Substring(0, 8) == "ISFRIEND")
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
