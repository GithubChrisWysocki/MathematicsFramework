using System.Collections;
using System.Linq;

namespace MathematicsFramework
{
    public static class SetOperations
    {
        public static void SetUnion<T>(this MathGenericSet<T> mathSet, MathGenericSet<T> unionMathSet) where T:SetMember
        {
            mathSet.GetAllMember().UnionWith(unionMathSet.GetAllMember());
        }
        public static void SetUnion(this MathGenericSet mathSet, MathGenericSet unionMathSet) 
        {
            mathSet.GetAllMember().UnionWith(unionMathSet);
        }
        public static void UnionWith(this ArrayList arrList, MathGenericSet set)
        {
            ArrayList unionList = new ArrayList(arrList);
            
            foreach (var item in set.GetAllMember())
            {
                if (!unionList.Contains(item)) // Prevent duplicates
                {
                    unionList.Add(item);
                }
            }
        }
        public static void SetIntersection<T>(this MathGenericSet<T> mathSet, MathGenericSet<T> intersectMathSet) where T : SetMember
        {
            var intersection = mathSet.GetAllMember().Intersect(intersectMathSet.GetAllMember()).ToList();
            mathSet.GetAllMember().Clear();
            foreach (var item in intersection)
            {
                mathSet.GetAllMember().Add(item);
            }
        }

        public static void SetDifference<T>(this MathGenericSet<T> mathSet, MathGenericSet<T> differenceMathSet) where T : SetMember
        {
            var difference = mathSet.GetAllMember().Except(differenceMathSet.GetAllMember()).ToList();
            mathSet.GetAllMember().Clear();
            foreach (var item in difference)
            {
                mathSet.GetAllMember().Add(item);
            }
        }
        public static bool ContainsSet<T>(this ArrayList list, MathGenericSet<T> mathSet)
        {
            foreach (var item in list)
            {
                if (mathSet.ContainsMember(item))
                {
                    return true;
                }
                
                    return false;
                
            }
            return true;
        }
        //public static void SetSymmetricDifference<T>(this MathGenericSet<T> mathSet, MathGenericSet<T> symmetricDifferenceMathSet) where T : SetMember
        //{
        //    var symmetricDifference = mathSet.GetAllMember().SymmetricExcept(symmetricDifferenceMathSet.GetAllMember()).ToList();
        //    mathSet.GetAllMember().Clear();
        //    foreach (var item in symmetricDifference)
        //    {
        //        mathSet.GetAllMember().Add(item);
        //    }
        //}
        //public static bool IsSetMember<T>(this Set<T> set, Set<T> memberOfSet) where T : ISetMember
        //{
        //    T member = (T)set;
        //    foreach (var item in set.GetAllMember())
        //    {
        //        memberOfSet.GetAllMember().Contains(set);
        //    }
        //    return true;
        //}
    }
}
