using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int GetHashCode([DisallowNull] object obj)
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
