using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.Core.Data;
using GUI;
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
using SAD.Core.Data;

namespace GUI
{
    /// <summary>
    /// Clear, Friend, Foe
    /// </summary>
    class targetViewModel 
    {
       public targetViewModel()
       {
           mainViewModel modelTarget = new mainViewModel();
           m_target = modelTarget.targets;
       }

       private Target[] m_target;
       
           
        
        
     }

}
