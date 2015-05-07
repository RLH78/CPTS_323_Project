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
using TargetServerCommunicator.Data;
using TargetServerCommunicator.Servers;
using TargetServerCommunicator;

namespace GUI
{

    public class mainViewModel : ViewModelBase
    {
        public mainViewModel()
        {
            Targets = new ObservableCollection<targetViewModel>();
            PriorityTargets = new ObservableCollection<targetViewModel>();
            list = new List<Target>();
            score = 0.0;
        }

        public Target[] targets { get; set; }
        string LoadServerMessage = "This option is unavailable at this time";

        PriorityQueue<Target> targetPriorityQueue = new PriorityQueue<Target>();

        private BitmapSource m_cameraImage;
        private Capture m_capture;
        public IMissileLauncher mainViewMissile;

        private string ipa { get; set; }

        private int prt { get; set; }
        public string IPAddress
        {
            get { return ipa; }
            set { ipa = value;
            OnPropertyChanged();
            }
        }
        public int Port
        {
            get { return prt; }
            set
            {
                prt = value;
                OnPropertyChanged();
            }
        }

        myCommand showServerMessage;
        myCommand fileLoader;
        myCommand clear;
        myCommand killAll;
        myCommand killFoes;
        myCommand killFriends;
        myCommand killLtoR;
        myCommand killBlink;
        myCommand TakePictureCommand;
        myCommand serverStart;
        myCommand serverStop;
        myCommand loadfromserver;
        myCommand loadgame;

        public ICommand load_game_from_server
        {
            get
            {
                if (loadgame == null)
                {
                    loadgame = new myCommand(param => loadGameFromServer());
                }
                return loadgame;
            }
        }

         public ICommand load_from_server
        {
            get
            {
                if (loadfromserver == null)
                {
                    loadfromserver = new myCommand(param => loadFromServer());
                }
                return loadfromserver;
            }
        }
        
        public ICommand start_server
        {
            get
            {
                if (serverStart == null)
                {
                    serverStart = new myCommand(param => startServerGame());
                }
                return serverStart;
            }
        }

        public ICommand stop_server
        {
            get
            {
                if (serverStop == null)
                {
                    serverStop = new myCommand(param => stopServerGame());
                }
                return serverStop;
            }
        }
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
        public ICommand kill_all_enemy_blinkers
        {
            get
            {
                if (killBlink == null)
                {
                    killBlink = new myCommand(param => killBlinkingAll());
                }
                return killBlink;
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
        public ICommand kill_left_to_right
        {
            get
            {
                if (killLtoR == null)
                {
                    killLtoR = new myCommand(param => killTargetsLeftToRight());
                }
                return killLtoR;
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
        public ObservableCollection<targetViewModel> PriorityTargets { get; private set; }
        List<Target> list { get; set; }




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
        private void killButtons()
        {
            Thread workerThread2 = new Thread(killTargets);
            //Thread workerThread3 = new Thread(killFoes);
            //Thread workerThread4 = new Thread(killFriends);
        }

        public void clearTargets()
        {
           Targets.Clear();
           PriorityTargets.Clear();
           Targets = new ObservableCollection<targetViewModel>();
           PriorityTargets = new ObservableCollection<targetViewModel>();
           list.Clear();
           list = new List<Target>();
           TargetManager.TotalTargets = 0;
           //targetPriorityQueue = null;
           targetPriorityQueue = new PriorityQueue<Target>();
           targets = null;
           calculateScore();
           OnPropertyChanged("targets");
           OnPropertyChanged("Targets");
           OnPropertyChanged("PriorityTargets");
        }
        public async void killBlinkingAll()
        {
            int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            
            while (newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() =>
                    {
                        try
                        {   
                            Targets.ElementAt(i).KillAllBlinking();

                            mainViewMissile = NewOne.returnLauncher();
                            //mainViewMissile.Reset();
                            i++;

                            if (i >= 4)
                                i = 0;
                        }
                        catch { }
                    });
                await killEmAll;
            }
        }
        public async void killAllBlinkingEnemies()
        {
            int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;

            while (newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() =>
                {
                    try
                    {
                        Targets.ElementAt(i).KillBlinkingEnemies();

                        mainViewMissile = NewOne.returnLauncher();
                        //mainViewMissile.Reset();
                        i++;

                        if (i >= 4)
                            i = 0;
                    }
                    catch { }
                });
                await killEmAll;
            }
        }
        public async void killTargets()
        {
            int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            
            while (newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() =>
                    {
                        try
                        {   
                            Targets.ElementAt(i).KillAllTargets();

                            mainViewMissile = NewOne.returnLauncher();
                            //mainViewMissile.Reset();
                            i++;

                            if (i >= 4)
                                i = 0;
                        }
                        catch { }
                    });
                await killEmAll;
            }
            
        }

        public async void killAllFoes()
        {
             int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            
            while (newVars.missileCount > 0)
            {
                Task killAllBadGuys = Task.Run(() =>
                    {
                        try
                        {   
                            Targets.ElementAt(i).KillFoes();

                            mainViewMissile = NewOne.returnLauncher();
                            //mainViewMissile.Reset();
                            i++;

                            if (i >= 4)
                                i = 0;
                        }
                        catch { }
                    });
                await killAllBadGuys;           
            }

        }
        public async void killAllFriends()
        {

         int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;

            while (newVars.missileCount > 0)
            {
                Task killAllFriends = Task.Run(() =>
                    {
                        try
                        {
                            Targets.ElementAt(i).KillFriends();

                            mainViewMissile = NewOne.returnLauncher();
                            //mainViewMissile.Reset();
                            i++;
                            
                            if (i >= 4)
                                i = 0;
                        }
                        catch { }
                    });
                await killAllFriends;
            }
        }

     
        public async void killTargetsLeftToRight()
        {
            int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            mainViewMissile = NewOne.returnLauncher();

            while (/*i < TargetManager.TotalTargets &&*/ newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() => {
                    
                    PriorityTargets.ElementAt(i).KillAllTargets();
                    
                    i++;

                    if (newVars.missileCount == 0)//i == TargetManager.TotalTargets - 1)
                    {
                        
                     //  mainViewMissile.Reset();
                      // mainViewMissile.Move(-15, 0); //other code needs a +15
                        //mainViewMissile.Reset();
                        // newVars.missileCount = 4;
                    }
            }    
                );
                await killEmAll;
            }

        }

        public async void killTargetQueueListBackwards()
        {
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            mainViewMissile = NewOne.returnLauncher();

            //List<Target> reverseList = new List<Target>();

            myCollection collection = new myCollection();

            for (int j = 0; j < TargetManager.TotalTargets; j++)
            {
                collection[j] = PriorityTargets.ElementAt(j);
            }

            Iterator myIterator = new Iterator(collection);
            targetViewModel last;
            last = (targetViewModel)myIterator.Last();

            while (last != null && newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() =>
                {                    
                    
                   last.KillAllTargets();
                   last = (targetViewModel)myIterator.Previous();
                  
                    if (newVars.missileCount == 0)//i == TargetManager.TotalTargets - 1)
                    {

                        mainViewMissile.Reset();
                        mainViewMissile.Move(-15, 0); //other code needs a +15                     
                    }
                }
                );
                await killEmAll;
            }
        }


        private double score { get; set; }
        public double THE_SCORE
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged();
            }
        }
        public void calculateScore()
        {
            int i = 0;
            while(i < TargetManager.TotalTargets)
            {
                score += Targets.ElementAt(i).getScore();
            }
            OnPropertyChanged("score");
            OnPropertyChanged("THE_SCORE");
        }
        public async void killTargetsLeftToRightWithHitCount()
        {
            int i = 0;
            int queueCount = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            mainViewMissile = NewOne.returnLauncher();

            PriorityQueue<Target> priorityqueue = new PriorityQueue<Target>();
            priorityqueue = targetPriorityQueue;

            List<Target> priorityList = new List<Target>();
            priorityList = list;

            ObservableCollection<targetViewModel> viewModels = new ObservableCollection<targetViewModel>();
            viewModels = PriorityTargets;

            int hitCount = 0;
            while (i < priorityqueue.Count() && newVars.missileCount > 0)//TargetManager.TotalTargets && newVars.missileCount > 0)
            {
                
                Task killEmAll = Task.Run(() =>
                {
                    hitCount = priorityList.ElementAt(i).hit;
                    viewModels.ElementAt(i).KillAllTargets();

                    if(priorityList.ElementAt(i).hit > hitCount) //hit it?
                    {
                        priorityqueue.RemoveItem();
                        priorityList = priorityqueue.getPriorityList();

                        queueCount = 0;
                        while (queueCount < priorityqueue.Count())
                        {
                            var newtargetViewModel = new targetViewModel(priorityList[queueCount]);
                            viewModels.Add(newtargetViewModel);
                            queueCount++;
                        }
                    }


                    i++;

                    if (newVars.missileCount == 0)//i == TargetManager.TotalTargets - 1)
                    {                     
                        mainViewMissile.Move(-15, 0); //other code needs a +15    
                    }                   
                }
                );
                await killEmAll;
            }
        }

        public async void killTargetsWithPriorityQueue()
        {
            int i = 0;
            launcherViewModel NewOne = launcherViewModel.getInstance();
            launcherVars newVars = launcherVars.Instance;
            mainViewMissile = NewOne.returnLauncher();

            while (i < TargetManager.TotalTargets && newVars.missileCount > 0)
            {
                Task killEmAll = Task.Run(() =>
                {

                    PriorityTargets.ElementAt(i).KillAllTargets();
                    i++;

                    targetPriorityQueue.RemoveItem();
                    list = targetPriorityQueue.getPriorityList();

                    PriorityTargets.Clear();
                    PriorityTargets = new ObservableCollection<targetViewModel>();

                    int queueCount = 0;
                    while (queueCount < targetPriorityQueue.Count())
                    {
                        var newtargetViewModel = new targetViewModel(list[queueCount]);
                        PriorityTargets.Add(newtargetViewModel);
                        queueCount++;
                    }

                    if (newVars.missileCount == 0)
                    {
                        mainViewMissile.Move(-15, 0); //other code needs a +15
                    }
                }
                );
                await killEmAll;
            }

        }
      /*  private void liveLoadFile()
        {
            Thread workerThread = new Thread(loadINIFile);
            workerThread.Start();
        }*/

        public static IGameServer gameServer;

        public IList<string> gameList { get; set; }
        
        public string selectedGame { get; set; }


        //IEnumerable<string> gameList;
        public void loadFromServer()
        {
            launcherViewModel aLauncher = launcherViewModel.getInstance();
            string teamName = aLauncher.getName();
            var serverType = GameServerType.Mock;
            serverType = GameServerType.WebClient;
            gameServer = GameServerFactory.Create(serverType, teamName, IPAddress, Port);
            gameList = (IList<string>)gameServer.RetrieveGameList();
            OnPropertyChanged("gameList");

        }

        public void loadGameFromServer()
        {            
            IEnumerable<target> targets = gameServer.RetrieveTargetList(selectedGame);

            foreach (var target in targets)
            {
                Target aTarget = new Target();
                aTarget.name = target.name;
                aTarget.xCoord = target.x;
                aTarget.yCoord = target.y;
                aTarget.zCoord = target.z;

                if(target.status == 1)
                {
                    aTarget.friend = true;
                }
                else
                {
                    aTarget.friend = false;
                }

                aTarget.points = (int)target.points;
                aTarget.flashRate = (int)target.dutyCycle; //??
                aTarget.spawnRate = (int)target.spawnRate;
                aTarget.swapSides = target.canChangeSides;
                aTarget.alive = true; //??
                aTarget.score = target.score;
                aTarget.hit = target.hit;
                aTarget.isBlinking = target.movingState;

                var newtargetViewModel = new targetViewModel(aTarget);
                Targets.Add(newtargetViewModel);

                targetPriorityQueue.AddItem(aTarget);
                TargetManager.TotalTargets++;
            }

            List<Target> list = targetPriorityQueue.getPriorityList();

           int i = 0;
            while (i < TargetManager.TotalTargets)
            {
                var newtargetViewModel2 = new targetViewModel(list[i]);
                PriorityTargets.Add(newtargetViewModel2);
                i++;
            }
            OnPropertyChanged("Targets");
        }

        public void startServerGame()
        {
           gameServer.StartGame(selectedGame);

           if (selectedGame == "one")
               killTargets();
           else if (selectedGame == "two")
               killTargets();
           else if (selectedGame == "three")
               killTargets();
           else if (selectedGame == "four")
               killTargets();
           else if (selectedGame == "five")
               killTargets();
           else
               killTargets();
           //killTargets();
           //killTargetsLeftToRight();
                      
        }

        public void stopServerGame()
        {
            gameServer.StopRunningGame();
        }
        public void loadINIFile()
        {
            var openFileDialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            var worked = openFileDialog.ShowDialog();
            //Targets = new ObservableCollection<targetViewModel>();
            //TargetManager.TotalTargets = 0;

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
                 
                    //test of PriorityQueue
                    targetPriorityQueue.AddItem(targets[i]);

                    i++;
                }

                /*List<Target>*/ list = targetPriorityQueue.getPriorityList();

                i = 0;
                while (i < TargetManager.TotalTargets)
                {
                    var newtargetViewModel2 = new targetViewModel(list[i]);
                    PriorityTargets.Add(newtargetViewModel2);
                    i++;
                }

                OnPropertyChanged("Targets");
                OnPropertyChanged("PriorityTargets");
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

    



