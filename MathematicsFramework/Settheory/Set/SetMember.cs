using System;
using MathematicsFramework.Settheory.Set;

namespace MathematicsFramework.Settheory.ElementSet
{
    public  abstract partial class SetMember{
        
       public bool IsSet => GetType().IsSubclassOf(typeof(MathSet))|| InheritsFromMathGenericSet(this);

        
        static bool InheritsFromMathGenericSet(object obj)
        {
            if (obj == null) return false;

            Type type = obj.GetType();
            Type genericBaseType = typeof(MathSet<>);

            while (type != null && type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericBaseType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }

    }
}
