using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFTutorials0218.Exceptions
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ReadFile(0);
        }

        void ReadFile(int index)
        {
            string path = @"D:\Test.txt";
            StreamReader file = null;

            try
            {
                file = new StreamReader(path);
                char[] buffer = new char[80];

                file.ReadBlock(buffer, index, buffer.Length);
                string str = new string(buffer);
                str.Trim();
                textBox.Text = str;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading from " + path + "\nMessage = " + e.Message);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
    }
}
