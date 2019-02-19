using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Regions.Views;
using System.Windows;
using System.Windows.Controls;

namespace Regions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            System.Console.WriteLine("JJH:  App CreateShell");
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            System.Console.WriteLine("JJH:  App RegisterTypes");
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            System.Console.WriteLine("JJH:  App ConfigureRegionAdapterMappings");
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            System.Console.WriteLine("JJH:  App ConfigureRegionAdapterMappings end");
        }
    }
}
