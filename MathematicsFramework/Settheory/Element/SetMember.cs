using System;
using MathematicsFramework.Settheory.Element;

namespace MathematicsFramework.Settheory.ElementSet
{
    public abstract partial class SetMember//: ISetMember{
    {
        //public bool IsSetElement<T>() where T:struct
        //    => GetType().IsSubclassOf(typeof(SetElement<T>));

        public bool IsSetElement => GetType().IsSubclassOf(typeof(SetElement))|| InheritsFromMathGenericElement(this);
        
       // public bool IsSet<T>() where T:SetMember => GetType().IsSubclassOf(typeof(MathGenericSet<T>)) || GetType().IsSubclassOf(typeof(MathGenericSet));
        

        static bool InheritsFromMathGenericElement(object obj)
        {
            if (obj == null) return false;

            Type type = obj.GetType();
            Type genericBaseType = typeof(SetElement<>);

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
