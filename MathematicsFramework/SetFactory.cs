using System;

namespace MathematicsFramework
{
    public static class SetFactory
    {
        public static Set<SetMember> CreatePowerSet<T>(T[] setMembers) where T : Set<SetMember>
        {
            //todo
            return null;
        }
        public static Set<SetMember> CreateSet<T>() where T : Set<SetMember>
        {
            return (Set<SetMember>)Activator.CreateInstance(typeof(T));
        }

        public static Set<SetMember> CreateSet<T>(T[] setMembers) where T : Set<SetMember>
        {
            var result = CreateSet<T>();
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }
    }
}
