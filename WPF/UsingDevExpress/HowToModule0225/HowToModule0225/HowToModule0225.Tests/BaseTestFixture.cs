using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Xpf.Core;
using HowToModule0225.Main;
using NUnit.Framework;
using System.Windows;

namespace HowToModule0225.Tests
{
    public abstract class BaseTestFixture
    {
        public IModuleManager Manager { get { return ModuleManager.DefaultManager; } }
        protected virtual bool IsFunctionalTesting { get { return false; } }
        TestBootstrapper bootstrapper;
        [SetUp]
        public void SetUp()
        {
            ModuleManager.DefaultManager = new ModuleManager(false, !IsFunctionalTesting);
            bootstrapper = new TestBootstrapper(IsFunctionalTesting);
            bootstrapper.Run();
        }
        [TearDown]
        public void TearDown()
        {
            ModuleManager.DefaultManager = null;
        }
        protected void DoEvents()
        {
            if (IsFunctionalTesting)
                DispatcherHelper.UpdateLayoutAndDoEvents(bootstrapper.MainWindow);
        }
    }
    public class TestBootstrapper : Bootstrapper
    {
        readonly bool showRealWindow;
        public Window MainWindow { get; private set; }
        public TestBootstrapper(bool showRealWindow)
        {
            this.showRealWindow = showRealWindow;
        }
        protected override void ShowMainWindow()
        {
            if (!showRealWindow) return;
            MainWindow = new MainWindow()
            {
                WindowStyle = WindowStyle.None,
                WindowState = WindowState.Normal,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowActivated = false,
                AllowsTransparency = true,
                Opacity = 0d,
                ShowInTaskbar = false,
            };
            MainWindow.Show();
        }
    }
}
