using Prism.Ioc;
using Prism.Unity;

using CommonServiceLocator;
using PrismLibraryStudy_Regions.View;
using System.Windows;

namespace PrismLibraryStudy_Regions
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }
        
    }
}
