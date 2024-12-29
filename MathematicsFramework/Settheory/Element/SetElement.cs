using System;
using MathematicsFramework.Settheory.ElementSet;

namespace MathematicsFramework.Settheory.Element
{
    public abstract class SetElement<T> : SetElement
    {
        private T _value;
        public new T Value
        {
            get { return _value; }
            set
            {
                if (value.GetType().IsValueType)
                    _value = value;
                else
                    throw new ArgumentException("Value must be a ValueType.");
            }
        }
    }

    public abstract class SetElement : SetMember
    {
        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                if (value.GetType().IsValueType)
                    _value = value;
                else
                    throw new ArgumentException("Value must be ValueType.");
            }
        }
    }


}
