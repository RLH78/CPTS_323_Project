using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// stores information about target
namespace SAD.Core.Data
{
    public class Target
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
        public bool alive { get; set; }
        public string name { get; set; }
        public double xCoord { get; set; }
        public double yCoord { get; set; }
        public double zCoord { get; set; }
        public bool friend { get; set; }
        public int points { get; set; }
        public int flashRate { get; set; }
        public int spawnRate { get; set; }
        public bool swapSides { get; set; }
    }
}
