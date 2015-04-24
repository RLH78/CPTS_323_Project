using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core.Annotation;
using System.Runtime.CompilerServices;
// stores information about target
namespace SAD.Core.Data
{
    public class Target : INotifyPropertyChanged
    {
        public Target()
        {
            this.name = "ERROR";
            this.xCoord = -99.0;
            this.yCoord = -99.0;
            this.zCoord = -99.0;
            this.friend = true;
            this.points = -99;
            this.flashRate = -99;
            this.spawnRate = -99;
            this.swapSides = true;
            this.alive = true;
        }
        // public int targetCount { get; set; }
        ~Target() { }

        public string name { get; set; }
        public double xCoord { get; set; }
        public double yCoord { get; set; }
        public double zCoord { get; set; }
        public bool friend { get; set; }
        public int points { get; set; }
        public int flashRate { get; set; }
        public int spawnRate { get; set; }
        public bool swapSides { get; set; }
        public bool alive
        {
            get { return m_isAlive; }
            set
            {
                m_isAlive = value;
                OnPropertyChanged("alive");
            }
        }

        private bool m_isAlive;


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
