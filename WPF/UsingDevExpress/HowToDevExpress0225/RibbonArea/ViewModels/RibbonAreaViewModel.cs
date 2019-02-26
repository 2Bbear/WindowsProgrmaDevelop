using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Input;

namespace RibbonArea.ViewModels
{
  
    public class RibbonAreaViewModel : ViewModelBase 
    {
        private string currentReport = HowToDevExpress0225.Common.Modules.Report1;
       
        public RibbonAreaViewModel()
        {
            Report1Command = new DelegateCommand(Report1, CanReport1);
            Report2Command = new DelegateCommand(Report2, CanReport2);
        }
        public static RibbonAreaViewModel Create()
        {
            return ViewModelSource.Create(() => new RibbonAreaViewModel());
        }

       
        //

        public ICommand Report1Command { get; private set; }
        public void Report1()
        {
            currentReport = HowToDevExpress0225.Common.Modules.Report1;
            
        }
        public bool CanReport1()
        {
            return true;
        }
        public ICommand Report2Command { get; private set; }
        public void Report2()
        {
            currentReport = HowToDevExpress0225.Common.Modules.Report2;
        }
        public bool CanReport2()
        {
            return true;
        }


    }
}
