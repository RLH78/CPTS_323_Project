using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Factory that creates Missile Launchers
namespace SAD.core.Factories
{
    public abstract class MissileLauncher
    {
        public string launcherName
        {
            get;
            set;
        }
    }

    public sealed class DreamCheeky: MissileLauncher 
    {
        public DreamCheeky()
        {
            launcherName = "KillShotLauncher!";
        }
    }

    public sealed class Mock : MissileLauncher
    {
        public Mock()
        {
            launcherName = "Boring-Mock-Launcher";
        }
    }

    /// <summary>
    /// concrete factory for missile launchers
    /// </summary>
    public class MissileLauncherFactory
    {
        public MissileLauncher createMissileLauncher(launcherType myLauncherType)
        {
            MissileLauncher myLauncher = null;

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
