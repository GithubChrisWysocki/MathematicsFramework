using System;
using MathematicsFramework.Settheory.Element;
using MathematicsFramework.Settheory.Set;

namespace MathematicsFramework.Settheory
{
    public abstract class SetMember//: ISetMember{
    {
        //public bool IsSetElement<T>() where T:struct
        //    => GetType().IsSubclassOf(typeof(SetElement<T>));

        public bool IsSetElement => GetType().IsSubclassOf(typeof(SetElement));
        
       // public bool IsSet<T>() where T:SetMember => GetType().IsSubclassOf(typeof(MathGenericSet<T>)) || GetType().IsSubclassOf(typeof(MathGenericSet));
        
        public bool IsSet => GetType().IsSubclassOf(typeof(MathGenericSet))|| InheritsFromMathGenericSet(this);
        
        static bool InheritsFromMathGenericSet(object obj)
        {
            if (obj == null) return false;

            Type type = obj.GetType();
            Type genericBaseType = typeof(MathGenericSet<>);

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
