using MindboxTestTaskLibrary.Shapes;

namespace MindboxTestTaskLibrary.UnitTests
{
    public class CircleTest
    {
        [Fact]
        public void CalculateSquare_Test()
        {
            // Arrange
            var hypothesisSquare = 314.1592653589793;

            // Act
            Circle circle = new Circle(10);

            // Assert
            Assert.Equal(hypothesisSquare, circle.GetSquare);
        }
    }
}