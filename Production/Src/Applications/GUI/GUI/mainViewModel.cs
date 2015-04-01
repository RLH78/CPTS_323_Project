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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SAD.Core.Data;
using System.Runtime.InteropServices;

namespace GUI
{  

    public class mainViewModel : ViewModelBase
    {
        public mainViewModel()
        {
           
        }

        public Target[] targets { get; set; }
        string LoadServerMessage = "This option is unavailable at this time";

        private BitmapSource m_cameraImage;
        private Capture m_capture;

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

        private void TakePicture()
        {
            if (m_capture == null)
                m_capture = new Capture(0);

            // take a picture

            var image = m_capture.QueryFrame();
            //image.Save(@"c:\data\test.png");

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
