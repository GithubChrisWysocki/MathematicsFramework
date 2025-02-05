using System.Collections.Generic;

namespace MathematicsFramework.Settheory
{
    public class SetFactoryNonGenericSet
    {
        /// <summary>
        /// Creates set with custom comparer,
        /// if setMembers is null an empty set is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setMembers"></param>
        /// <returns></returns>
        public static IMathSetNonGeneric CreateSetWithCustomComparer<SETTYPE,COMPARER>(params object[] setMembers) where SETTYPE : MathSet<COMPARER>, new() where COMPARER: IEqualityComparer<object>, new()
        {
            if (setMembers == null)
                return new SETTYPE();
            var result = CreateSetWithCustomComparer<SETTYPE,COMPARER>(null);
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }

        public static IMathSetNonGeneric CreateSetWithDefaultComparer<SETTYPE>(params object[] setMembers) where SETTYPE : MathSet, new() 
        {
            if (setMembers == null)
                return new SETTYPE();
            var result = CreateSetWithDefaultComparer<SETTYPE>(null);
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }

        //public static MathSet CreatePowerSet<T>(T[] setMembers, int? cardinality = null) //where T:SetMember
        //{
        //    if (cardinality == null)
        //    {
        //        cardinality = setMembers.Length;
        //    }


        //    for (int i = 0; i < cardinality; i++)
        //    {

        //    }

        //    return null;
        //}

    }
}