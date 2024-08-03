// See https://aka.ms/new-console-template for more information

using MindBoxTask;
using static System.Int32;

var a = new Circle(3);
var b = new Circle(5);

var figures = new List<IShape>();
figures.Add(a);
figures.Add(b);

foreach (var f in figures)
    Console.WriteLine(f.GetFigureSquare());

Console.WriteLine("Hello, World!");
Console.WriteLine("Operations list:");
Console.WriteLine("1. Triangle square");
Console.WriteLine("2. Circle square");
Console.WriteLine("3. Exit");
string? option;
do
{
    option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Console.WriteLine("Enter first triangle side:");
            TryParse(Console.ReadLine(), out var firstSide);
            Console.WriteLine("Enter second triangle side:");
            TryParse(Console.ReadLine(), out var secondSide);
            Console.WriteLine("Enter third triangle side:");
            TryParse(Console.ReadLine(), out var thirdSide);
            var result = SquareHelper.GetSquareOfTriangle(firstSide, secondSide, thirdSide);
            Console.WriteLine(result);
            break;
        case "2":
            Console.WriteLine("Enter first triangle side:");
            TryParse(Console.ReadLine(), out var radius);
            result = SquareHelper.GetSquareOfCircle(radius);
            Console.WriteLine(result);
            break;
        case "3": return;
    }
} while (option == "3");