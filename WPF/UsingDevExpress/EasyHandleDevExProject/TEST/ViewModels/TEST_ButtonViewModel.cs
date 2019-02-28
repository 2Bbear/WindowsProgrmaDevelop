using DevExpress.Mvvm;
using DevExpress.Mvvm.ModuleInjection;
using DevExpress.Mvvm.POCO;
using EasyHandleDevExProject.Config;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using TEST.Models;

namespace TEST.ViewModels
{
    public class TEST_ButtonViewModel:ViewModelBase
    {
        public List<string> ComboBoxData { get; set; }//콤보박스 데이터용
        public string SelectedValue { get; set; } // 콤보박스 데이터용

        public DataController dataController; //Model에서 메소드를 불러오기 위한 객체

        public static TEST_ButtonViewModel Create()
        {
            return ViewModelSource.Create(()=>new TEST_ButtonViewModel());
        }

        public TEST_ButtonViewModel()
        {
            //객체 초기화
            dataController = new DataController();

            InitControll();

            DelegateProcess();
        }
        //컨트롤을 초기화 하는 메소드
        private void InitControll()
        {
            ComboBoxData = dataController.getManagerList();
            
        }
        //이벤트 처리용 딜리게이트를 처리하는 메소드
        private void DelegateProcess()
        {
            Command_CallCLM = new DelegateCommand(CallCLM, CanCallCLM);
       
            Command_CallSAM = new DelegateCommand(CallSAM, CanCallSAM);

            Command_CallSET = new DelegateCommand(CallSET, CanCallSET);

            Command_ComboSelecItem = new DelegateCommand(SelectChanged);
        }
        #region 딜리게이트

        public DelegateCommand Command_ComboSelecItem { get; private set; }
        private void SelectChanged()
        {

        }

        //버튼
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
        #endregion


    }
}
