using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
      
        private class TestSet: Set<SetMember> { }
        private class TestElement : SetElement { }
        [TestMethod]
        public void TestSetElementIsTrue()
        {
            TestSet testSet = new TestSet();
            testSet.AddMember(new TestElement());
            Assert.IsTrue(testSet[0].IsSetElement);
        }
        [TestMethod]
        public void TestSetIsTrue()
        {
            TestSet testSet = new TestSet();
            testSet.AddMember(new TestSet());
            Assert.IsTrue(testSet[0].IsSet);
        }
    }
}
