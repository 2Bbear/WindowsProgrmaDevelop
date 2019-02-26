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
            RegisterModules();

            if (!RestoreState())
                InjectModules();

            ShowMainWindow();
        }
        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }
        protected virtual void RegisterModules()
        {
            Manager.Register(Regions.MainWindow, new Module(AppModules.Main, MainWindowViewModel.Create, typeof(MainWindow)));
            Manager.Register(Regions.CLMView, new Module(AppModules.CLM, CLMViewModel.Create, typeof(CLMView)));
            Manager.Register(Regions.SAMView, new Module(AppModules.SAM, SAMViewModel.Create, typeof(SAMView)));
            
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
            Manager.Inject(Regions.CLMView, AppModules.CLM);
            Manager.Inject(Regions.SAMView, AppModules.SAM);
     
        }
        protected virtual void ShowMainWindow()
        {
            App.Current.MainWindow = new MainWindow();
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
