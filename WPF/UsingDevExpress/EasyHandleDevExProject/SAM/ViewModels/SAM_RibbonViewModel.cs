using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace SAM.ViewModels
{
    public class SAM_RibbonViewModel :BindableBase
    {
        public static SAM_RibbonViewModel Create()
        {
            return ViewModelSource.Create(() => new SAM_RibbonViewModel());
        }
    }
}
