using MindBoxTask;
using Xunit;

namespace MindBoxTests;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5, 3 * 4 * 0.5)]
    [InlineData(3 * 1.312, 4 * 1.312, 5 * 1.312, 3 * 1.312 * 4 * 1.312 * 0.5)]
    public void TriangleSquare(double sideA, double sideB, double sideC, double expectedSquare)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        Assert.Equal(expectedSquare, triangle.Square, 0.0001);
    }

    [Theory]
    [InlineData(2, -1, 2)]
    [InlineData(2, 1, 0)]
    public void TriangleWithNegativeSide(int sideA, int sideB, int sideC)
    {
        Assert.Throws<InvalidShapeException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Theory]
    [InlineData(100, 1, 2)]
    [InlineData(50, 25, 25)]
    public void CheckForNonExistedTriangle(int sideA, int sideB, int sideC)
    {
        Assert.Throws<InvalidShapeException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(2, 1, 2, false)]
    [InlineData(3, 4, 6, false)]
    public void IsTriangleRight(int sideA, int sideB, int sideC, bool expectedResult)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        Assert.Equal(expectedResult, triangle.IsRight);
    }
}