namespace MindBoxTask;

public class Circle: IShape
{
    public double Square { get; }
    public double Perimeter { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new InvalidShapeException("The radius of circle must be greater that 0.");
        }

        Square = Math.PI * Math.Pow(radius, 2);
        Perimeter = 2 * Math.PI * radius;
    }
}