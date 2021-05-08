using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsFramework
{
     public abstract class SetMember:ISetMember
    {
        public bool IsSetElement => GetType().IsInstanceOfType(typeof(SetElement));
        public bool IsSet => GetType().IsInstanceOfType(typeof(Set));
    }
}
