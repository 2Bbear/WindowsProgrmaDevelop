using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;


namespace TreeArea.ViewModels
{
    public class TreeAreaViewModel: BindableBase
    {
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }
        public static TreeAreaViewModel Create()
        {
            return ViewModelSource.Create(() => new TreeAreaViewModel());
        }
        public static TreeAreaViewModel Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new TreeAreaViewModel()
            {
                Caption = caption,
                Content = content
            });
        }
        protected TreeAreaViewModel() { }
    }
}
