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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTutorials0218.RoutedEvents
{
    /// <summary>
    /// MyCustomcontrol.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MyCustomcontrol : UserControl
    {
        static MyCustomcontrol()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomcontrol),
               new FrameworkPropertyMetadata(typeof(MyCustomcontrol)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //demo purpose only, check for previous instances and remove the handler first 
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null) 
                button.Click += Button_Click;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseClickEvent();
        }

        public static readonly RoutedEvent ClickEvent =
           EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
           typeof(RoutedEventHandler), typeof(MyCustomcontrol));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        protected virtual void RaiseClickEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(MyCustomcontrol.ClickEvent);
            RaiseEvent(args);
        }
    }
}
