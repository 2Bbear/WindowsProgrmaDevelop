using DevExpress.Mvvm;
using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using HowToModule0225.Common;
using HowToModule0225.Main.Properties;
using HowToModule0225.Main.ViewModels;
using HowToModule0225.Main.Views;
using HowToModule0225.Modules.ViewModels;
using HowToModule0225.Modules.Views;
using System.ComponentModel;
using System.Windows;
using AppModules = HowToModule0225.Common.Modules;

namespace HowToModule0225.Main
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationThemeHelper.UpdateApplicationThemeName();
            new Bootstrapper().Run();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ApplicationThemeHelper.SaveApplicationThemeName();
            base.OnExit(e);
        }
    }
    public class Bootstrapper
    {
        const string StateVersion = "1.0";
        public virtual void Run()
        {
            ConfigureTypeLocators();
            RegisterModules();
            if (!RestoreState())
                InjectModules();
            ConfigureNavigation();
            ShowMainWindow();
        }

        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }
        protected virtual void ConfigureTypeLocators()
        {
            var mainAssembly = typeof(MainViewModel).Assembly;
            var modulesAssembly = typeof(ModuleViewModel).Assembly;
            var assemblies = new[] { mainAssembly, modulesAssembly };
            ViewModelLocator.Default = new ViewModelLocator(assemblies);
            ViewLocator.Default = new ViewLocator(assemblies);
        }
        protected virtual void RegisterModules()
        {
            Manager.Register(Regions.MainWindow, new Module(AppModules.Main, MainViewModel.Create, typeof(MainView)));
            Manager.Register(Regions.Navigation, new Module(AppModules.Module1, () => new NavigationItem("Module1")));
            Manager.Register(Regions.Navigation, new Module(AppModules.Module2, () => new NavigationItem("Module2")));
            Manager.Register(Regions.Documents, new Module(AppModules.Module1, () => ModuleViewModel.Create("Module1", "Module1 Content"), typeof(ModuleView)));
            Manager.Register(Regions.Documents, new Module(AppModules.Module2, () => ModuleViewModel.Create("Module2", "Module2 Content"), typeof(ModuleView)));
        }
        protected virtual bool RestoreState()
        {
#if !DEBUG
            if (Settings.Default.StateVersion != StateVersion) return false;
            return Manager.Restore(Settings.Default.LogicalState, Settings.Default.VisualState);
#else
            return false;
#endif
        }
        protected virtual void InjectModules()
        {
            Manager.Inject(Regions.MainWindow, AppModules.Main);
            Manager.Inject(Regions.Navigation, AppModules.Module1);
            Manager.Inject(Regions.Navigation, AppModules.Module2);
        }
        protected virtual void ConfigureNavigation()
        {
            Manager.GetEvents(Regions.Navigation).Navigation += OnNavigation;
            Manager.GetEvents(Regions.Documents).Navigation += OnDocumentsNavigation;
        }
        protected virtual void ShowMainWindow()
        {
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
            App.Current.MainWindow.Closing += OnClosing;
        }
        void OnNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NewViewModelKey == null) return;
            Manager.InjectOrNavigate(Regions.Documents, e.NewViewModelKey);
        }
        void OnDocumentsNavigation(object sender, NavigationEventArgs e)
        {
            Manager.Navigate(Regions.Navigation, e.NewViewModelKey);
        }
        void OnClosing(object sender, CancelEventArgs e)
        {
            string logicalState;
            string visualState;
            Manager.Save(out logicalState, out visualState);
            Settings.Default.StateVersion = StateVersion;
            Settings.Default.LogicalState = logicalState;
            Settings.Default.VisualState = visualState;
            Settings.Default.Save();
        }
    }
}