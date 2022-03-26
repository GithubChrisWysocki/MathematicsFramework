using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        public class TestMathSet : MathSet<SetMember> { }
        private class TestElement : SetElement<int> { }
        static TestMathSet _testMathSet;
        static TestElement testElement;
        static UnitTestSet()
        {
            _testMathSet = new TestMathSet();
            testElement = new TestElement();
            _testMathSet.AddMember(testElement);
            _testMathSet.AddMember(new TestMathSet());
        }
        [TestMethod]
        public void TestSetElementIsTrue()
        {
            Assert.IsTrue(_testMathSet[0].IsSetElement<int>());
        }
        [TestMethod]
        public void TestSetIsTrue()
        {
            Assert.IsTrue(_testMathSet[1].IsSet);
        }
        [TestMethod]
        public void TestSetUnion()
        {
            //int count = 0;
            //Set<SetMember> testSet2 = SetFactory.CreateSet<TestSet>(new TestSet[] { new TestSet() });
            //count = testSet2.GetAllMember().Count;
            //Assert.AreEqual(count, 1);
            //testSet2.SetUnion(testSet);
            //count = testSet2.GetAllMember().Count;
            //Assert.AreEqual(count, 3);
        }
        [TestMethod]
        public void TestIsSetMember()
        {
            //Set<SetMember> testSet2 = SetFactory.CreateSet<TestSet>(null);
            //Assert.IsFalse(testSet.ContainsMember(testSet2));
            //testSet2.AddMember(testSet);
            //bool res = testSet2.ContainsMember(testSet);
            //Assert.IsTrue(false);
            //testSet2.SetUnion(testSet);
            //Assert.IsTrue(testSet2.ContainsMember(testElement));
        }
        
    }
}
