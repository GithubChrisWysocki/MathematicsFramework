namespace MathematicsFramework.Settheory.Set
{
    public static class SetFactory
    {
        public static MathSet<SetMember> CreatePowerSet<T>(T[] setMembers) where T : MathSet<SetMember>
        {
            return null;
        }

        public static MathSet<SetMember> CreateSet<T>(T[] setMembers) where T : MathSet<SetMember>
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
