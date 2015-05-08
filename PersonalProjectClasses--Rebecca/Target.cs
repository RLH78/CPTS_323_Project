//Added a method to the Target class for personal project
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
    public class Target : INotifyPropertyChanged , IComparable<Target>
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
            this.score = 0.0;
            this.hit = 0;
            this.isBlinking = true;           
        }
        // public int targetCount { get; set; }
        
        
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

        public bool isBlinking { get; set; }

        public double score { get; set; }

        public int hit { get; set; }

       

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

        public int CompareTo(Target other)
        {
            double place_hold = 0;            
            double realPhi = 0;           
            int degrees = 0;
            int degrees2 = 0;
         

            //phi of current target
            place_hold = this.xCoord / this.yCoord;           
            realPhi = Math.Atan(place_hold);            
            degrees = Convert.ToInt32(realPhi * (180 / Math.PI));           

            //phi of other target
            place_hold = other.xCoord / other.yCoord;
            realPhi = Math.Atan(place_hold);
            degrees2 = Convert.ToInt32(realPhi * (180 / Math.PI));

            if (degrees < degrees2)
                return -1;

            else if (degrees > degrees2)
                return 1;

            else
                return 0;
        }
    }
}
