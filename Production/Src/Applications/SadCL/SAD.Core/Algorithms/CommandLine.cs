using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.core.Devices;
using SAD.Core.Data;
using SAD.core.Data;
using SAD.core.Factories;

namespace SAD.Core.Algorithms
{
    public class CommandLine
    {
        IMissileLauncher myLauncher;
        Target[] targets;
        public CommandLine(IMissileLauncher Launcher)
        {
            myLauncher = Launcher;            
        }

        public void runCommandPrompt()
        {
            string command = "start"; // string that holds the user's command
            int exit = 0; // exit flag
            int tempCounter = 0; // counter used in Kill target
            bool foundName = false; // used in Kill target case
            char[] delimiters = { ' ' };
            string[] words;
            double phi = 0;
            double theta = 0;
            int i = 0; //iterator
            int missileNum = 4;

            while (exit == 0)
            {
                Console.WriteLine("\nChoose a Command: ");
                Console.WriteLine("1.  Fire");
                Console.WriteLine("2.  Move <phi, theta>");
                Console.WriteLine("3.  Moveby <phi, theta>");
                Console.WriteLine("4.  Friends");
                Console.WriteLine("5.  Scoundrels");
                Console.WriteLine("6.  Kill <targetName>");
                Console.WriteLine("7.  Status");
                Console.WriteLine("8.  Reload");
                Console.WriteLine("9.  Reset");
                Console.WriteLine("10. Load <filepath>");
                Console.WriteLine("11. Exit");
                Console.WriteLine("Please type in one of the commands");
                Console.WriteLine("Example --> Command: Kill targetOne");
                Console.Write("Command: ");
                command = Console.ReadLine();

               int caseNum = determineCaseNumber(command); // determine which case to switch to
               
                switch (caseNum)
                {
                    case 1: // Fire
                        if(missileNum > 0)
                        {
                            myLauncher.Fire();
                        }
                        else if(missileNum < 1)
                        {
                            Console.WriteLine("I just can't do it captain I don't have the fire power!");
                        }                        
                        missileNum = missileNum - 1;
                        break;
                    case 2: // Move <phi, theta>
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            phi = Convert.ToDouble(words[1]);
                            theta = Convert.ToDouble(words[2]);
                            myLauncher.Move(phi, theta);
                        }
                        catch { Console.WriteLine("Make sure to enter the correct number/type of entries"); }
                        break;
                    case 3: // Moveby <phi, theta>                        
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);                        
                        try
                        {                            
                            phi = Convert.ToDouble(words[1]);
                            theta = Convert.ToDouble(words[2]);
                            myLauncher.MoveBy(phi, theta);
                            
                        }
                        catch { Console.WriteLine("Make sure to enter the correct number/type of entries"); }
                        break;
                    case 4: // Friends
                        try
                        {
                            for (i = 0; i < TargetManager.TotalTargets; i++)
                            {
                                if (targets[i].friend == true)
                                {
                                    Console.WriteLine("\nTarget: {0}", targets[i].name);
                                    Console.WriteLine("Friend: YES! DO NOT KILL!");
                                    Console.WriteLine("Position: x={0}, y={1}, z={2}", targets[i].xCoord, targets[i].yCoord, targets[i].zCoord);
                                    Console.WriteLine("Points: {0}", targets[i].points);
                                    if (targets[i].alive == true)
                                    {
                                        Console.WriteLine("Status: Not dead . . . yet");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Status: He's dead, Jim");
                                    }
                                }
                            }
                        }
                        catch { Console.WriteLine("Make sure a file is loaded"); }
                        break;
                    case 5: // Scoundrels
                        try
                        {
                            for (i = 0; i < TargetManager.TotalTargets; i++)
                            {
                                if (targets[i].friend == false)
                                {
                                    Console.WriteLine("\nTarget: {0}", targets[i].name);
                                    Console.WriteLine("Friend: ENEMY! DESTROY! DESTROY!");
                                    Console.WriteLine("Position: x={0}, y={1}, z={2}", targets[i].xCoord, targets[i].yCoord, targets[i].zCoord);
                                    Console.WriteLine("Points: {0}", targets[i].points);
                                    if (targets[i].alive == true)
                                    {
                                        Console.WriteLine("Status: Not dead . . . yet");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Status: He's dead, Jim");
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Make sure a file is loaded");
                        }
                        break;
                    case 6: // Kill <targetName>
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        tempCounter = 0; // resetting these values
                        foundName = false;

                        //Finding a Target that matches user's entry 
                        try
                        {
                            for (i = 0; i < TargetManager.TotalTargets; i++)
                            {
                                if (targets[i].name.ToUpper() == words[1].ToUpper())
                                {
                                    tempCounter = i;
                                    foundName = true;
                                }
                            }                            
                        }                         
                        catch { Console.WriteLine("Don't forget to include a name after 'Kill'"); }

                        try
                        {
                            //Finding if target is friend, enemy, or nonexistent
                            if (targets[tempCounter].friend == true && foundName == true)
                            {
                                Console.WriteLine("What are you doing? Don't shoot our friends!");
                            }
                            //Section that kills targets
                            else if (targets[tempCounter].friend == false && foundName == true)
                            {
                                myLauncher.Kill(targets[tempCounter].xCoord, targets[tempCounter].zCoord);
                                targets[tempCounter].alive = false;

                                TargetManager.RemainingEnemyTargets = TargetManager.RemainingEnemyTargets - 1;                                                                
                            }
                            else
                            {
                                Console.WriteLine("That target doesn't exist");
                            }
                        }
                        catch { Console.WriteLine("Make sure a file is loaded");}
                        break;
                    case 7: // status
                        myLauncher.Status();
                        Console.WriteLine("{0} of 4 missiles remaining", missileNum); 
                        break;
                    case 8: // reload
                        missileNum = 4;
                        myLauncher.Reload();                        
                        break;
                    case 9: // reset
                        myLauncher.Reset();                        
                        break;
                    case 10: // load
                        FileReaderFactory readerFactory = new FileReaderFactory();
                        FileReader myReader = readerFactory.createFileReader(SAD.core.Factories.fileReaderType.INI);
                        words = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            targets = myReader.readFile(words[1]);
                        }
                        catch { Console.WriteLine("Did you enter that correctly?"); }
                       //Un-comment this if you don't want to copy/paste the path
                       // targets = myReader.readFile("C:\\Users\\Rebecca\\Source\\targets.ini"); 
                        break;
                    case 11: // exit
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
            else if (userCommand.Length >= 6 && userCommand.Substring(0, 6) == "MOVEBY")
            {
                num = 3;
            }
            else if (userCommand.Length == 7 && userCommand.Substring(0, 7) == "FRIENDS")
            {
                num = 4;
            }
            else if (userCommand.Length == 10 && userCommand.Substring(0, 10) == "SCOUNDRELS")
            {
                num = 5;
            }
            else if (userCommand.Length >= 4 && userCommand.Substring(0, 4) == "KILL")
            {
                num = 6;
            }
            else if (userCommand.Length == 6 && userCommand.Substring(0, 6) == "STATUS")
            {
                num = 7;
            }
            else if (userCommand.Length == 6 && userCommand.Substring(0, 6) == "RELOAD")
            {
                num = 8;
            }
            else if (userCommand.Length == 5 && userCommand.Substring(0, 5) == "RESET")
            {
                num = 9;
            }
            else if (userCommand.Length >= 4 && userCommand.Substring(0, 4) == "LOAD")
            {
                num = 10;
            }           
            else if (userCommand.Length == 4 && userCommand.Substring(0, 4) == "EXIT")
            {
                num = 11;
            }
            else
            {
                num = 0;
            }
            return num;
        }

    }
}
