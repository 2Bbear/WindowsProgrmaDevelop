﻿
using System.Windows;
using DevExpress.Mvvm.ModuleInjection;



using HowToDevExpress0225.Common;
using AppModules = HowToDevExpress0225.Common.Modules;
using HowToDevExpress0225.Views;

using System.ComponentModel;
using CLM.Views;
using CLM.ViewModels;

using SAM.Views;
using SAM.ViewModels;

using RibbonArea.Views;
using RibbonArea.ViewModels;

using TopReportArea.Views;
using TopReportArea.ViewModels;


namespace HowToDevExpress0225
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
        //
    
        //
       
       
        protected virtual void RegisterModules()
        {
            //Manager.Register(Regions.MainWindow, new Module(AppModules.Main, MainWindowViewModel.Create, typeof(MainWindow)));
            //Module
            Manager.Register(Regions.CLMView, new Module(AppModules.CLM, CLMViewModel.Create, typeof(CLMView)));
            Manager.Register(Regions.SAMView, new Module(AppModules.SAM, SAMViewModel.Create, typeof(SAMView)));

            //Resion================================================================

            //RibbonArea
            Manager.Register(Regions.RibbonArea, new Module(AppModules.Ribbon, RibbonAreaViewModel.Create, typeof(RibbonAreaView_Blue)));

            //TreeArea
            Manager.Register(Regions.TreeArea, new Module(AppModules.Report1, () => TreeArea.ViewModels.TreeAreaViewModel.Create("TestTree1", "TestTop1 Content"), typeof(TreeArea.Views.TreeAreaView)));
            Manager.Register(Regions.TreeArea, new Module(AppModules.Report2, () => TreeArea.ViewModels.TreeAreaViewModel.Create("TestTree2ddddddddddddddddddd", "TestTop2 Content"), typeof(TreeArea.Views.TreeAreaView)));
           
            //TopReportArea
            Manager.Register(Regions.TopReportArea, new Module(AppModules.Report1, () => TopReportAreaViewModel.Create("TestTop1", "TestTop1 Content"), typeof(TopReportAreaView)));
            Manager.Register(Regions.TopReportArea, new Module(AppModules.Report2, () => TopReportAreaViewModel.Create("TestTop2", "TestTop2 Content"), typeof(TopReportAreaView)));

            //BottomReportArea
            Manager.Register(Regions.BottomReportArea, new Module(AppModules.Report1, () => BottomArea.ViewModels.BottomAreaViewModel.Create("TestTree1", "TestTop1 Content"), typeof(BottomArea.Views.BottomAreaView)));
            Manager.Register(Regions.BottomReportArea, new Module(AppModules.Report2, () => BottomArea.ViewModels.BottomAreaViewModel.Create("TestTree2", "TestTop2 Content"), typeof(BottomArea.Views.BottomAreaView)));

            //=======================================================================

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
            //Manager.Inject(Regions.MainWindow, AppModules.Main);
            Manager.Inject(Regions.CLMView, AppModules.CLM);
            Manager.Inject(Regions.SAMView, AppModules.SAM);

            //Region=====================================================
            Manager.Inject(Regions.RibbonArea, AppModules.Ribbon);
           
            //===========================================================
        }
        //시작 윈도우 설정
        protected virtual void ShowMainWindow()
        {
            //App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow = new SeparatedWindowView();
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
