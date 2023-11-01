namespace MindboxTestTaskLibrary.Base
{
    public abstract class BaseShape
    {
        private readonly double Square;
        public double GetSquare => Square;

        protected BaseShape(double square)
        {
            Square = square;
        }

        public string GetShapeSquareInfo()
        {
            return $"Square of {GetType().Name} = {Square}";
        }
    }
}