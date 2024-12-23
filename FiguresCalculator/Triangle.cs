using FiguresTests;

namespace FiguresCalculator;

public class Triangle : FigureBase<Triangle>, IFigureOperations
{
    public override FigureType FigureType => FigureType.Triangle;
    public IReadOnlyList<double> Sides { get; init; } = new List<double> { }.AsReadOnly();

    public const double MaxSide = Double.MaxValue * 0.2;

    private readonly double _p;
    private readonly double _area;

    private Triangle() { }

    public Triangle(double x, double y, double z)
    {
        var array = new[] { x, y, z };

        if(array.Any(x => x <= 0 || x >= MaxSide)) 
        {
            throw new ArgumentException($"The sides values must be in range ({0}, {MaxSide})");
        }

        if (x + y <= z || x + z <= y || y + z <= x)
        {
            throw new InvalidOperationException($"The sides values {x}, {y}, {z} can not form a triangle");
        }

        Sides = array.OrderBy(x => x).ToList().AsReadOnly();
        _p = Sides.Sum();

        var half_p = _p * 0.5;
        _area = Math.Sqrt(half_p * Sides.Select(x => half_p - x).Aggregate((x, y) => x * y));
    }
    public double GetArea() => _area;
    public double GetPerimeter() => _p;

    public bool IsRight()
    {
        var max = Sides.Max(); // Sides[2]

        // check the Pythagorean theorem
        return max * max == Sides.Take(Sides.Count - 1).Select(x => x * x).Sum();
    }

    public override bool Equals(Triangle? other) => Sides.ToHashSet().SetEquals(other?.Sides ?? Enumerable.Empty<double>());

    public override string ToString() => $"{FigureType.Value}: sides = {string.Join(", ", Sides)}";
}
