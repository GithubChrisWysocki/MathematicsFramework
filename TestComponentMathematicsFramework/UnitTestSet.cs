using System;
using MathematicsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        public class TestMathSet : MathSet<SetMember> { }
        private class TestElement : SetElement<int> { }
        private class TestElement2 :SetElement<decimal>{}
        static TestMathSet _testMathSet;
        static TestElement testElement;
        private static readonly TestElement2 testElement2;

        static UnitTestSet()
        {
            _testMathSet = new TestMathSet();
            testElement = new TestElement();
            testElement2=new TestElement2();
            object c = testElement2;
            _testMathSet.AddMember(testElement);
            _testMathSet.AddMember(testElement2);
            _testMathSet.AddMember(new TestMathSet());
        }
        [TestMethod]
        public void TestSetElementIsTrue()
        {
            Assert.IsTrue(_testMathSet[0].IsSetElement<int>());
            Assert.IsTrue(_testMathSet[1].IsSetElement<decimal>());
            Assert.IsTrue(_testMathSet[0].IsSetElement());
            Assert.IsTrue(_testMathSet[1].IsSetElement());
        }
        [TestMethod]
        public void TestSetIsTrue()
        {
            Assert.IsTrue(_testMathSet[2].IsSet);
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
