using MindBoxTask;
using Xunit;

namespace MindBoxTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(4, 50.26548245743669)]
        [InlineData(10, 314.15926535897933)]
        public void CircleSquare(int radius, double expectedSquare)
        {
            var circle = new Circle(radius);
            Assert.Equal(expectedSquare, circle.Square, 0.0001);
        }

        [Theory]
        [InlineData(-4)]
        [InlineData(0)]
        public void CircleSquareWithNegativeRadius(int radius)
        {
            Assert.Throws<InvalidShapeException>(() => new Circle(radius));
        }
    }
}