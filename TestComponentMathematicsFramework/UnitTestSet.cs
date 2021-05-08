using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {

        private class TestSet : Set<SetMember> { }
        private class TestElement : SetElement { }
        static TestSet testSet;
        static UnitTestSet()
        {
            testSet = new TestSet();
            testSet.AddMember(new TestElement());
            testSet.AddMember(new TestSet());
        }
        [TestMethod]
        public void TestSetElementIsTrue()
        {
            Assert.IsTrue(testSet[0].IsSetElement);
        }
        [TestMethod]
        public void TestSetIsTrue()
        {
            Assert.IsTrue(testSet[1].IsSet);
        }
    }
}
