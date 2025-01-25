using System.Collections;
using System.Linq;

namespace MathematicsFramework.Settheory
{
    public static class SetOperations
    {
        public static void SetUnionMerge<T>(this IMathSetGeneric<T> mathSet, IMathSetGeneric<T> unionMathSet)
            where T : SetMember
        {
            mathSet.innerMembers.UnionWith(unionMathSet.innerMembers);
        }

        public static void SetUnionMerge(this IMathSetNonGeneric mathSet, IMathSetNonGeneric unionMathSet)
        {
            mathSet.innerMembers.UnionWith(unionMathSet);
        }

        public static IMathSetNonGeneric SetUnionNew<T>(MathSet mathSet, MathSet unionMathSet) where T:MathSet,new()
        {
            var retSet = SetFactory.CreateSet<T>(null);
            //todo: geht auch jeweils zwei parallele foreach
            retSet.innerMembers.UnionWith(mathSet);
            retSet.innerMembers.UnionWith(unionMathSet);
            return retSet;
        }
        private static void UnionWith(this ArrayList arrList, IMathSetNonGeneric set)
        {
            foreach (var item in set.innerMembers)
            {
                if (!set.ContainsMember(item).contains) // Prevent duplicates
                {
                    arrList.Add(item);
                }
            }
        }

        public static void SetIntersection<T>(this IMathSetGeneric<T> mathSet, IMathSetGeneric<T> intersectMathSet)
            where T : SetMember
        {
            var intersection = mathSet.innerMembers.Intersect(intersectMathSet.innerMembers).ToList();
            //mathSet.innerMembers.Clear();
            //foreach (var item in intersection)
            //{
            //    mathSet.innerMembers.Add(item);
            //}
        }

        public static void SetDifference<T>(this IMathSetGeneric<T> mathSet, IMathSetGeneric<T> differenceMathSet)
            where T : SetMember
        {
            var difference = mathSet.innerMembers.Except(differenceMathSet.innerMembers).ToList();
            mathSet.innerMembers.Clear();
            foreach (var item in difference)
            {
                mathSet.innerMembers.Add(item);
            }
        }

        public static bool ContainsSet<T>(this ArrayList list, MathSet mathSet)// where T : SetMember
        {
            foreach (var item in list)
            {
                if (mathSet.ContainsMember(item).contains)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        //public static void SetSymmetricDifference<T>(this MathGenericSet<T> mathSet, MathGenericSet<T> symmetricDifferenceMathSet) where T : SetMember
        //{
        //    var symmetricDifference = mathSet.innerMembers.SymmetricExcept(symmetricDifferenceMathSet.innerMembers).ToList();
        //    mathSet.innerMembers.Clear();
        //    foreach (var item in symmetricDifference)
        //    {
        //        mathSet.innerMembers.Add(item);
        //    }
        //}
        //public static bool IsSetMember<T>(this Set<T> set, Set<T> memberOfSet) where T : ISetMember
        //{
        //    T member = (T)set;
        //    foreach (var item in set.innerMembers)
        //    {
        //        memberOfSet.innerMembers.Contains(set);
        //    }
        //    return true;
        //}
    }
}