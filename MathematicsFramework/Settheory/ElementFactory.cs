namespace MathematicsFramework.Settheory;

public class ElementFactory
{
    public static IElementGeneric<TU> CreateElement<T, TU>(TU? elementValue)
        where T : SetElement<TU>, new() where TU : struct
    {
        if (elementValue == null)
            return new T();
        return new T() { Value = (TU)elementValue };
    }

    public static IElementNonGeneric CreateElement<T>(object? elementValue)
        where T : SetElement, new()
    {
        if (elementValue == null)
            return new T();
        return new T() { Value = elementValue };
    }
}