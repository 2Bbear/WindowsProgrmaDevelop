
using Prism.Mvvm;
namespace ViewModelLocator.ViewModels
{
    class MyWindowViewModel: BindableBase
    {
        private string _title = "Prism Unity Applicationddd";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MyWindowViewModel()
        {

        }
    }
}
