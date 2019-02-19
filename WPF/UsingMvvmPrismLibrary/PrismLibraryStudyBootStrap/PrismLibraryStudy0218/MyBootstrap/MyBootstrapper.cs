using Prism.Unity;
using Unity;
using PrismLibraryStudy0218.Views;
using System.Windows;
using System.Diagnostics;
using CommonServiceLocator;

namespace PrismLibraryStudy0218.MyBootstrap
{
    class MyBootstrapper:UnityBootstrapper
    {
        /*
         Prism 응용프로그램의 최상위 윈도우를 지정할 수 있는 메소드
         쉘 클래스의 인스턴스를 반환하여 이 메소드를 구현해야한다.
         DependencyObject는 Window의 하위 클래스이기 때문에 윈도우를 반환 할 수 있다.
             */
        protected override DependencyObject CreateShell()
        {
            System.Console.WriteLine("JJH:  MyBootstrapper CreateShell");
            //여기서 Container 대신에 ServiceLocator를 사용 해도 무방하다
            /*
             ServiceLocator가 특정 의존성 주입 컨테이너를 대신해서 기능을 수행 할 수 있는데, 
             ServiceLocator는 컨테이너를 호출 함으로써 구현될 수 있다. 따라서
             컨테이너가 없는 코드를 만들기 위해서는 ServiceLocator를 사용하는 것이 좋은 선택이 될 수 있다.

             */
            return ServiceLocator.Current.GetInstance<MainWindow>();
            //return Container.Resolve<MainWindow>();
        }

        /*
         시작은 CreateShell이지만 내부적으로 Shell초기화 단계에서
         다른 Window화면으로 바꿔버릴 수 있다.

             */
        protected override void InitializeShell()
        {
            System.Console.WriteLine("JJH:  MyBootstrapper InitializeShell");
            Application.Current.MainWindow= ServiceLocator.Current.GetInstance<CustomWindow>();
            Application.Current.MainWindow.Show();
            System.Console.WriteLine("JJH:  MyBootstrapper InitializeShell end");
        }
    }
}
