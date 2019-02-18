using Prism.Unity;
using Unity;
using PrismLibraryStudy0218.Views;
using System.Windows;

namespace PrismLibraryStudy0218.MyBootstrap
{
    class MyBootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
