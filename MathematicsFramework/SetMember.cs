namespace MathematicsFramework
{
    public abstract class SetMember:ISetMember
    {
        protected SetMember()
        {

        }
        public bool IsSetElement => GetType().IsSubclassOf(typeof(SetElement));
        public bool IsSet => GetType().IsSubclassOf(typeof(Set<SetMember>));
    }
}
