using MindboxTestTaskLibrary.Shapes;

namespace MindboxTestTaskLibrary.UnitTests
{
    public class TriangleTest
    {
        [Fact]
        public void CalculateTriangleSquare_Test()
        {
            // Arrange
            var hypothesisSquare = 84;

            // Act
            Triangle triangle = new Triangle(7, 24, 25);

            // Assert
            Assert.Equal(hypothesisSquare, triangle.GetSquare);
        }

        [Fact]
        public void IsTriangleRight_Test()
        {
            // Arrange
            var hypothesis = true;

            // Act
            Triangle triangle = new Triangle(7, 24, 25);
            var result = triangle.IsRight();

            // Assert
            Assert.Equal(hypothesis, result);
        }
    }
}