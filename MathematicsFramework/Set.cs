using System;
using System.Collections;

namespace MathematicsFramework
{
    public abstract class Set: SetMember
    {
        private SetCollection innerMembers;

        private class SetCollection : CollectionBase 
        {
            public ArrayList InnerList => base.InnerList; 
        }
        public Set()
        {
        innerMembers=    new SetCollection();
        }

        public ISetMember this[int key]
        {
            get
            {
                return innerMembers.InnerList[key] as ISetMember;
            }
        }
        public void AddMember(ISetMember setMember)
        {
            innerMembers.InnerList.Add(setMember);
        }

    }
}
