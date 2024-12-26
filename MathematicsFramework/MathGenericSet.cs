using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MathematicsFramework
{
    public abstract class MathGenericSet : SetMember
    {
        public IEqualityComparer Comparer { get; set; }
        public virtual ArrayList innerMembers { get; set; }
        public MathGenericSet()
        {
            Comparer = new DefaultComparer();
            innerMembers = new ArrayList();
        }
        public MathGenericSet(IEqualityComparer comparer)
        {
            Comparer = comparer;
            innerMembers = new ArrayList();
        }
        public void AddMember(object setMember)
        {
            innerMembers.Add(setMember);
        }
        public virtual bool ContainsMember(object memberToCheck)
        {
            foreach (var item in innerMembers)
            {
                if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                {
                    return true;
                }
            }
            return false;
        }

        public class DefaultComparer : IEqualityComparer
        {
            public new bool Equals(object x, object y)
            {
                CompareLogic comparer = new CompareLogic();
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
    }
    public abstract class MathGenericSet<T> : MathGenericSet where T : SetMember
    {
        public new IEqualityComparer<T> Comparer { get; set; }

        // Gehört in SetFactory?!
        //public static MathGenericSet<SetMember> CreateSet<T>() where T : MathGenericSet<SetMember>, new()
        //{
        //    return new T(); //(Set<SetMember>)Activator.CreateInstance(typeof(T));
        //}
        public new SetCollection innerMembers { get; set; }
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
        public MathGenericSet()
        {
            Comparer = new DefaultComparer<T>();
            innerMembers = new SetCollection(Comparer);
        }
        public MathGenericSet(IEqualityComparer<T> comparer)
        {
            innerMembers = new SetCollection(comparer);
        }
        public T? this[int key]
        {
            get
            {
                int i = 0;
                foreach (var item in innerMembers)
                    if (key == i++)
                        return item;

                return default;
            }
        }
        public bool ContainsMember(T memberToCheck)
        {
            foreach (var item in innerMembers)
            {
                if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                {
                    return true;
                }
            }
            return false;
        }
        public void AddMember(T setMember)
        {
            if (!ContainsMember(setMember))
                innerMembers.Add(setMember);
            else
                throw new ArgumentException("Member already exists in set and would be selfreferntial.");
        }

    }
}
