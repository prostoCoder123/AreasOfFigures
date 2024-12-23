namespace FiguresTests;

internal static class Helper
{
    public static double GetCircleArea(double radius) => Math.PI * radius * radius;

    public static double GetTriangleArea(double x, double y, double z)
    {
        double half_perimeter = 0.5 * (x + y + z);

        return Math.Sqrt(
                    half_perimeter *
                    (half_perimeter - x) *
                    (half_perimeter - y) *
                    (half_perimeter - z)
               );
    }
}
