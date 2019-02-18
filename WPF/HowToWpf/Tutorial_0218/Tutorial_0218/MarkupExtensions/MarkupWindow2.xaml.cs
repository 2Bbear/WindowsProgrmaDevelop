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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tutorial_0218.MarkupExtensions
{
    /// <summary>
    /// MarkupWindow2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MarkupWindow2 : Window
    {
        public MarkupWindow2()
        {
            InitializeComponent();
        }
    }

    public class MyMarkupExtension : MarkupExtension
    {
        public MyMarkupExtension() { }
        public String FirstStr { get; set; }
        public String SecondStr { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return FirstStr + "코드 수정이지롱" + SecondStr;
        }
    }
}
