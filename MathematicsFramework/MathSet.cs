using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MathematicsFramework
{
    public abstract class MathSet<T> : SetMember where T : SetMember
    {
        public static MathSet<SetMember> CreateSet<T>() where T : MathSet<SetMember>, new()
        {
            return new T(); //(Set<SetMember>)Activator.CreateInstance(typeof(T));
        }
        private SetCollection innerMembers;
        public class SetCollection : HashSet<T>
        {
            public SetCollection(IEqualityComparer<T> comparer) : base(comparer) { }

        }
        public class DefaultComparer<T> : IEqualityComparer<T>
        {
            public bool Equals(T? x, T? y)
            {
                CompareLogic comparer = new CompareLogic();
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
        public MathSet()
        {
            innerMembers = new SetCollection(new DefaultComparer<T>());
        }
        public MathSet(IEqualityComparer<T> comparer)
        {
            innerMembers = new SetCollection(comparer);
        }
        public bool ContainsMember(T memberToCheck)
        {
            return innerMembers.Contains(memberToCheck);
        }

        public SetMember? this[int key]
        {
            get
            {
                int i = 0;
                foreach (var item in innerMembers)
                    if (key == i++)
                        return item;

                return null;
            }
        }

        public void AddMember(T setMember)
        {
            innerMembers.Add(setMember);
        }
        public SetCollection GetAllMember() => innerMembers;
    }
}
