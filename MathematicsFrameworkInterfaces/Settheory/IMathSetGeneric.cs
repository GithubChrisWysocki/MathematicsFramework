using System.Collections;
using Base;

namespace MathematicsFramework.Settheory;

public interface IMathSetGeneric<T> 
{
    IEqualityComparer<T> Comparer { get;  }
    (bool contains, T? innerMember) ContainsMember(T memberToCheck, bool recursive = false);
    void AddMember(T setMember);
    void RemoveMember(T setMember);
    SetCollection<T> innerMembers { get; }
}