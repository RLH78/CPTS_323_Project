using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            LauncherSelect myWindow = new LauncherSelect();
            myWindow.Top = 100;
            myWindow.Left = 400;
            myWindow.Show();
        }
    }
}
