using System;

namespace MathematicsFramework;

public static class GeneralExtensions
{
    public static bool IsStruct(this Type type)
    {
        return type.IsValueType && !type.IsPrimitive && !type.IsEnum;
    }
}