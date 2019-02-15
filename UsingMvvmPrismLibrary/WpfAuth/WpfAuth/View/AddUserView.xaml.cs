using System.Windows.Controls;
using WpfAuth.ViewModel;

namespace WpfAuth.View
{
    /// <summary>
    /// AddUserView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddUserView : UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
            this.DataContext = new AddUserViewModel();
        }
    }
}
