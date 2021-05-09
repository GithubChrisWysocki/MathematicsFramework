using System;

namespace MathematicsFramework
{
    public static class SetFactory
    {
        public static Set<ISetMember> CreatePowerSet<T>(T[] setMembers) where T : Set<ISetMember>
        {
            //todo
            return null;
        }
        public static Set<ISetMember> CreateSet<T>() where T : Set<ISetMember>
        {
            return (Set<ISetMember>)Activator.CreateInstance(typeof(T));
        }

        public static Set<ISetMember> CreateSet<T>(T[] setMembers) where T : Set<ISetMember>
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
