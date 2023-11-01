using MindboxTestTaskLibrary.Base;

namespace MindboxTestTaskLibrary.Shapes
{
    public class Triangle : BaseShape
    {
        public readonly double[] Sides;

        public Triangle(double firstSide, double secondSide, double thirdSide) : base
        (
            Math.Sqrt((firstSide + secondSide + thirdSide) / 2 *
            ((firstSide + secondSide + thirdSide) / 2 - firstSide) *
            ((firstSide + secondSide + thirdSide) / 2 - secondSide) *
            ((firstSide + secondSide + thirdSide) / 2 - thirdSide))
        )
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
                throw new ArgumentException("Provided side length is not a positive double");
            else if (firstSide + secondSide < thirdSide || secondSide + thirdSide < firstSide || firstSide + thirdSide < secondSide)
                throw new ArgumentException("Provided sides do not form a triangle");

            Sides = new double[3] { firstSide, secondSide, thirdSide };
        }

        public bool IsRight()
        {
            Array.Sort(Sides);

            return Math.Pow(Sides[2], 2) ==
                Math.Pow(Sides[0], 2) +
                Math.Pow(Sides[1], 2)
                ? true : false;
        }
    }
}