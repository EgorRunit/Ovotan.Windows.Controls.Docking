using System.Windows;

namespace System
{
    public class OwnerRect
    {
        public  double X, Y, Width, Height;
        public FrameworkElement Owner;
        public OwnerRect(FrameworkElement owner,  double left, double top, double width, double height)
        {
            X = left;
            Width = width;
            Y = top;
            Height = height;
            Owner = owner;
        }
    }

    public static class ElementRectangleExtension
    {
        public static OwnerRect FindElementFromPoint(this List<OwnerRect> elements , Point point)
        {

            foreach (OwnerRect rectangle in elements)
            {
                if(rectangle.X <= point.X &&  rectangle.Y <= point.Y && rectangle.Width>= point.X && rectangle.Height >= point.Y)
                {
                    return rectangle;
                }
            }
            return null;

        }


        public static Rect FindElementFromPoint(this List<Rect> elements, Point point)
        {

            foreach (var rectangle in elements)
            {
                if (rectangle.X <= point.X && rectangle.Y <= point.Y && rectangle.Width>= point.X && rectangle.Height >= point.Y)
                {
                    return rectangle;
                }
            }
            return Rect.Empty;

        }
    }
}
