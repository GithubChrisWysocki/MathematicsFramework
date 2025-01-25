namespace Base;
public class SetCollection<T> : HashSet<T>
{
    public SetCollection(IEqualityComparer<T> comparer) : base(comparer)
    {
    }
}