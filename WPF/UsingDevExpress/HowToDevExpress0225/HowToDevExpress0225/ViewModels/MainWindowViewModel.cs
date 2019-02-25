using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToDevExpress0225.ViewModels
{
    class MainWindowViewModel
    {
        public static MainWindowViewModel Create()
        {
            return ViewModelSource.Create(() => new MainWindowViewModel());
        }
    }
}
