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
using System.Windows.Shapes;
using SAD.core.Factories;
using SAD.core.Devices;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LauncherSelect.xaml
    /// </summary>
    public partial class LauncherSelect 
    {
        public LauncherSelect()
        {
            InitializeComponent();
            setToMock = 0;
            setToDC = 1;
        }

        private int launcherType { get; set; }
        public IMissileLauncher aLauncher { get; private set; }
        private int setToMock;
        private int setToDC;

        private void Mock_Launcher_Checked(object sender, RoutedEventArgs e)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            aLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.mock);
            if (Mock_Launcher.IsChecked == true)
            {
                MessageBox.Show("Mock Launcher created");
                launcherType = setToMock;
                MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();
            }
        }

        private void Dream_Cheeky_Checked(object sender, RoutedEventArgs e)
        {
            MissileLauncherFactory factory = new MissileLauncherFactory();
            aLauncher = factory.createMissileLauncher(SAD.core.Factories.launcherType.dreamC);
            if (Dream_Cheeky.IsChecked == true)
            {
                MessageBox.Show("Dream Cheeky created");
                launcherType = setToDC;
                MainWindow win2 = new MainWindow();
                win2.Show();
                this.Close();
            }
        }
    }
}
