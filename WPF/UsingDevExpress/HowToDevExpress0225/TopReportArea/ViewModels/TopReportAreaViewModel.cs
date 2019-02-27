
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;

namespace TopReportArea.ViewModels
{
    public class TopReportAreaViewModel :BindableBase, ITopReportAreaModule, ISupportState<TopReportAreaViewModel.Info>
    {
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }
        public static TopReportAreaViewModel Create()
        {
            return ViewModelSource.Create(() => new TopReportAreaViewModel());
        }
        public static TopReportAreaViewModel Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new TopReportAreaViewModel()
            {
                Caption = caption,
                Content = content
            });
        }
        protected TopReportAreaViewModel() { }

        [Serializable]
        public class Info
        {
            public string Content { get; set; }
            public string Caption { get; set; }
        }
        Info ISupportState<Info>.SaveState()
        {
            return new Info()
            {
                Content = this.Content,
                Caption = this.Caption,
            };
        }
        void ISupportState<Info>.RestoreState(Info state)
        {
            this.Content = state.Content;
            this.Caption = state.Caption;
        }

        //
        

    }
}
