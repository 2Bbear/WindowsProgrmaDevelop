using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SDKSample
{
    public class ExampleClass:ContentControl
    {
        
        public ExampleClass()
        {

        }

        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);
        }
    }
}
