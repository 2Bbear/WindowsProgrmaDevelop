using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTutorials0218.RoutedEvents
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = "Button is Clicked";
            //e.Handled = true;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Click event is bubbled to Stack Panel";
            
        }
        //최근에 바뀐 걸까. 윈도우 클릭은 라우트 되지 않는 것 같다.
        private void Window_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Click event is bubbled to Window";
        }
    }
}
