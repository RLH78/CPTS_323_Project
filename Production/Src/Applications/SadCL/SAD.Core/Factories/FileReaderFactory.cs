using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD.core.Factories
{
    public abstract class FileReader
    {
        public string readerName
        {
            get;
            set;
        }
    }

    public sealed class INIFileReader : FileReader
    {
        public INIFileReader()
        {
            readerName = "INI File Reader";
        }
    }

    public sealed class MockFileReader : FileReader
    {
        public MockFileReader()
        {
            readerName = "Mock";
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
