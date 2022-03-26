namespace MathematicsFramework
{
    public static class SetOperations
    {
        public static void SetUnion<T>(this MathSet<T> mathSet, MathSet<T> unionMathSet) where T:SetMember
        {
            mathSet.GetAllMember().UnionWith(unionMathSet.GetAllMember());
        }
        //public static bool IsSetMember<T>(this Set<T> set , Set<T> memberOfSet) where T : ISetMember
        //{
        //    T member = (T)set ;
        //    foreach (var item in set.GetAllMember())
        //    {
        //        memberOfSet.GetAllMember().Contains(set);
        //    }
        //    return true;
        //}
    }
}
