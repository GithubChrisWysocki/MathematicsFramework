using System;
using System.Collections;
using System.Collections.Generic;

namespace MathematicsFramework
{
    public abstract class Set<T> : SetMember where T:SetMember
    {
        private SetCollection innerMembers;

        public class SetCollection : HashSet<T>
        {
  
        }

        public int Count { get => innerMembers.Count; }


        public void Clear() => innerMembers.Clear();
        public IEnumerator GetEnumerator() => innerMembers.GetEnumerator();
        public void RemoveAt(T setMember) => innerMembers.Remove( setMember);

        public Set()
        {
            innerMembers = new SetCollection();
        }

        public SetMember this[int key]
        {
            get
            {
                for (int i = 0;key < innerMembers.Count || i < key; i++)
                {
                     innerMembers.GetEnumerator().MoveNext();
                }
                return innerMembers.GetEnumerator().Current;
            }
        }

        public void AddMember(T setMember)
        {
            innerMembers.Add(setMember);
        }
        public SetCollection GetAllMember() => innerMembers;
    }
}
