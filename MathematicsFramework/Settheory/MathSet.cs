using System;
using System.Collections;
using System.Collections.Generic;
using Base;

namespace MathematicsFramework.Settheory
{
    public abstract class MathSet : SetMember, IMathSetNonGeneric 
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

        private IEqualityComparer<object> _comparer;
        public IEqualityComparer<object> Comparer
        {
            get
            {
                if (_comparer == null)
                    _comparer = new DefaultComparer<object>();
                return _comparer;
            }
            set { _comparer = value; }
        }

        private SetCollection<object> _innerMembers;
        public SetCollection<object> innerMembers
        {
            get
            {
                if (_innerMembers == null)
                    _innerMembers = new SetCollection<object>(Comparer);
                return _innerMembers;
            }
        }


        public void AddMember(object setMember)
        {
            if (Comparer.Equals(this, setMember))
                throw new ArgumentException("Member already exists in set and would be selfreferential.");

            if (!ContainsMember(setMember).contains)
                innerMembers.Add(setMember);
        }

        public void RemoveMember(object setMember)
        {
            (bool contains, object innerMember) = ContainsMember(setMember);
            if (contains)
                innerMembers.Remove(innerMember);
        }
        /// <summary>
        /// recursive - checks each nested set also if it contains the member
        /// </summary>
        /// <param name="memberToCheck"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public (bool contains, object? innerMember)  ContainsMember(object memberToCheck, bool recursive = false)
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
                        return (true, item);

            return (false, null);
        }
    }
    public abstract class MathSet<T> : SetMember, IMathSetNonGeneric where T : IEqualityComparer<object>,new()
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

        private IEqualityComparer<object> _comparer;
        public IEqualityComparer<object> Comparer
        {
            get 
            { 
                if(_comparer == null)
                    _comparer = new T();
                return _comparer; 
            }
            set { _comparer = value; }
        }

        private SetCollection<object> _innerMembers;
        public  SetCollection<object> innerMembers
        {
            get 
            { 
                if (_innerMembers == null)
                    _innerMembers = new SetCollection<object>(Comparer);
                return _innerMembers; 
            }
        }


        public void AddMember(object setMember)
        {
            if (Comparer.Equals(this, setMember))
                throw new ArgumentException("Member already exists in set and would be selfreferential.");

            if (!ContainsMember(setMember).contains)
                innerMembers.Add(setMember);
        }

        public void RemoveMember(object setMember)
        {
            (bool contains, object innerMember) = ContainsMember(setMember);
            if (contains)
                innerMembers.Remove(innerMember);
        }
        /// <summary>
        /// recursive - checks each nested set also if it contains the member
        /// </summary>
        /// <param name="memberToCheck"></param>
        /// <param name="recursive"> checks each nested set also if it contains the member</param>
        /// <returns></returns>
        public (bool contains, object? innerMember) ContainsMember(object memberToCheck, bool recursive = false)
        {
            //todo: das kann man parallelisieren
            if (recursive)
            {
                foreach (var item in innerMembers)
                {
                    if (Comparer.Equals(item, memberToCheck)) // Prevent duplicates
                        return (true, item);
                    if (item is MathSet<T> set)
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
    //public abstract class MathSet<T,U> : SetMember, ICompareable<T>, IMathSetGeneric<T> where T : SetMember, ICompareable where U: IEqualityComparer<object>,new()
    //{
    //    public T? this[int key]
    //    {
    //        get
    //        {
    //            int i = 0;
    //            foreach (var item in innerMembers)
    //                if (key == i++)
    //                    return item;

    //            return default;
    //        }
    //    }

    //    //todo: default constructor is bad idea for element construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer

    //    public MathSet()
    //    {
    //         innerMembers = new SetCollection<T>(Comparer);
    //    }

    //    //public MathSet(IEqualityComparer<T> comparer)
    //    //{
    //    //    Comparer = comparer;
    //    //    innerMembers = new SetCollection<T>(comparer);
    //    //}

    //    private IEqualityComparer<T> _comparer;
    //    public IEqualityComparer<T> Comparer
    //    {
    //        get
    //        {
    //            if (_comparer == null)
    //                _comparer = new U();
    //            return _comparer;
    //        }
    //        set { _comparer = value; }
    //    }

    //    private SetCollection<object> _innerMembers;
    //    public SetCollection<object> innerMembers
    //    {
    //        get
    //        {
    //            if (_innerMembers == null)
    //                _innerMembers = new SetCollection<object>(Comparer);
    //            return _innerMembers;
    //        }
    //    }

    //    public SetCollection<T> innerMembers { get; }

    //    public (bool contains, T? innerMember) ContainsMember(T memberToCheck, bool recursive = false)
    //    {
    //        //todo: das kann man parallelisieren
    //        if (recursive)
    //        {
    //            foreach (var item in innerMembers)
    //            {
    //                if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
    //                    return (true, item);
    //                if (item is MathSet<T,U> set)
    //                {
    //                    (bool contains, T innerMember) = set.ContainsMember(memberToCheck, true);
    //                    if (contains)
    //                        return (true, innerMember);
    //                }
    //            }
    //        }
    //        else
    //            foreach (var item in innerMembers)
    //                if (item.Comparer.Equals(item, memberToCheck)) // Prevent duplicates
    //                    return (true,item);

    //        return (false,null);
    //    }

    //    public void AddMember(T setMember)
    //    {
    //        if (Comparer. .Equals(this, setMember))
    //            throw new ArgumentException("Member already exists in set and would be selfreferntial.");

    //        if (!ContainsMember(setMember).contains)
    //            innerMembers.Add(setMember);
    //    }

    //    public void RemoveMember(T setMember)
    //    {
    //        (bool contains, T innerMember) = ContainsMember(setMember);
    //        if (contains)
    //            innerMembers.Remove(innerMember);
    //    }
    //}
}