using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD.core.Devices
{

    /// <summary>
    /// The Target Class
    /// </summary>
    public interface IMissileLauncher
    {
        public string launcherName;
        void Fire();
        void Move();
        void MoveBy();
        void Reload();
        void Kill();
        void Status();
     }

    public class MissileLauncherAdapter : IMissileLauncher
    {
        
    }



}
