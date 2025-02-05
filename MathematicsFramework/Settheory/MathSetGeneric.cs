using Base;
using System;
using System.Collections.Generic;

namespace MathematicsFramework.Settheory
{
    public abstract class MathSetGeneric<T> : SetMember, ICompareable<T>, IMathSetGeneric<T> where T : SetMember, ICompareable
    {
        //todo: default constructor is bad idea for element construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer

        public MathSetGeneric()
        {
            innerMembers = new SetCollection<T>(Comparer);
        }

        //public MathSet(IEqualityComparer<T> comparer)
        //{
        //    Comparer = comparer;
        //    innerMembers = new SetCollection<T>(comparer);
        //}

        private IEqualityComparer<T> _comparer;
        public IEqualityComparer<T> Comparer
        {
            get
            {
                if (_comparer == null)
                    _comparer = new DefaultComparer<T>();
                return _comparer;
            }
            set { _comparer = value; }
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

        public SetCollection<T> innerMembers { get; }

        public (bool contains, T? innerMember) ContainsMember(T memberToCheck, bool recursive = false)
        {
            //todo: das kann man parallelisieren
            if (recursive)
                foreach (var item in innerMembers)
                {
                    if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true, item);

                    if (item is MathSetGeneric<T> set)
                    {
                        (bool contains, T innerMember) = set.ContainsMember(memberToCheck, recursive);
                        if (contains)
                            return (true, innerMember);
                    }
                }
            else
                foreach (var item in innerMembers)
                    if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true, item);

            return (false, null);
        }

        public void AddMember(T setMember)
        {
            if (setMember.Comparer.Equals(this,setMember))
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

    public abstract class MathSetGeneric<T, U> : SetMember, ICompareable<T>, IMathSetGeneric<T> where T : SetMember, ICompareable where U : IEqualityComparer<T>, new()
    {
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

        //todo: default constructor is bad idea for element construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer

        public MathSetGeneric()
        {
            innerMembers = new SetCollection<T>(Comparer);
        }

        //public MathSet(IEqualityComparer<T> comparer)
        //{
        //    Comparer = comparer;
        //    innerMembers = new SetCollection<T>(comparer);
        //}



        private IEqualityComparer<T> _comparer;
        public IEqualityComparer<T> Comparer
        {
            get
            {
                if (_comparer == null)
                    _comparer = new U();
                return _comparer;
            }
            set { _comparer = value; }
        }

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

                    if (item is MathSetGeneric<T, U> set)
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
                        return (true, item);

            return (false, null);
        }

        public void AddMember(T setMember)
        {
            if (setMember.Comparer.Equals(this, setMember))
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
