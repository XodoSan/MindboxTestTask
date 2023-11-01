using MindboxTestTaskLibrary.Base;

namespace MindboxTestTaskLibrary.Shapes
{
    public class Circle : BaseShape
    {
        public readonly double Radius;

        public Circle(double radius) : base(double.Pi * radius * radius)
        {
            if (radius <= 0.0)
            {
                throw new ArgumentException("Radius cannot be less than or equal to zero");
            }

            Radius = radius;
        }
    }
}