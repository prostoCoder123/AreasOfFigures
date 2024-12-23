namespace FiguresCalculator;

public class FigureType
{
    private FigureType(string value) { Value = value; }

    public string Value { get; private set; }

    public static FigureType Circle => new FigureType("Circle");
    public static FigureType Triangle => new FigureType("Triangle");

    public override string ToString()
    {
        return Value;
    }
}
