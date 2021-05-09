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
            int count = 0;
            Set<ISetMember> testSet2 = SetFactory.CreateSet<TestSet>();
            testSet2.AddMember(new TestSet());
            count = testSet2.GetAllMember().Count;
            Assert.AreEqual(count, 1);
            testSet2.SetUnion(testSet);
            count = testSet2.GetAllMember().Count;
            Assert.AreEqual(count , 3);
        }
        [TestMethod]
        public void TestIsSetMember()
        {
            Set<ISetMember> testSet2 = SetFactory.CreateSet<TestSet>();
            Assert.IsFalse(testSet.ContainsSet(testSet2));
            testSet2.AddMember(testSet);
            bool res= testSet2.ContainsSet(testSet);
            Assert.IsTrue(res);
        }
        
    }
}
