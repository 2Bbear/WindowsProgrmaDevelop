using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
            System.Console.WriteLine("JJH:  StackPanelRegionAdapter StackPanelRegionAdapter");
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            System.Console.WriteLine("JJH:  StackPanelRegionAdapter Adapt");
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                //handle remove
            };

            System.Console.WriteLine("JJH:  StackPanelRegionAdapter Adapt end");
        }

        protected override IRegion CreateRegion()
        {
            System.Console.WriteLine("JJH:  StackPanelRegionAdapter CreateRegion");
            return new AllActiveRegion();
        }
    }
}
