namespace Base;

//todo: Das kann womöglich ganz weg und überall setcollection durch hashset ersetzt werden
public class SetCollection<T> : HashSet<T>
{
    public SetCollection(IEqualityComparer<T> comparer) : base(comparer)
    {
    }
}

