using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        public class TestSet : Set<SetMember> { }
        private class TestElement : SetElement<int> { }
        static TestSet testSet;
        static TestElement testElement;
        static UnitTestSet()
        {
            testSet = new TestSet();
            testElement = new TestElement();
            testSet.AddMember(testElement);
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
            Set<SetMember> testSet2 = SetFactory.CreateSet<TestSet>(new TestSet[] { new TestSet() });
            count = testSet2.GetAllMember().Count;
            Assert.AreEqual(count, 1);
            testSet2.SetUnion(testSet);
            count = testSet2.GetAllMember().Count;
            Assert.AreEqual(count, 3);
        }
        [TestMethod]
        public void TestIsSetMember()
        {
            Set<SetMember> testSet2 = SetFactory.CreateSet<TestSet>(null);
            Assert.IsFalse(testSet.ContainsMember(testSet2));
            testSet2.AddMember(testSet);
            bool res = testSet2.ContainsMember(testSet);
            Assert.IsTrue(false);
            testSet2.SetUnion(testSet);
            Assert.IsTrue(testSet2.ContainsMember(testElement));
        }
        
    }
}
