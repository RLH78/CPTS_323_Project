using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core.Data;

// Singleton object that stores a list of targets and their status
namespace SAD.core.Data
{
    public class TargetManager
    {
        private static Target[] targetInstance;

        private TargetManager()
        {
            TotalTargets = 0;
            RemainingFriendTargets = 0;
            RemainingEnemyTargets = 0;
        }

        public static int TotalTargets { get; set; }

        public static int RemainingFriendTargets { get; set; }

        public static int RemainingEnemyTargets { get; set; }

        public static Target[] getInstance()
        {
            if (targetInstance == null)
            {
                targetInstance = new Target[25];
            }
            return targetInstance;
        }
        
        
    }
}
