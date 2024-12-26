namespace MathematicsFramework
{
    public abstract class SetElement<T> : SetElement
    {
        public new T Value { get; set; }
    }
    public abstract class SetElement : SetMember
    {
        public object Value { get; set; }   
    }
}
