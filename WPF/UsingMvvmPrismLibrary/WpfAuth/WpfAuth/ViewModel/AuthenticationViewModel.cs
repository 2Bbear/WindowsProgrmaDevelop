using Prism.Mvvm;
using System;
using System.Threading;
using System.Windows.Controls;

namespace WpfAuth.ViewModel
{
    public interface IViewModel { }

    public class AuthenticationViewModel : BindableBase, IViewModel
    {


        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new DelegateCommand(Login, CanLogin);
        }

        public DelegateCommand LoginCommand { get { return _loginCommand; } }


        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            UserInfo user = _authenticationService.AuthenticateUser(Username, clearTextPassword);
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal == null)
                throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
            customPrincipal.Identity = new CustomIdentity(user.User_id, user.RoleId, user.DeptId);
            Username = string.Empty; //reset
            passwordBox.Password = string.Empty; //reset
        }

        private bool CanLogin(object parameter)
        {
            return true;
        }

        #region 변수 정의
        private readonly IAuthenticationService _authenticationService;
        private readonly DelegateCommand _loginCommand;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        #endregion
    }
}
