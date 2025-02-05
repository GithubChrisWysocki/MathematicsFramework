using System.Collections.Generic;

namespace MathematicsFramework.Settheory
{
    public class SetFactoryGeneric
    {
        /// <summary>
        /// Creates set wiht default comparer,
        /// if setMembers is null, an empty set is returned
        /// </summary>
        /// <typeparam name="MEMBERTYPE"></typeparam>
        /// <typeparam name="MEMBERTYPE"></typeparam>
        /// <param name="setMembers"></param>
        /// <returns></returns>
        public static IMathSetGeneric<MEMBERTYPE> CreateSetWithCustomComparer<SETTYPE, MEMBERTYPE,COMPARER>(params MEMBERTYPE[] setMembers) where SETTYPE : MathSetGeneric<MEMBERTYPE, COMPARER>, new() where MEMBERTYPE : SetMember, ICompareable where COMPARER : IEqualityComparer<MEMBERTYPE>, new()
        {
            if (setMembers == null)
                return new SETTYPE();

            var result = CreateSetWithCustomComparer<SETTYPE, MEMBERTYPE,COMPARER>(null);

            foreach (var item in setMembers)
                result.AddMember(item);
            
            return result;
        }
        public static IMathSetGeneric<MEMBERTYPE> CreateSetWithDefaultComparer<SETTYPE, MEMBERTYPE>(params MEMBERTYPE[] setMembers) where SETTYPE : MathSetGeneric<MEMBERTYPE>, new() where MEMBERTYPE : SetMember, ICompareable 
        {
            if (setMembers == null)
                return new SETTYPE();

            var result = CreateSetWithDefaultComparer<SETTYPE, MEMBERTYPE>(null);

            foreach (var item in setMembers)
                result.AddMember(item);

            return result;
        }
    }
}
