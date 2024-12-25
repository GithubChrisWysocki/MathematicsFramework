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
        protected virtual ArrayList innerMembers { get; set; }
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
        public bool ContainsMember(object memberToCheck)
        {
            foreach (var item in GetAllMember())
            {
                if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                {
                    return true;
                }
            }
            return false;
        }
        public ArrayList GetAllMember() => innerMembers;
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
    public abstract class MathGenericSet<T> : MathGenericSet
    {
        public new IEqualityComparer<T> Comparer { get; set; }  
        public static MathGenericSet<SetMember> CreateSet<T>() where T : MathGenericSet<SetMember>, new()
        {
            return new T(); //(Set<SetMember>)Activator.CreateInstance(typeof(T));
        }
        private new SetCollection innerMembers { get; set; }
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
        public bool ContainsMember(T memberToCheck)
        {
            return innerMembers.Contains(memberToCheck);
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

        public void AddMember(T setMember)
        {
            innerMembers.Add(setMember);
        }
        public new SetCollection GetAllMember() => innerMembers;
    }
}
