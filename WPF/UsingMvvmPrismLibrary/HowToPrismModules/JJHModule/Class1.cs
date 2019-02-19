using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
namespace JJHModule
{
    public class Class1 : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<RegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion",typeof(Views.ViewA));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
