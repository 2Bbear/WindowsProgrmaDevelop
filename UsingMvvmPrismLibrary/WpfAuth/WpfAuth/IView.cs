using WpfAuth.ViewModel;

namespace WpfAuth
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get; set;
        }

        void Show();
    }
}
