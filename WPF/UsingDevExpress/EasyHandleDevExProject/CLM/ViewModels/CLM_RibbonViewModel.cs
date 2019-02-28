using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;


namespace CLM.ViewModels
{
    public class CLM_RibbonViewModel :BindableBase
    {
        public string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }
        public static CLM_RibbonViewModel Create()
        {
            return ViewModelSource.Create(() => new CLM_RibbonViewModel()
            {
                Caption = "구매관리"
            }
            );
        }
        public static CLM_RibbonViewModel Create(string caption)
        {
            return ViewModelSource.Create(() => new CLM_RibbonViewModel()
            {
                Caption = caption
            }
            );
        }
        protected CLM_RibbonViewModel()
        {

        }
     


    }
}
