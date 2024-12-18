using System;

namespace MathematicsFramework
{
    public abstract class SetMember//: ISetMember{
    {
        protected SetMember() { }
        public bool IsSetElement<T>() => GetType().IsSubclassOf(typeof(SetElement<T>));

        public bool IsSetElement() => GetType().IsSubclassOf(typeof(SetElement));
        
        public bool IsSet => GetType().IsSubclassOf(typeof(MathGenericSet<SetMember>));
    }
}
