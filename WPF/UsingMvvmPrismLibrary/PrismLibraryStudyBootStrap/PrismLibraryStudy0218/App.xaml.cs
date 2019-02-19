using PrismLibraryStudy0218.MyBootstrap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrismLibraryStudy0218
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            System.Console.WriteLine("JJH:  App OnStartup");
            base.OnStartup(e);

            var bootstrapper = new MyBootstrapper();
            bootstrapper.Run();
            System.Console.WriteLine("JJH:  App OnStartup end");
        }
    }
}
