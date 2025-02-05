using MathematicsFramework.Settheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework;
[TestClass]
public class TestSetFactory
{
    [TestMethod]
    public void TestSetFactorySanity()
    {
        var testSet2 = SetFactoryGeneric.CreateSetWithDefaultComparer<TestSetCustomElement, TestElement_Abstract_NonGeneric>(null);
        Assert.IsInstanceOfType<TestSetCustomElement>(testSet2);
        Assert.AreEqual(testSet2.innerMembers.Count,0);

        var testset3 = SetFactoryNonGenericSet.CreateSetWithDefaultComparer<TestSet_Abstract_NonGeneric>(null);
        Assert.IsInstanceOfType<TestSet_Abstract_NonGeneric>(testset3);
        Assert.AreEqual(testset3.innerMembers.Count,0);

        var testSet4 = SetFactoryGeneric.CreateSetWithDefaultComparer<TestSetWithElementDecimal, TestElement_Generic_decimal>(null);
        Assert.IsInstanceOfType<TestSetWithElementDecimal>(testSet4);
        Assert.AreEqual(testSet4.innerMembers.Count,0);
    }
    
    [TestMethod]
    public void TestSetFactorySanityWithMembers()
    {
        var testSet2 = SetFactoryGeneric.CreateSetWithDefaultComparer<TestSetCustomElement,TestElement_Abstract_NonGeneric>(new TestElement_Abstract_NonGeneric());
        Assert.IsInstanceOfType<TestSetCustomElement>(testSet2);
        Assert.AreEqual(testSet2.innerMembers.Count,1);

        var testset3 = SetFactoryNonGenericSet.CreateSetWithDefaultComparer<TestSet_Abstract_NonGeneric>(testSet2,1,"xyz");
        Assert.IsInstanceOfType<TestSet_Abstract_NonGeneric>(testset3);
        Assert.AreEqual(testset3.innerMembers.Count,3);

        var testSet4 = SetFactoryGeneric.CreateSetWithDefaultComparer<TestSetWithElementDecimal,TestElement_Generic_decimal>(new TestElement_Generic_decimal(){Value = 1});
        Assert.IsInstanceOfType<TestSetWithElementDecimal>(testSet4);
        Assert.AreEqual(testSet4.innerMembers.Count,1);
    }
}