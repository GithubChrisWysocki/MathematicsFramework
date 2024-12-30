using System.Collections;

namespace MathematicsFramework.Settheory;

public interface IMathSetNonGeneric
{
    IEqualityComparer Comparer { get;  }
    (bool contains, object? innerMember) ContainsMember(object memberToCheck, bool recursive = false);
    void AddMember(object setMember);
    void RemoveMember(object setMember);
    ArrayList innerMembers { get; }

}