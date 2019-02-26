using DevExpress.Mvvm.POCO;


namespace SAM.ViewModels
{
    public class SAMViewModel
    {
        public static SAMViewModel Create()
        {
            return ViewModelSource.Create(() => new SAMViewModel());
        }
    }
}
