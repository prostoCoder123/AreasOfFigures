using FiguresTests;

namespace FiguresCalculator;

public class Circle : FigureBase<Circle>, IFigureOperations
{
    public override FigureType FigureType => FigureType.Circle;
    public double Radius { get; init; }

    public const double MaxRadius = Double.MaxValue * 0.3;
    public Circle(double radius)
    {
        if (radius <= 0 || radius >= MaxRadius)
        {
            throw new ArgumentException($"The radius value must be in range (0, {MaxRadius})", nameof(radius));
        }

        Radius = radius;
    }

    public double GetArea() => Math.PI * Radius * Radius;
    public double GetPerimeter() => 2 * Math.PI * Radius;

    public override bool Equals(Circle? other) => Radius == other?.Radius;

    public override string ToString() => $"{FigureType.Value}: radius = {Radius}";
}