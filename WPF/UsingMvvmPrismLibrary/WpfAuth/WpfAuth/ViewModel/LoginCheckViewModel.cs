using Prism.Mvvm;
using System.Threading;

namespace WpfAuth.ViewModel
{
    class LoginCheckViewModel : BindableBase
    {
        public LoginCheckViewModel()
        {
            this.UserId = Thread.CurrentPrincipal.Identity.Name;
            this.UserAuth = Thread.CurrentPrincipal.IsInRole("Admin") ? "Administrator" : "Normal";
        }
        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private string userAuth;

        public string UserAuth
        {
            get { return userAuth; }
            set { userAuth = value; }
        }

    }
}
