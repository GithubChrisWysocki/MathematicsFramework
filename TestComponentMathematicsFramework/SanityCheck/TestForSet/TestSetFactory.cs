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
        var testSet2 = SetFactory.CreateSet<TestSetOnlyElement,TestElement_Abstract>(null);
        Assert.IsInstanceOfType<TestSetOnlyElement>(testSet2);
        Assert.AreEqual(testSet2.innerMembers.Count,0);

        var testset3 = SetFactory.CreateSet<TestSet_Abstract>(null);
        Assert.IsInstanceOfType<TestSet_Abstract>(testset3);
        Assert.AreEqual(testset3.innerMembers.Count,0);

        var testSet4 = SetFactory.CreateSet<TestSetWithElementDecimal,TestElement_Generic_decimal>(null);
        Assert.IsInstanceOfType<TestSetWithElementDecimal>(testSet4);
        Assert.AreEqual(testSet4.innerMembers.Count,0);
    }
}