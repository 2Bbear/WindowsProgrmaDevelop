using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLM.ViewModels
{
    public class CLMViewModel
    {
        public static CLMViewModel Create()
        {
            return ViewModelSource.Create(() => new CLMViewModel());
        }
    }
}
