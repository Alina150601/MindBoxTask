namespace MindBoxTask;

public class Triangle : IShape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;
    public double Square { get; }
    public double Perimeter { get; }
    public bool IsRight { get; }

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new InvalidShapeException("The sides of triangle must be greater that 0.");
        }

        _sideA = a;
        _sideB = b;
        _sideC = c;

        if (!DoesTriangleExist())
        {
            throw new InvalidShapeException("The triangle with given sides does not exist. " +
                                            "Rule: the sum of two side lengths of a triangle is always greater than the third side.");
        }

        Perimeter = a + b + c;
        var halfPerimeter = Perimeter / 2;
        Square = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
        IsRight = IsTriangleRight();
    }

    private bool IsTriangleRight()
    {
        var allSides = new List<double> { _sideA, _sideB, _sideC };
        var max = allSides.Max();
        allSides.Remove(max);
        var squareOfTheBiggestSide = Math.Pow(max, 2);
        var squareOfLowSides = Math.Pow(allSides[0], 2) + Math.Pow(allSides[1], 2);

        return squareOfTheBiggestSide - squareOfLowSides == 0;
    }

    private bool DoesTriangleExist()
    {
        var doesTriangleExist = _sideB + _sideC > _sideA &&
                                _sideA + _sideC > _sideB &&
                                _sideA + _sideB > _sideC;

        return doesTriangleExist;
    }
}