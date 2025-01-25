using MathematicsFramework.Settheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework.SetOps
{
    [TestClass]
    public class TestSetOps
    {
        [TestMethod]
        public void TestSetCanUnionEmptySetsStaysZero()
        {
            var emptyset3 = SetFactory.CreateSet<TestSet_Abstract_NonGeneric>(null);
            var eptyset5 = SetFactory.CreateSet<TestSet_Abstract_NonGeneric2>(null);

            emptyset3.SetUnionMerge(eptyset5);

            Assert.AreEqual(emptyset3.innerMembers.Count, 0);
        }
    }
}
