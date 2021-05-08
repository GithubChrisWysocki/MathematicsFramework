namespace MathematicsFramework
{
    public static class SetOperations
    {
        public static void SetUnion<T>(this Set<T> set, Set<T> unionSet) where T:ISetMember
        {
            set.GetAllMember().UnionWith(unionSet.GetAllMember());
        }
    }
}
