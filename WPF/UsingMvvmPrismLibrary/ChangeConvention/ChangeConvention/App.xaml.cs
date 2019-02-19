using System.Windows;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using ChangeConvention.Views;
namespace ChangeConvention
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
