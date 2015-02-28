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

        public static Target[] getInstance()
        {
            if (targetInstance == null)
            {
                targetInstance = new Target[50];
            }
            return targetInstance;
        }
    }
}
