using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using SAD.Core.Data;
using SAD.core.Data;

namespace SAD.core.Factories
{
    public abstract class FileReader
    {
        public string readerName
        {
            get;
            set;
        }
        public abstract Target[] readFile(string pathName);
    }

    public sealed class INIFileReader : FileReader
    {
        public INIFileReader()
        {
            readerName = "INI File Reader";
        }
       
        public Target[] targets;
        public override Target[] readFile(string pathName)
        {
            string line; // the full string that is read in
            int targetCount = 0; // counter for index of Target
            int dataCount = 0; // counter for how many data items have been input
            char[] delimiters = { '=', '#' };
           
            bool commentLine = false; // checks if the line is comment line
            
            targets = TargetManager.getInstance(); //getting an array of targets

            try
            {
                var fileCheck = File.Exists(pathName);
                if (fileCheck == false)
                    throw new Exception("This file doesn't appear to exist. Please check the path you entered.");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
                return targets;
            }
            
            using (TextReader reader = File.OpenText(pathName))
            {             
                while ((line = reader.ReadLine()) != null) 
                {
                    string[] words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    commentLine = false;
                    if (line.StartsWith("#")) // checking if line is a comment
                    {
                        commentLine = true;
                    }

                    if (line.ToUpper() == "[TARGET]") // checking for [Target] header
                    {
                        if(dataCount < 9 && dataCount != 0) // check for missing data
                        {
                            Console.WriteLine("WARNING: There was an error reading the file.\nAre you missing some data?");
                        }

                        if (dataCount == 9) // have all the data. Restart count for next target
                        {
                            dataCount = 0;
                            targetCount++;
                        } 
                        
                        targets[targetCount] = new Target();                       
                    }

                    else if (!string.IsNullOrEmpty(line) && commentLine == false) // if not a comment line and not a space, then found data
                    {
                        targets = TargetClassSetUp(words, targets, targetCount);
                        dataCount++;
                    }                        
                }
            }

            //Console.WriteLine(targets[1].name); //test print to see if it loaded correctly

            Console.WriteLine("\nNew Targets Acquired!");            
            return targets;
        }
        private Target[] TargetClassSetUp(string[] data, Target[] target, int counter)
        {
            try
            {
                if (data.ElementAt(0).ToUpper() == "NAME")
                {
                    target[counter].name = data.ElementAt(1);
                    target[0].targetCount = counter + 1;
                }
                else if (data.ElementAt(0).ToUpper() == "X")
                {
                    target[counter].xCoord = Convert.ToDouble(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "Y")
                {
                    target[counter].yCoord = Convert.ToDouble(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "Z")
                {
                    target[counter].zCoord = Convert.ToDouble(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "FRIEND")
                {
                    target[counter].friend = Convert.ToBoolean(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "POINTS")
                {
                    target[counter].points = Convert.ToInt32(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "FLASHRATE")
                {
                    target[counter].flashRate = Convert.ToInt32(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "SPAWNRATE")
                {
                    target[counter].spawnRate = Convert.ToInt32(data.ElementAt(1));
                }
                else if (data.ElementAt(0).ToUpper() == "CANSWAPSIDESWHENHIT")
                {
                    target[counter].swapSides = Convert.ToBoolean(data.ElementAt(1));
                }
                else
                {
                    Console.WriteLine("WARNING: There was an error in a data label");
                    Console.WriteLine("Please exit the program and fix your target file");
                }
            }
            catch
            {
                Console.WriteLine("WARNING: Some of the data in the target file is not the correct type.\nPlease exit and fix your target file data.");
            }           
            
            return target;
        }
    }

    public sealed class MockFileReader : FileReader
    {
        public MockFileReader()
        {
            readerName = "Mock";
        }
        public override Target[] readFile(string pathName)
        {
            Target[] fake = TargetManager.getInstance();
            return fake;
        }
    }

    public class FileReaderFactory
    {
        public FileReader createFileReader(fileReaderType type)
        {
            FileReader reader = null;

            switch (type)
	        {
		        case fileReaderType.INI:
                    reader = new INIFileReader();
                    break;
                case fileReaderType.mock:
                    reader = new MockFileReader();
                    break;
                default:
                    Console.WriteLine("Tried to create a bad file reader type");
                    break;
	        }
            return reader;
        }
    }

    public enum fileReaderType
	{
        INI,
        mock 
	}



}
