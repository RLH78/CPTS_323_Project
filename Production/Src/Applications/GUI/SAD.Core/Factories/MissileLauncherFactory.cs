using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAD.core.Devices;

//Factory that creates Missile Launchers
namespace SAD.core.Factories
{


    /// <summary>
    /// concrete factory for missile launchers
    /// </summary>
    public class MissileLauncherFactory
    {
        public IMissileLauncher createMissileLauncher(launcherType myLauncherType)
        {
            IMissileLauncher myLauncher = null;

            switch (myLauncherType)
            {
                case launcherType.dreamC:
                    myLauncher = new DreamCheeky();
                    break;
                case launcherType.mock:
                    myLauncher = new Mock();
                    break;
                default:
                    Console.WriteLine("Oops. Tried to make a launcher type that doesn't exist");
                    break;
            }
            return myLauncher;
        }
    }

    public enum launcherType
    {
        dreamC,
        mock
    }
}
