using DevExpress.Mvvm.POCO;

namespace HowToModule0225.Main.ViewModels
{
    public class MainViewModel
    {
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }
    }
}
