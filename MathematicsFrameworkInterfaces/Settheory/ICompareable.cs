using System.Collections;

namespace MathematicsFramework.Settheory;

public interface ICompareable<T>
{
     IEqualityComparer<T>  Comparer { get; }
}
public interface ICompareable
{
    IEqualityComparer Comparer { get; }
}