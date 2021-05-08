

namespace MathematicsFramework
{
    public static class SetOperations
    {
        public static void SetUnion<T>(this Set<T> set, Set<T> unionSet) where T:SetMember
        {
            set.GetAllMember().UnionWith(unionSet.GetAllMember());
        }
    }
}
