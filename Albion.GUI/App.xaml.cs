using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Albion.GUI.ViewModels;
using NLog;

namespace Albion.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        private MainViewModel _vm;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _log.Info("Start");
            _vm = new MainViewModel();
            var v = new MainWindow(){DataContext = _vm};
            v.Show();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            _vm.Dispose();
            _log.Info("Stop");
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            _log.Error(e.Exception, "UnhandledException");
            e.Handled = true;
        }
    }
}
