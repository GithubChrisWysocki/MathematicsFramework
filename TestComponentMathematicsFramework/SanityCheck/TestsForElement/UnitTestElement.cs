using MathematicsFramework.Settheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework.SanityCheck.Element;
[TestClass]
public class UnitTestElement
{
    [TestMethod]
    public void TestFactoryCanCreateNonGenericElement()
    {
        var element = ElementFactory.CreateElement<TestElement_Abstract_NonGeneric>(null);
        Assert.IsInstanceOfType<TestElement_Abstract_NonGeneric>(element);
        Assert.IsNull(element.Value);

        var element2 = ElementFactory.CreateElement<TestElement_Abstract_NonGeneric>(3);
        Assert.IsInstanceOfType<TestElement_Abstract_NonGeneric>(element);
        Assert.AreEqual(element2.Value, 3);

        var element3 = ElementFactory.CreateElement<TestElement_Abstract_NonGeneric>(3);
        Assert.IsInstanceOfType<TestElement_Abstract_NonGeneric>(element);
        Assert.AreEqual(element3.Value, 3);

        Assert.IsTrue(element3.Comparer.Equals(element3, element2));
    }

    [TestMethod]
    public void TestFactoryCanCreateGenericElement()
    {
        var element = ElementFactory.CreateElement<TestElement_Generic_decimal>(null);
        Assert.IsInstanceOfType<TestElement_Generic_decimal>(element);
        Assert.IsNull(element.Value);

        var element2 = ElementFactory.CreateElement<TestElement_Generic_decimal>(3);
        Assert.IsInstanceOfType<TestElement_Generic_decimal>(element);
        Assert.AreEqual(element2.Value, 3);

        var element3 = ElementFactory.CreateElement<TestElement_Generic_decimal>(3);
        Assert.IsInstanceOfType<TestElement_Generic_decimal>(element);
        Assert.AreEqual(element3.Value, 3);
        Assert.IsTrue(element3.Comparer.Equals(element3, element2));
    }
}