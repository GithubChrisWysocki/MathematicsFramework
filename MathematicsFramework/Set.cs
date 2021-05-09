﻿using System.Collections.Generic;

namespace MathematicsFramework
{
    public abstract class Set<T> : SetMember where T : SetMember
    {
        private SetCollection innerMembers;
        public class SetCollection : HashSet<T> { }
        public Set()
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
