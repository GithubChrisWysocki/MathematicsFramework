using System;
using System.Collections;
using System.Collections.Generic;
using MathematicsFramework.Settheory.ElementSet;

namespace MathematicsFramework.Settheory.Set
{
    public abstract class MathSet : SetMember
    {
        public object? this[int key]
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
        public IEqualityComparer Comparer { get; }
        public ArrayList innerMembers { get; }

        public MathSet()
        {
            Comparer = new DefaultComparer();
            innerMembers = new ArrayList();
        }

        public MathSet(IEqualityComparer comparer)
        {
            Comparer = comparer;
            innerMembers = new ArrayList();
        }

        public void AddMember(object setMember)
        {
            if (this == setMember)
                throw new ArgumentException("Member already exists in set and would be selfreferntial.");

            if (!ContainsMember(setMember))
                innerMembers.Add(setMember);
        }

        public bool ContainsMember(object memberToCheck)
        {
            foreach (var item in innerMembers)
                if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                    return true;
            return false;
        }
    }

    public abstract class MathSet<T> : SetMember where T : SetMember
    {
        public MathSet()
        {
            Comparer = new DefaultComparer<T>();
            innerMembers = new SetCollection(Comparer);
        }

        public MathSet(IEqualityComparer<T> comparer)
        {
            innerMembers = new SetCollection(comparer);
        }

        public class SetCollection : HashSet<T>
        {
            public SetCollection(IEqualityComparer<T> comparer) : base(comparer)
            {
            }
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

        public IEqualityComparer<T> Comparer { get; }


        public SetCollection innerMembers { get; }

        public bool ContainsMember(T memberToCheck, bool recursive = false)
        {
            //todo: das kann man parallelisieren
            if (recursive)
            {
                foreach (var item in innerMembers)
                {
                    if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return true;
                    if (item is MathSet<T> set)
                        if (set.ContainsMember(memberToCheck, true))
                            return true;
                }
            }
            else
                foreach (var item in innerMembers)
                    if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return true;

            return false;
        }

        public void AddMember(T setMember)
        {
            if (this == setMember)
                throw new ArgumentException("Member already exists in set and would be selfreferntial.");

            if (!ContainsMember(setMember))
                innerMembers.Add(setMember);
        }

        public void RemoveMember(T setMember)
        {
            if (ContainsMember(setMember))
                innerMembers.Remove(setMember);
        }
    }
}