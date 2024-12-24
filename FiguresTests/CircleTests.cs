using FiguresCalculator;

namespace FiguresTests;

public class CircleTests
{
    const double AlmostMaxRadius = Circle.MaxRadius * 0.999;

    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1.5)]
    [TestCase(0.5)]
    [TestCase(10000000)]
    [TestCase(3000)]
    [TestCase(0.0009)]
    [TestCase(13.232323)]
    [TestCase(13e-20)]
    [TestCase(AlmostMaxRadius)]
    public void GetArea_OfCorrectCircle_ReturnsCorrectValue(double radius)
    {
        Circle circle = new(radius);

        double area = circle.GetArea();

        Assert.That(area, Is.EqualTo(Helper.GetCircleArea(radius)));
    }

    [Test]
    public void CreateCircle_WithZeroRadius_ThrowsException()
    {
        TestDelegate CreateCircle = () => new Circle(default);

        ArgumentException ex = Assert.Throws<ArgumentException>(CreateCircle);
        Assert.That(ex.ParamName, Is.EqualTo("radius"));

        Assert.Throws<ArgumentException>(() => new Circle(0.0));
    }

    [TestCase(-0.09)]
    [TestCase(-100.988)]
    [TestCase(-0.0003)]
    [TestCase(-0.0)]
    public void CreateCircle_WithRadiusLessThanZero_ThrowsException(double radius)
    {
        TestDelegate CreateCircle = () => new Circle(radius);

        ArgumentException ex = Assert.Throws<ArgumentException>(CreateCircle);
        Assert.That(ex.ParamName, Is.EqualTo("radius"));
    }

    [Test]
    public void CreateCircle_WithRadiusGreaterOrEqualThanMax_ThrowsException()
    {
        TestDelegate CreateCircle = () => new Circle(Circle.MaxRadius);

        ArgumentException ex = Assert.Throws<ArgumentException>(CreateCircle);
        Assert.That(ex.ParamName, Is.EqualTo("radius"));
    }

    [TestCase(5)]
    [TestCase(100000000)]
    [TestCase(5e-17)]
    public void EqualCircles_WithTheSameRadius_ReturnsTrue(double radius)
    {
        Circle circle1 = new(radius);
        Circle circle2 = new(radius);

        Assert.That(circle1.Equals(circle2), Is.True);
    }

    [TestCase(5, 10)]
    [TestCase(100000000, 40000000)]
    [TestCase(5e-17, 5e-18)]
    public void EqualCircles_WithDifferentRadius_ReturnsFalse(double radius1, double radius2)
    {
        Circle circle1 = new(radius1);
        Circle circle2 = new(radius2);

        Assert.That(circle1.Equals(circle2), Is.False);
    }

    [TestCase(5)]
    [TestCase(100000000)]
    [TestCase(5e-17)]
    public void GetArea_OfCirclesWithTheSameRadius_ReturnsTheSameResults(double radius)
    {
        Circle circle1 = new(radius);
        Circle circle2 = new(radius);

        double area1 = circle1.GetArea();
        double area2 = circle2.GetArea();

        Assert.That(area1, Is.EqualTo(area2));
    }
}