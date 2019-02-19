using System;
using Prism.Modularity;
using _07_HowToPrism_Modules.View;
using Prism.Unity;
using Prism.Ioc;
using System.Windows;

namespace _07_HowToPrism_Modules
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
