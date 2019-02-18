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
    /// MyStackpanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MyStackpanel : Window
    {
        public MyStackpanel()
        {
            InitializeComponent();
            //전체 패널
            StackPanel stackPanel = new StackPanel();
            this.Content = stackPanel;
            //텍스트 블럭
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Welcome to XAML Tutorial this is changed";
            textBlock.Height = 20;
            textBlock.Width = 200;
            textBlock.Margin = new Thickness(5);
            stackPanel.Children.Add(textBlock);
            //버튼
            Button button = new Button();
            button.Content = "OK this is changed";
            button.Height = 20;
            button.Width = 50;
            button.Margin = new Thickness(20);
            stackPanel.Children.Add(button);
        }
    }
}
