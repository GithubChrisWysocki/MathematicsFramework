using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        private TestSet_Abstract _setAbstract;
        private TestSet1_Generic_Abstract _setGenericAbstract;
        private TestSet_Generic_Element _setGenericElement;
        private TestElement_Abstract _elementAbstract;
        private TestElement_Generic_decimal _elementGenericDecimal;

        [TestInitialize]
        public void Setup()
        {
            _setAbstract = new TestSet_Abstract();
            _setGenericAbstract = new TestSet1_Generic_Abstract();
            _setGenericElement = new TestSet_Generic_Element();
            _elementAbstract = new TestElement_Abstract();
            _elementGenericDecimal = new TestElement_Generic_decimal();
        }

        [TestMethod]
        public void IgnoreDuplicate()
        {
            _setAbstract.AddMember(_setGenericElement);
            var elementCount = _setAbstract.innerMembers.Count;
            _setAbstract.AddMember(_setGenericElement);
            Assert.AreEqual(elementCount, _setAbstract.innerMembers.Count);
        }

        [TestMethod]
        public void TestCanOnlyAddElementRestrictedByGeneric()
        {
            _setGenericElement.AddMember(new TestElement_Abstract());
        }

        [TestMethod]
        public void TestAddElementOrSetIncreaseCountByOne()
        {
            var countbeforeAdd = _setAbstract.innerMembers.Count;
            _setAbstract.AddMember(new object());
            Assert.AreEqual(countbeforeAdd + 1, _setAbstract.innerMembers.Count);
        }

        [TestMethod]
        public void TestPreventSelfReferential()
        {
            var i = _setGenericAbstract.innerMembers.Count;
            Assert.ThrowsException<ArgumentException>(() => _setGenericAbstract.AddMember(_setGenericAbstract));
            Assert.AreEqual(i, _setGenericAbstract.innerMembers.Count);
        }

        [TestMethod]
        public void TestIsSetTrue()
        {
            var setGenericAbstract = new TestSet1_Generic_Abstract();
            setGenericAbstract.AddMember(_setAbstract);
            setGenericAbstract.AddMember(_setGenericElement);

            Assert.IsTrue(setGenericAbstract[0].IsSet);
            Assert.IsTrue(setGenericAbstract[1].IsSet);
        }

        [TestMethod]
        public void TestSetElementIsTrue()
        {
            var setGenericElement = new TestSet_Generic_Element();
            setGenericElement.AddMember(new TestElement_Abstract() { Value = 1 });
            setGenericElement.AddMember(new TestElement_Abstract() { Value = 2 });
            Assert.IsTrue(setGenericElement[0].IsSetElement);
            Assert.IsTrue(setGenericElement[1].IsSetElement);
        }

        [TestMethod]
        public void TestCanAddRandomObject()
        {
            _setAbstract.AddMember(1);
            var h2 = new ArrayList();
            _setAbstract.AddMember("asdf");
            _setAbstract.AddMember(h2.Add(1));
        }

        [TestMethod]
        public void TestSetUnion()
        {
            //int count = 0;
            //Set<SetMember> testSet2 = SetFactory.CreateSet<TestSet>(new TestSet[] { new TestSet() });
            //count = testSet2.innerMembers.Count;
            //Assert.AreEqual(count, 1);
            //testSet2.SetUnion(testSet);
            //count = testSet2.innerMembers.Count;
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