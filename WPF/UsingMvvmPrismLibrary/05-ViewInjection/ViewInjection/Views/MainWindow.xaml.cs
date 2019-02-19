using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace ViewInjection.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
        }

        /*
         어차피 regionmanager에 등록하는 과정이다. 바로 registerviewwithregion으로 하나
         분리하여 등록 명 따로 붙일 view따로 하나 하는 행동은 같은 것이다.

             */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = _container.Resolve<ViewA>();
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            //IRegion region = _regionManager.Regions["ContentRegion"];
            //region.Add(view);
        }
    }
}
