using System;

namespace MathematicsFramework
{
    public static class SetFactory
    {
        public static MathSet<SetMember> CreatePowerSet<T>(T[] setMembers) where T : MathSet<SetMember>
        {
            //todo
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
