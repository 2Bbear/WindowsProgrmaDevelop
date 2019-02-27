using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Xpf.Core;
using EasyHandleDevExProject.Views;

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
            
        }
        //시작 윈도우 설정
        protected virtual void ShowMainWindow()
        {
            //App.Current.MainWindow = new MainWindow();
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
