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

namespace Tutorial_0218
{
    /// <summary>
    /// MyStackpanel2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MyStackpanel2 : Window
    {
        public MyStackpanel2()
        {
            InitializeComponent();
            button001.Content = "button001 changed";

            //xaml을 거치지 않고 이벤트 바인딩
            button002.Click +=this.Button001_customClick;


        }
        //단순 자동 생성으로 메소드 바인딩을 하였을 경우
        private void Button001_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button001_Click ");
        }

        //커스텀 메소드 바인딩
        private void Button001_customClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button001_customClick ");
        }
    }
}
