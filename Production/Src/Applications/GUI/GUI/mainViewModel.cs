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
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SAD.Core.Data;
using SAD.core.Data;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading;
using System.Collections.Concurrent;


namespace GUI
{

    public class mainViewModel : ViewModelBase
    {
        public mainViewModel()
        {
            Targets = new ObservableCollection<targetViewModel>();            
        }

        public Target[] targets { get; set; }
        string LoadServerMessage = "This option is unavailable at this time";

        private BitmapSource m_cameraImage;
        private Capture m_capture;

        myCommand showServerMessage;
        myCommand fileLoader;
        myCommand clear;
        myCommand killAll;
        myCommand killFoes;
        myCommand killFriends;
        myCommand TakePictureCommand;
        
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

        public ICommand clear_targets
        {
            get
            {
                if (clear == null)
                {
                    clear = new myCommand(param => clearTargets());
                }
                return clear;
            }
        }
        public ICommand kill_all_targets
        {
            get
            {
                if (killAll == null)
                {
                    killAll = new myCommand(param => killTargets());
                }
                return killAll;
            }
        }
        public ICommand kill_all_foes
        {
            get
            {
                if (killFoes == null)
                {
                    killFoes = new myCommand(param => killAllFoes());
                }
                return killFoes;
            }
        }
        public ICommand kill_all_friends
        {
            get
            {
                if (killFriends == null)
                {
                    killFriends = new myCommand(param => killAllFriends());
                }
                return killFriends;
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
        public ICommand Take_Picture
        {
            get
            {
                if (TakePictureCommand == null)
                {
                    TakePictureCommand = new myCommand(param => TakePicture());
                }
                return TakePictureCommand;
            }
        }
        public string _Load_Server_Message
        {
            get { return LoadServerMessage; }
        }
        public ObservableCollection<targetViewModel> Targets { get; private set; }

        private targetViewModel m_selectedTarget;
        public targetViewModel SelectedTarget
        {
            get
            {
                return m_selectedTarget;
            }
            set
            {
                m_selectedTarget = value;
                OnPropertyChanged();
            }
        }

        public void clearTargets()
        {
           Targets.Clear();
           targets = null;
           OnPropertyChanged("targets");
           OnPropertyChanged("Targets");         
        }

        public void killTargets()
        {
            int i = 0;
            while (i < TargetManager.TotalTargets)
            {
                Targets.ElementAt(i).KillAllTargets();
                i++;
            }            
        }

        public void killAllFoes()
        {
            int i = 0;
            while (i < TargetManager.TotalTargets)
            {
                Targets.ElementAt(i).KillFoes();
                i++;
            }

        }
        public void killAllFriends()
        {
            int i = 0;
            while (i < TargetManager.TotalTargets)
            {
                Targets.ElementAt(i).KillFriends();
                i++;
            }
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
                OnPropertyChanged("targets");
            }
            catch { MessageBox.Show("Error Loading File"); }
            if (worked == true)
            {
                int i = 0;
                while (i < TargetManager.TotalTargets)
                {
                    var newtargetViewModel = new targetViewModel(targets[i]);
                    Targets.Add(newtargetViewModel);                    
                    i++;
                }
                OnPropertyChanged("Targets");
                MessageBox.Show("Successfully loaded: " + openFileDialog.FileName);
            }
        }       
        private void TakePicture()
        {
            if (m_capture == null)
                m_capture = new Capture(0);

            // take a picture

            var image = m_capture.QueryFrame();
            //image.Save(@"C:\Users\test.png");

            var wpfImage = ConvertImageToBitmap(image);
            CameraImage = wpfImage;
        }
       
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr ptr);
        private static BitmapSource ConvertImageToBitmap(IImage image)
        {
            if (image != null)
            {
                using (var source = image.Bitmap)
                {
                    var hbitmap = source.GetHbitmap();
                    try
                    {
                        var bitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero,
                                                     Int32Rect.Empty,
                                                     BitmapSizeOptions.FromEmptyOptions());
                        DeleteObject(hbitmap);
                        bitmap.Freeze();
                        return bitmap;
                    }
                    catch
                    {
                        image = null;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public BitmapSource CameraImage
        {
            get { return m_cameraImage; }
            set
            {
                if (Equals(value, m_cameraImage))
                {
                    return;
                }
                m_cameraImage = value;
                OnPropertyChanged("m_cameraImage");
                OnPropertyChanged("CameraImage");
            }
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

    



