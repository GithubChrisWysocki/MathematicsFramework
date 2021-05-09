using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {

        private class TestSet : Set<ISetMember> { }
        private class TestElement : SetElement<int> { }
        static TestSet testSet;

         static Set<ISetMember> testSet2 { get; }

        static UnitTestSet()
        {
            testSet = new TestSet();
            testSet.AddMember(new TestElement());
            testSet.AddMember(new TestSet());
            testSet2 = SetFactory.CreateSet<TestSet>();
            testSet2.AddMember(new TestSet());
            testSet.SetUnion(testSet2);
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
            var count = testSet.GetAllMember().Count;
            Assert.IsTrue(count == 3);
        }
        [TestMethod]
        public void TestIsSetMember()
        {
            Assert.IsFalse(testSet.ContainsSet(testSet2));
            testSet.AddMember(testSet2);
            bool res= testSet.ContainsSet(testSet2);
            Assert.IsTrue(res);
        }
        
    }
}
