using System;

namespace MathematicsFramework.Settheory.Element
{
    public abstract class SetElement<T> : SetElement where T : struct
    {
        public new T Value { get; set; }
    }

    public abstract class SetElement : SetMember
    {
        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                if (value.GetType().IsStruct())
                    _value = value;
                else
                    throw new ArgumentException("Value must be a struct.");
            }
        }
    }


}
