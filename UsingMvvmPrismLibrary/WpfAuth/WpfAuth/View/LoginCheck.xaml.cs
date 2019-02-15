using System.Windows.Controls;
using WpfAuth.ViewModel;
using Prism.Mvvm;
namespace WpfAuth.View
{
    /// <summary>
    /// LoginCheck.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginCheck : UserControl
    {
        public LoginCheck()
        {
            InitializeComponent();
            this.DataContext = new LoginCheckViewModel();
        }

    }
}
