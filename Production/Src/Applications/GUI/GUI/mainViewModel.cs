using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GUI.Annotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAD.core.Devices;
using System.Windows;
using SAD.core.Factories;
using System.Windows.Input;
using SAD.Core.Data;

namespace GUI
{  

    public class mainViewModel : ViewModelBase
    {
        public mainViewModel()
        {
           // LauncherSelect launcher = new LauncherSelect();
           // myLauncher = launcher.aLauncher;
        }
        
        Target[] targets;
        string LoadServerMessage = "This option is unavailable at this time";

        myCommand showServerMessage;
        myCommand fileLoader;

        public ICommand _Show_Server_Message
        {
            get
            {
                if (showServerMessage == null)
                {
                    showServerMessage = new myCommand(param => MessageBox.Show(_Load_Server_Message));
                }
                return showServerMessage;
            }
        }

        public ICommand _load_INI_File
        {
            get
            {
                if (fileLoader == null)
                {
                    fileLoader = new myCommand(param => loadINIFile());
                }
                return fileLoader;
            }
        }

        public string _Load_Server_Message
        {
            get { return LoadServerMessage; }
        }
        public void loadINIFile()
        {
            var openFileDialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            var worked = openFileDialog.ShowDialog();

            FileReaderFactory readerFactory = new FileReaderFactory();
            FileReader myReader = readerFactory.createFileReader(SAD.core.Factories.fileReaderType.INI);            
            try
            {                
                targets = myReader.readFile(openFileDialog.FileName);                
            }
            catch { MessageBox.Show("Error Loading File"); }
            if (worked == true)
            {
                MessageBox.Show("Successfully loaded: " + openFileDialog.FileName);
            }
        }
    }

    
  






    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }


}
