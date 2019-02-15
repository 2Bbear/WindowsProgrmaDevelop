using Microsoft.Practices.Unity;
using Prism.Mvvm;
using WpfAuth.ViewModel;

namespace WpfAuth
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            AddUserCommand = new DelegateCommand(OnUserAdd, CanExec);
            LoginCheckCommand = new DelegateCommand(OnLoginCheckCommand, CanExec);

            _addUserViewModel = ContainerHelper.Container.Resolve<AddUserViewModel>();
            _loginCheckViewModel = ContainerHelper.Container.Resolve<LoginCheckViewModel>();
        }

        private void OnLoginCheckCommand(object obj)
        {
            CurrentViewModel = _loginCheckViewModel;
        }

        private bool CanExec(object obj)
        {
            return true;
        }

        // 사용자 추가 ViewModel
        private AddUserViewModel _addUserViewModel;
        private LoginCheckViewModel _loginCheckViewModel;

        // 사용자 추가 버튼 처리
        public DelegateCommand AddUserCommand { get; private set; }
        public DelegateCommand LoginCheckCommand { get; private set; }

        // 사용자 추가 버튼을 클릭.
        private void OnUserAdd(object obj)
        {
            CurrentViewModel = _addUserViewModel;
        }

        private BindableBase _currentViewModel;

        // 현재 화면에 보여주어야 할 화면
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }
    }



}
