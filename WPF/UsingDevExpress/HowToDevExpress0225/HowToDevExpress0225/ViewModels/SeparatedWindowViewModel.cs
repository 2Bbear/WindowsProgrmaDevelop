using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToDevExpress0225.ViewModels
{
    public class SeparatedWindowViewModel
    {
        public static SeparatedWindowViewModel Create()
        {
            return ViewModelSource.Create(() => new SeparatedWindowViewModel());
        }
    }
}
