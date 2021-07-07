using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace FocusTest
{
    public class PointerTracker : Control
    {
        private Point lastPos;
        
        public override void Render(DrawingContext context)
        {
            base.Render(context);
            context.FillRectangle(Brushes.Transparent, Bounds, 0);
            context.FillRectangle(Brushes.Red, new Rect(lastPos.X-4, lastPos.Y-4,8,8), 8);
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            lastPos = e.GetPosition(this);
            InvalidateVisual();
        }
    }
}