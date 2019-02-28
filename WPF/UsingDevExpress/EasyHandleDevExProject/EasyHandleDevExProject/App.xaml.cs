
using System.ComponentModel;

using System.Windows;
using DevExpress.Mvvm.ModuleInjection;

using EasyHandleDevExProject.Config;
using EasyHandleDevExProject.Views;



using AppModules = EasyHandleDevExProject.Config.Modules;
namespace EasyHandleDevExProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new Bootstrapper().Run();
        }
    }
    public class Bootstrapper
    {
        const string StateVersion = "1.0";


        public virtual void Run()
        {
            //ConfigureTypeLocators();
            RegisterModules();

            if (!RestoreState())
                InjectModules();

            //ConfigureRibbonModule();
            ShowMainWindow();
        }

        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }

        protected virtual void RegisterModules()
        {
            Manager.Register(Regions.TestRegion, new Module(AppModules.TESTModule, TEST.ViewModels.TEST_ButtonViewModel.Create, typeof(TEST.Views.TEST_ButtonView)));

            //Ribbon
            Manager.Register(Regions.RibbonRegion, new Module(AppModules.CLMModule, () => CLM.ViewModels.CLM_RibbonViewModel.Create("dddd"), typeof(CLM.Views.CLM_RibbonView)));
            Manager.Register(Regions.RibbonRegion, new Module(AppModules.CLMModule2, () => CLM.ViewModels.CLM_RibbonViewModel.Create("바낌"), typeof(CLM.Views.CLM_RibbonView)));

            Manager.Register(Regions.RibbonRegion, new Module(AppModules.SAMModule, SAM.ViewModels.SAM_RibbonViewModel.Create, typeof(SAM.Views.SAM_RibbonView)));
            
            //하나의 모델에 여러 매니저를 만들 수 있게 할것인가...
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
        //Manager의 각 Region들의 첫 모듈 주입?
        protected virtual void InjectModules()
        {
            Manager.Inject(Regions.TestRegion, AppModules.TESTModule);
        }
        //시작 윈도우 설정
        protected virtual void ShowMainWindow()
        {
            App.Current.MainWindow = new MainWindowView();
            App.Current.MainWindow.Show();
            
            App.Current.MainWindow.Closing += OnClosing;

        }
        void OnClosing(object sender, CancelEventArgs e)
        {
            string logicalState;
            string visualState;
            Manager.Save(out logicalState, out visualState);
        }
    }

}
