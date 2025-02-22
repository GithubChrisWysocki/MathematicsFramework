﻿using System;

namespace MathematicsFramework.Settheory
{
    public abstract class SetMember //: ISetMember{
    {
        public bool IsSetElement => GetType().IsSubclassOf(typeof(SetElement)) || InheritsFromMathGenericElement(this);

        public bool IsSet => GetType().IsSubclassOf(typeof(MathSet)) || InheritsFromMathGenericSet(this);

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