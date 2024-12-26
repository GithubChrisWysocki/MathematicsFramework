namespace MathematicsFramework
{
    public static class SetFactory
    {
        public static MathGenericSet<SetMember> CreatePowerSet<T>(T[] setMembers) where T : MathGenericSet<SetMember>
        {
           
            return null;
        }

        public static MathGenericSet<SetMember> CreateSet<T>(T[] setMembers) where T : MathGenericSet<SetMember>
        {
            var result = CreateSet<T>(null);// CreateSet<T>();
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }
    }
}
