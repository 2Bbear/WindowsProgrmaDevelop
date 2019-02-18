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

namespace WPFTutorials0218.Inputs
{
    /// <summary>
    /// KeyBoardInput.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class KeyBoardInput : Window
    {
        public KeyBoardInput()
        {
            InitializeComponent();
        }
        //키보드의 컨트롤 + o 키를 눌르면 반응
        private void OnTextInputKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                handle();
                e.Handled = true;
            }

        }

        private void OnTextInputButtonClick(object sender, RoutedEventArgs e)
        {
            handle();
            e.Handled = true;
        }

        public void handle()
        {
            MessageBox.Show("Do you want to open a file?");
        }
    }
}
