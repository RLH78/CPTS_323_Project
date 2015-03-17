using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAD.core.Factories;
using SAD.core.Devices;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mock_Launcher_Checked(object sender, RoutedEventArgs e)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            IMissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.mock); 
        }

        private void Dream_Cheeky_Checked(object sender, RoutedEventArgs e)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            IMissileLauncher myLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC);
        }
        

    }
}
