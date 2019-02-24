using Prism_LocalizationExample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Prism_LocalizationExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        
        App()
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture=
            //    new System.Globalization.CultureInfo("ko-KR");

          
            

        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
