using DevExpress.Mvvm;
using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Mvvm.POCO;
using EasyHandleDevExProject.Config;
using System.Windows.Input;

namespace TEST.ViewModels
{
    public class TEST_ButtonViewModel:ViewModelBase
    {
        

        public static TEST_ButtonViewModel Create()
        {
            return ViewModelSource.Create(()=>new TEST_ButtonViewModel());
        }

        public TEST_ButtonViewModel()
        {
            DelegateProcess();
        }

        private void DelegateProcess()
        {
            Command_CallCLM = new DelegateCommand(CallCLM, CanCallCLM);
       
            Command_CallSAM = new DelegateCommand(CallSAM, CanCallSAM);

            Command_CallSET = new DelegateCommand(CallSET, CanCallSET);
        }

        public ICommand Command_CallCLM { get; private set; }
        private void CallCLM()
        {
           
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.RibbonRegion, Modules.CLMModule);
            


        }
        public bool CanCallCLM()
        {
            return true;
        }

        public ICommand Command_CallSAM { get; private set; }
        private void CallSAM()
        {
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.RibbonRegion, Modules.SAMModule);
        }
        public bool CanCallSAM()
        {
            return true;
        }

        public ICommand Command_CallSET { get; private set; }
        private void CallSET()
        {
            ModuleManager.DefaultManager.InjectOrNavigate(Regions.RibbonRegion, Modules.CLMModule2);
        }
        public bool CanCallSET()
        {
            return true;
        }

    }
}
