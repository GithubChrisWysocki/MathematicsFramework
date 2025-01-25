using System.Collections;

namespace Base;
public class SetCollection<T> : HashSet<T>
{
    public SetCollection(IEqualityComparer<T> comparer) : base(comparer)
    {
    }
}

public class SetCollection: Hashtable
{
    public SetCollection(IEqualityComparer comparer) : base(comparer)
    {
    }
}