using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Media.Imaging;



namespace GUI
{
    public class videoViewModel : ReactiveObject
    {
        public videoViewModel()
        {
            //try
            //{
            //    this.capture = new Capture();
            //}
            //catch (Exception)
            //{

            //}

            //cts = new CancellationTokenSource(); // necessary to indicate cancellation of tasks.
            //imageBlockingCollection = new BlockingCollection<Image<Bgr, byte>>(); // Acts as a FIFO. Part of the .NET framework as of .NET 4.0. No bounded capacity.

            //this.Start = ReactiveCommand.Create(this.WhenAnyValue(x => x.IsRunning).Select(x => x == false));
            //this.Start.Subscribe(x => this.StartAcquisition());

            //this.Stop = ReactiveCommand.Create(this.WhenAnyValue(x => x.IsRunning).Select(x => x == true));
            //this.Stop.Subscribe(x => this.StopAcquisition());

            //this.IsRunning = false;
            cts = new CancellationTokenSource(); // necessary to indicate cancellation of tasks.
            imageBlockingCollection = new BlockingCollection<Image<Bgr, byte>>(); // Acts as a FIFO. Part of the .NET framework as of .NET 4.0. No bounded capacity.

            this.Start = ReactiveCommand.Create(this.WhenAnyValue(x => x.IsRunning).Select(x => x == false));
            this.Start.Subscribe(x => this.StartAcquisition());

            this.Stop = ReactiveCommand.Create(this.WhenAnyValue(x => x.IsRunning).Select(x => x == true));
            this.Stop.Subscribe(x => this.StopAcquisition());

            this.IsRunning = false;
        }
        private void StartVideo()
        {
            try
            {
                this.capture = new Capture();
            }
            catch (Exception)
            {

            }
        }
        //Live Stream Video
        //private BitmapSource bitmapImage;
        //private readonly Capture capture;
        //private bool isRunning;
        //private CancellationTokenSource cts;
        //private BlockingCollection<Image<Bgr, byte>> imageBlockingCollection;
        private BitmapSource bitmapImage;
        private Capture capture;
        private bool isRunning;
        private CancellationTokenSource cts;
        private BlockingCollection<Image<Bgr, byte>> imageBlockingCollection;

        /* private void liveVideoFeed()
         {
             Thread workerThread = new Thread(StartAcquisition);
             workerThread.Start();
         }*/
        //Live Video
        private void StartAcquisition()
        {
            //this.IsRunning = true;

            //var producerTask = Task.Run(() => this.ProduceFrame(imageBlockingCollection, cts.Token));
            //var consumerTask = Task.Run(() => this.ConsumeFrame(imageBlockingCollection, cts.Token));
            this.IsRunning = true;

            if (this.capture == null)
            {
                StartVideo();
            }
        }

        private void StopAcquisition()
        {
            this.IsRunning = false;
            this.cts.Cancel();
        }

        /// <summary>
        /// Producer
        /// </summary>
        private void ProduceFrame(BlockingCollection<Image<Bgr, byte>> bc, CancellationToken ct)
        {
            if (this.capture != null)
            {
                while (!ct.IsCancellationRequested)
                {
                    var image = this.capture.QueryFrame();
                    bc.Add(image);
                }

                bc.CompleteAdding();
            }
        }

        private void ConsumeFrame(BlockingCollection<Image<Bgr, byte>> bc, CancellationToken ct)
        {
            while (!bc.IsCompleted)
            {
                var imageToDisplay = bc.Take();
                try
                {
                    App.Current.Dispatcher.Invoke(() => this.BitmapImage = ConvertBitmap.ToBitmapSource(image: imageToDisplay));
                }
                catch
                {

                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref this.isRunning, value);
            }
        }

        public BitmapSource BitmapImage
        {
            get
            {
                return bitmapImage;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref this.bitmapImage, value);
            }
        }

        public ReactiveCommand<object> Start { get; private set; }
        public ReactiveCommand<object> Stop { get; private set; }


    }
}
