using Prism.Unity;
using Unity;
using PrismLibraryStudy0218.Views;
using System.Windows;
using System.Diagnostics;

namespace PrismLibraryStudy0218.MyBootstrap
{
    class MyBootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            System.Console.WriteLine("JJH:  MyBootstrapper CreateShell");
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            System.Console.WriteLine("JJH:  MyBootstrapper InitializeShell");
            Application.Current.MainWindow.Show();
            System.Console.WriteLine("JJH:  MyBootstrapper InitializeShell end");
        }
    }
}
