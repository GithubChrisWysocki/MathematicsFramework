namespace MathematicsFramework.Settheory;

public interface IElementGeneric<T>:ICompareable<T>
{
    T? Value { get;  }

    IEqualityComparer<T> Comparer { get; }
}