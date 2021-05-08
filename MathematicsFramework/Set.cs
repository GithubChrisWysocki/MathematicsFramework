using System;
using System.Collections;

namespace MathematicsFramework
{
    public abstract class Set: CollectionBase ,ISetMember
    {

        public ISetMember this[int key]
        {
            get
            {
                return InnerList[key] as ISetMember;
            }
        }
        public void AddMember(ISetMember setMember)
        {
            InnerList.Add(setMember);
            var x = InnerList[0];
        }

        public bool IsSet=>true;


        public bool IsSetElement => false;
    }
}
