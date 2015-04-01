using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mainViewModel modeltarget = new mainViewModel();
            m_target = modeltarget.targets;
            

            
        }

        private Target[] m_target;






    }
}
