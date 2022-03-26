namespace MathematicsFramework
{
    public abstract class SetMember//: ISetMember
    {
        protected SetMember() { }
        public bool IsSetElement<T>() where T:struct => GetType().IsSubclassOf(typeof(SetElement<T>));
        public bool IsSet => GetType().IsSubclassOf(typeof(MathSet<SetMember>));
    }
}
