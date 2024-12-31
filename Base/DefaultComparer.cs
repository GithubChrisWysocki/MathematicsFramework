using KellermanSoftware.CompareNetObjects;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace MathematicsFramework.Settheory
{
    public class DefaultComparer : IEqualityComparer
    {
        protected CompareLogic comparer { get; }

        public DefaultComparer()
        {
            comparer = new CompareLogic();
        }

        public new bool Equals(object x, object y)
        {
            return comparer.Compare(x, y).AreEqual;
        }
        
        public int GetHashCode(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Use the default hash code if available
            return obj.GetHashCode();
        }
    }

    public class DefaultComparer<T> : DefaultComparer, IEqualityComparer<T>
    {
        public bool Equals(T? x, T? y)
        {
            return comparer.Compare(x, y).AreEqual;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            // Use the default hash code if available
            return obj.GetHashCode();
        }
    }
}
