﻿

namespace MathematicsFramework.Settheory
{
    public static class SetFactory
    {
        public static MathSet CreatePowerSet<T>(T[] setMembers, int? cardinality = null) //where T:SetMember
        {
            if (cardinality==null)
            {
                cardinality = setMembers.Length;
            }

            
            
            for (int i = 0; i < cardinality; i++)
            {
                
            }
            
            return null;
        }

      //  public static T CreateSet<T>() where T : MathSet<>, new()
      //  {
      //      return new T(); //(Set<SetMember>)Activator.CreateInstance(typeof(T));
      //  }

        public static T CreateSetNonGeneric<T>(params object[] setMembers) where T : MathSet, new()
        {
            if (setMembers == null)
                return new T();
            var result = CreateSetNonGeneric<T>(null);
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }
        
        public static IMathSetGeneric<T> CreateSet<T>( T[] setMembers) where T : SetMember, IMathSetGeneric<T>, new() 
        {
            if (setMembers == null)
                return new T();
            var result = CreateSet<T>(null);
            foreach (var item in setMembers)
            {
                result.AddMember(item);
            }
            return result;
        }
    }
}