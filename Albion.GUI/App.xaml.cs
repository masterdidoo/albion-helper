using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Albion.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel _vm;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _vm = new MainViewModel();
            var v = new MainWindow(){DataContext = _vm};
            v.Show();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            _vm.Dispose();
        }
    }
}
