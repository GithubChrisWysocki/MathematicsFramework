using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsFramework
{
     public abstract class SetMember
    {
        public bool IsSetElement => GetType().IsSubclassOf(typeof(SetElement));
        public bool IsSet => GetType().IsSubclassOf(typeof(Set<SetMember>));


    }
}
