using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAD.core.Factories;
using SAD.core.Devices;

namespace GUI
{
    public class launcherViewModel : ViewModelBase
    {
        public launcherViewModel()
        {
            //
        }

        myServerMessage createDC;
        myServerMessage createMock;

        public ICommand _create_DC
        {
            get;
            set;
        }
    }



   
}
