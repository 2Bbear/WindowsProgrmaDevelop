using System;
using System.Windows;
using WpfAuth.View;
using WpfAuth.ViewModel;

namespace WpfAuth
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);
            AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService());
            IView loginWindow = new LoginWindow(viewModel);
            loginWindow.Show();
        }
    }
}
