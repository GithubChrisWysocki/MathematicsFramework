using System;
using System.Collections;
using System.Collections.Generic;

namespace MathematicsFramework.Settheory
{
    public abstract class SetElement<T> : SetElement, IElementGeneric<T> where T : struct
    {
        //todo: default constructor is bad idea for element construction Comparer should be injected as singleton through interface and construcor because there can be very many sets and there is only need for one instance of comparer

        public SetElement()
        {
            Comparer = new DefaultComparer<T>();
        }

        public SetElement(IEqualityComparer<T> comparer)
        {
            Comparer = comparer;
        }

        private T _value;

        public new IEqualityComparer<T> Comparer { get; }

        public new T Value
        {
            get => _value;
            set
            {
                if (value.GetType().IsValueType)
                    _value = value;
                else
                    throw new ArgumentException("Value must be a ValueType.");
            }
        }
    }

    public abstract class SetElement : SetMember,IElementNonGeneric
    {
        public SetElement()
        {
            Comparer = new DefaultComparer();
        }

        public SetElement(IEqualityComparer comparer)
        {
            Comparer = comparer;
        }
        private object? _value;

        public object? Value
        {
            get => _value;
            set
            {
                //todo: Maybe throwing Exception during runtime is not the best way to handle this. May be a nongeneric Element not restricted to struct should not exist.
                if (value.GetType().IsValueType)
                    _value = value;
                else
                    throw new ArgumentException("Value must be ValueType.");
            }
        }

        public IEqualityComparer Comparer { get; }
    }
}