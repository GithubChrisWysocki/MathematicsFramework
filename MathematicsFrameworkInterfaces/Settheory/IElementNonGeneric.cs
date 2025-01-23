using System.Collections;

namespace MathematicsFramework.Settheory;

public interface IElementNonGeneric:ICompareable
{
     object Value { get; }

     IEqualityComparer Comparer { get; }
}