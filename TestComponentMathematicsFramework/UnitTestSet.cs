using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {

        private class TestSet : Set<SetMember> { }
        private class TestElement : SetElement<int> { }
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
            Assert.IsTrue(testSet[0].IsSetElement<int>());
        }
        [TestMethod]
        public void TestSetIsTrue()
        {
            Assert.IsTrue(testSet[1].IsSet);
        }
        [TestMethod]
        public void TestSetUnion()
        {
            TestSet  testSet2 = new TestSet();
            testSet2.AddMember(new TestSet());
            testSet.SetUnion(testSet2);
            var count = testSet.GetAllMember().Count;
            Assert.IsTrue(count == 3);
        }
    }
}
