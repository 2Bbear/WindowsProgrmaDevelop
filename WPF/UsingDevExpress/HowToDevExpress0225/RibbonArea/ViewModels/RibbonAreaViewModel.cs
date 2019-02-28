using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ModuleInjection;
using System.Windows.Input;
using HowToDevExpress0225.Common;

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
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.TopReportArea, Modules.Report1);
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.TreeArea, Modules.Report1);
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.BottomReportArea, Modules.Report1);
        }
        public bool CanReport1()
        {
            return true;
        }
        public ICommand Report2Command { get; private set; }
        public void Report2()
        {
            currentReport = HowToDevExpress0225.Common.Modules.Report2;
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.TopReportArea, Modules.Report2);
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.TreeArea, Modules.Report2);
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.BottomReportArea, Modules.Report2);
        }
        public bool CanReport2()
        {
            return true;
        }


    }
}
