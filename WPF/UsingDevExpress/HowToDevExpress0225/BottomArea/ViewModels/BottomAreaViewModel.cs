using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottomArea.ViewModels
{
    public class BottomAreaViewModel
    {
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Content { get; set; }

        public static BottomAreaViewModel Create()
        {
            return ViewModelSource.Create(() => new BottomAreaViewModel());
        }
        public static BottomAreaViewModel Create(string caption, string content)
        {
            return ViewModelSource.Create(() => new BottomAreaViewModel()
            {
                Caption = caption,
                Content = content
            });
        }
        protected BottomAreaViewModel() { }
    }

    
}
