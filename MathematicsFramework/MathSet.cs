using System.Collections.Generic;

namespace MathematicsFramework
{
    public abstract class MathSet<T> : SetMember where T : SetMember
    {
        public static MathSet<SetMember> CreateSet<T>() where T : MathSet<SetMember>,new()
        {
            return new T(); //(Set<SetMember>)Activator.CreateInstance(typeof(T));
        }
        private SetCollection innerMembers;
        public class SetCollection : HashSet<T> { }
        public MathSet()
        {
            innerMembers = new SetCollection();
        }
        public bool ContainsMember(T memberToCheck)
        {
            return innerMembers.Contains(memberToCheck);
        }

        public SetMember? this[int key]
        {
            get
            {
                int i = 0;
                foreach (var item in innerMembers)
                    if (key == i++)
                        return item;

                return null;
            }
        }

        public void AddMember(T setMember)
        {
            innerMembers.Add(setMember);
        }
        public SetCollection GetAllMember() => innerMembers;
    }
}
