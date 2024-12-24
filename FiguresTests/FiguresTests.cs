using FiguresCalculator;

namespace FiguresTests;

public class FiguresTests
{
    IReadOnlyList<Circle> _circles;
    IReadOnlyList<Triangle> _triangles;
    IReadOnlyList<IFigureOperations> Figures { get; set; }

    [SetUp]
    public void Setup()
    {
        _circles = new List<Circle>()
        {
            new Circle(5),
            new Circle(10e5),
            new Circle(1e-4)
        }.AsReadOnly();

        _triangles = new List<Triangle>()
        {
            new Triangle(20, 14, 7),
            new Triangle(7, 10, 5)
        }.AsReadOnly();

        var figures = new List<IFigureOperations>() { };
        figures.AddRange(_circles);
        figures.AddRange(_triangles);

        Figures = figures.AsReadOnly();
    }

    [Test]
    public void GetArea_OfCorrectFigures_ReturnsCorrectValues()
    {
        var circleAreas = _circles.Select(x => Helper.GetCircleArea(x.Radius));
        var triangleAreas = _triangles.Select(x => Helper.GetTriangleArea(x.Sides[0], x.Sides[1], x.Sides[2]));
        var expectedAreas = circleAreas.Union(triangleAreas);

        var areas = Figures.Select(x => x.GetArea());

        Assert.That(areas, Is.All.Not.Null);
        Assert.That(areas, Is.EquivalentTo(expectedAreas));
    }
}