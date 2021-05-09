namespace MathematicsFramework
{
    public interface ISetMember
    {
        public bool IsSetElement<T>() where T : struct;
        public bool IsSet { get; }
    }
}