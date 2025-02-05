using Base;
using System.Collections;

namespace MathematicsFramework.Settheory;

public interface IMathSetNonGeneric
{
    IEqualityComparer<object> Comparer { get;  }
    (bool contains, object? innerMember) ContainsMember(object memberToCheck, bool recursive = false);
    void AddMember(object setMember);
    void RemoveMember(object setMember);
    SetCollection<object> innerMembers { get; }

}