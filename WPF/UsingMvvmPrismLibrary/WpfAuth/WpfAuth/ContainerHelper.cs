using Microsoft.Practices.Unity;

namespace WpfAuth
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
