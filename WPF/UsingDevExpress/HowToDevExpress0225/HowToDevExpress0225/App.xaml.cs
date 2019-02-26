using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Mvvm.ModuleInjection;

using DevExpress.Xpf.Core;

using HowToDevExpress0225.Common;
using AppModules = HowToDevExpress0225.Common.Modules;
using HowToDevExpress0225.Views;
using HowToDevExpress0225.ViewModels;
using System.ComponentModel;
using CLM.Views;
using CLM.ViewModels;

using SAM.Views;
using SAM.ViewModels;

using RibbonArea.Views;
using RibbonArea.ViewModels;

using TopReportArea.Views;
using TopReportArea.ViewModels;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

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
            ConfigureTypeLocators();
            RegisterModules();

            if (!RestoreState())
                InjectModules();

            ConfigureRibbonModule();
            ShowMainWindow();
        }
        protected virtual void ConfigureTypeLocators()
        {
            var mainAssembly = typeof(MainWindowViewModel).Assembly;
            var modulesAssembly = typeof(MainWindowViewModel).Assembly;
            var assemblies = new[] { mainAssembly, modulesAssembly };
            ViewModelLocator.Default = new ViewModelLocator(assemblies);
            ViewLocator.Default = new ViewLocator(assemblies);
        }
        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }
        //
        protected virtual void ConfigureRibbonModule()
        {
            Manager.GetEvents(Regions.RibbonArea).Navigation += OnNavigation;
           
        }
        void OnNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NewViewModelKey == null) return;
            if (e.NewViewModelKey == "Ribbon") return;
            Manager.InjectOrNavigate(Regions.TopReportArea, e.NewViewModelKey);// e.NewViewModelKey
        }
        void OnDocumentsNavigation(object sender, NavigationEventArgs e)
        {
           
        }
        //
       
       
        protected virtual void RegisterModules()
        {
            //Manager.Register(Regions.MainWindow, new Module(AppModules.Main, MainWindowViewModel.Create, typeof(MainWindow)));
            //Module
            Manager.Register(Regions.CLMView, new Module(AppModules.CLM, CLMViewModel.Create, typeof(CLMView)));
            Manager.Register(Regions.SAMView, new Module(AppModules.SAM, SAMViewModel.Create, typeof(SAMView)));

            //Resion================================================================

            //RibbonArea
            Manager.Register(Regions.RibbonArea, new Module(AppModules.Ribbon, RibbonAreaViewModel.Create, typeof(RibbonAreaView)));

            //TreeArea

            //TopReportArea
               
            Manager.Register(Regions.TopReportArea, new Module(AppModules.Report1, () => TopReportAreaViewModel.Create("TestTop1", "TestTop1 Content"), typeof(TopReportAreaView)));
            Manager.Register(Regions.TopReportArea, new Module(AppModules.Report2, () => TopReportAreaViewModel.Create("TestTop2", "TestTop2 Content"), typeof(TopReportAreaView)));
            //BottomReportArea
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
