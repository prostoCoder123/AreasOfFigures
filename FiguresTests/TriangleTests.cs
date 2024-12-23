using FiguresCalculator;

namespace FiguresTests;

public class TriangleTests
{
    const double AlmostMaxSide = Triangle.MaxSide * 0.999;

    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1, 10, 12)]
    [TestCase(4, 12, 4)]
    [TestCase(10, 4, 3)]
    public void CreateTriangle_WithIncorrectSides_ThrowsException(double x, double y, double z)
    {
        TestDelegate CreateTriangle = () => new Triangle(x, y, z);

        Assert.Throws<InvalidOperationException>(CreateTriangle);
    }

    [TestCase(7, 10, 5)]
    [TestCase(5, 7, 11)] // 20, 9, 7
    [TestCase(AlmostMaxSide, AlmostMaxSide, AlmostMaxSide)]
    public void GetArea_OfCorrectTriangle_ReturnsCorrectValue(double x, double y, double z)
    {
        Triangle triangle = new(x, y, z);

        double area = triangle.GetArea();

        Assert.That(area, Is.EqualTo(Helper.GetTriangleArea(x, y, z)));
    }

    [Test]
    public void CreateTriangle_WithASideEqualsZero_ThrowsException()
    {
        TestDelegate CreateTriangle = () => new Triangle(default, 5, 7);
        TestDelegate CreateAnotherTriangle = () => new Triangle(1000, 53000, 0.0);

        Assert.Throws<ArgumentException>(CreateTriangle);
        Assert.Throws<ArgumentException>(CreateAnotherTriangle);
    }

    [TestCase(-0.009, 1.3434, 4.099)]
    [TestCase(-0.009, 1.3434, 4.099)]
    [TestCase(60.3434, -1.3434, 4.099)]
    [TestCase(60.3434, 19.3434, -4.099)]
    public void CreateTriangle_WithSideLessThanZero_ThrowsException(double x, double y, double z)
    {
        TestDelegate CreateTriangle = () => new Triangle(x, y, z);

        Assert.Throws<ArgumentException>(CreateTriangle);
    }

    [TestCase(Triangle.MaxSide, 8e35, 10e32)]
    [TestCase(14e28, 8e31, Triangle.MaxSide)]
    public void CreateTriangle_WithSideGreaterOrEqualThanMax_ThrowsException(double x, double y, double z)
    {
        TestDelegate CreateTriangle = () => new Triangle(x, y, z);

        Assert.Throws<ArgumentException>(CreateTriangle);
    }

    [TestCase(2e-2, 3e-2, 4e-2)]
    [TestCase(2e10, 3e10, 4e10)]
    [TestCase(AlmostMaxSide, AlmostMaxSide, AlmostMaxSide)]
    public void EqualTriangles_WithTheSameSides_ReturnsTrue(double x, double y, double z)
    {
        Triangle triangle1 = new(x, y, z);
        Triangle triangle2 = new(x, y, z);

        Assert.That(triangle1.Equals(triangle2), Is.True);
    }

    [TestCase(5, 10, 7)]
    [TestCase(15e10, 8e10, 9e10)]
    [TestCase(15e-3, 8e-3, 9e-3)]
    public void EqualTriangles_WithDifferentSides_ReturnsFalse(double x, double y, double z)
    {
        Triangle triangle1 = new(x, y, z);
        Triangle triangle2 = new(x - 1e-4, y - 2e-4, z - 3e-4);

        Assert.That(triangle1.Equals(triangle2), Is.False);
    }

    [TestCase(5, 8, 12)]
    [TestCase(5e10, 8e10, 12e10)]
    public void GetArea_OfTrianglesWithTheSameSides_ReturnsTheSameResults(double x, double y, double z)
    {
        Triangle triangle1 = new(x, y, z);
        Triangle triangle2 = new(x, y, z);

        double area1 = triangle1.GetArea();
        double area2 = triangle2.GetArea();

        Assert.That(area1, Is.EqualTo(area2));
    }

    [TestCase(24, 26, 10)]
    [TestCase(6, 8, 10)]
    public void IsRight_ForRightTriangles_ReturnsTrue(double x, double y, double z)
    {
        Triangle triangle = new(x, y, z);

        bool isRight = triangle.IsRight();

        Assert.That(isRight, Is.True);
    }

    [TestCase(4, 5, 2)]
    [TestCase(6, 18, 14)]
    public void IsRight_ForNotRightTriangles_ReturnsFalse(double x, double y, double z)
    {
        Triangle triangle = new(x, y, z);

        bool isRight = triangle.IsRight();

        Assert.That(isRight, Is.False);
    }
}
