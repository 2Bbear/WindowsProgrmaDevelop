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
    /// MultiTouchInput.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MultiTouchInput : Window
    {
        public MultiTouchInput()
        {
            InitializeComponent();
        }

        void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
        }

        void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Rectangle rectToMove = e.OriginalSource as Rectangle;
            Matrix rectsMatrix = ((MatrixTransform)rectToMove.RenderTransform).Matrix;

            rectsMatrix.RotateAt(e.DeltaManipulation.Rotation, e.ManipulationOrigin.X, e.ManipulationOrigin.Y);

            rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.X,
               e.ManipulationOrigin.X, e.ManipulationOrigin.Y);

            rectsMatrix.Translate(e.DeltaManipulation.Translation.X,
               e.DeltaManipulation.Translation.Y);

            rectToMove.RenderTransform = new MatrixTransform(rectsMatrix);
            Rect containingRect = new Rect(((FrameworkElement)e.ManipulationContainer).RenderSize);

            Rect shapeBounds = rectToMove.RenderTransform.TransformBounds(new Rect(rectToMove.RenderSize));

            if (e.IsInertial && !containingRect.Contains(shapeBounds))
            {
                e.Complete();
            }

            e.Handled = true;
        }

        void Window_InertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0);
            e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);
            e.Handled = true;
        }
    }
}
