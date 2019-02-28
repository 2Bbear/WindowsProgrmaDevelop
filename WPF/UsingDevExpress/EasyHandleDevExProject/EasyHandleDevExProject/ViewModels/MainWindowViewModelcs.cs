
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;


namespace EasyHandleDevExProject.ViewModels
{
    public class MainWindowViewModelcs: ViewModelBase
    {
        public static MainWindowViewModelcs Create()
        {
            return ViewModelSource.Create(() => new MainWindowViewModelcs());
        }
        //생성자
        public MainWindowViewModelcs()
        {
          
           
        }
      
    }
}
