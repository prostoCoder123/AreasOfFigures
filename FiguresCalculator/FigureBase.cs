using FiguresCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresTests;

public abstract class FigureBase<T> : IEquatable<T> where T : class
{
    protected FigureBase() { }
    public virtual FigureType FigureType { get; } = default!;

    public virtual bool Equals(T? other) => throw new NotImplementedException();
}
