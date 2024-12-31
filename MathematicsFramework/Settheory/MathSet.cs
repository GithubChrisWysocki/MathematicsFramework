using System;
using System.Collections;
using System.Collections.Generic;
using Base;

namespace MathematicsFramework.Settheory
{
    public abstract class MathSet : SetMember,IMathSetNonGeneric,ICompareable
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

        //todo: default constructor is bad idea for set construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer
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

            if (!ContainsMember(setMember).contains)
                innerMembers.Add(setMember);
        }

        public void RemoveMember(object setMember)
        {
            (bool contains, object innerMember) = ContainsMember(setMember);
            if (contains)
                innerMembers.Remove(innerMember);
        }

        public (bool contains, object? innerMember) ContainsMember(object memberToCheck, bool recursive = false)
        {
            //todo: das kann man parallelisieren
            if (recursive)
            {
                foreach (var item in innerMembers)
                {
                    if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true, item);
                    if (item is MathSet set)
                    {
                        (bool contains, object innerMember) = set.ContainsMember(memberToCheck, true);
                        if (contains)
                            return (true, innerMember);
                    }
                }
            }
            else
                foreach (var item in innerMembers)
                    if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true,item);

            return (false,null);
        }
    }

    public abstract class MathSet<T> : SetMember,ICompareable<T>, IMathSetGeneric<T> where T : SetMember,ICompareable
    {
        //todo: default constructor is bad idea for element construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer

        public MathSet()
        {
            Comparer = new DefaultComparer<T>();
            innerMembers = new SetCollection<T>(Comparer);
        }

        public MathSet(IEqualityComparer<T> comparer)
        {
            Comparer = comparer;
            innerMembers = new SetCollection<T>(comparer);
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

        public SetCollection<T> innerMembers { get; }

        public (bool contains, T? innerMember) ContainsMember(T memberToCheck, bool recursive = false)
        {
            //todo: das kann man parallelisieren
            if (recursive)
            {
                foreach (var item in innerMembers)
                {
                    if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true, item);
                    if (item is MathSet<T> set)
                    {
                        (bool contains, T innerMember) = set.ContainsMember(memberToCheck, true);
                        if (contains)
                            return (true, innerMember);
                    }
                }
            }
            else
                foreach (var item in innerMembers)
                    if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true,item);

            return (false,null);
        }

        public void AddMember(T setMember)
        {
            if (this == setMember)
                throw new ArgumentException("Member already exists in set and would be selfreferntial.");

            if (!ContainsMember(setMember).contains)
                innerMembers.Add(setMember);
        }

        public void RemoveMember(T setMember)
        {
            (bool contains, T innerMember) = ContainsMember(setMember);
            if (contains)
                innerMembers.Remove(innerMember);
        }
    }
}