using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        private TestSet_Abstract _setNonGeneric;
        private TestSet1Abstract _setAbstract;
        private TestSetOnlyElement _setOnlyElement;
        private TestElement_Abstract _elementAbstract;
        private TestElement_Generic_decimal _elementGenericDecimal;

        [TestInitialize]
        public void Setup()
        {
            _setNonGeneric = new TestSet_Abstract();
            _setAbstract = new TestSet1Abstract();
            _setOnlyElement = new TestSetOnlyElement();
            _elementAbstract = new TestElement_Abstract();
            _elementGenericDecimal = new TestElement_Generic_decimal();
        }

        [TestMethod]
        public void IgnoreDuplicate()
        {
            _setNonGeneric.AddMember(_setOnlyElement);
            var elementCount = _setNonGeneric.innerMembers.Count;
            _setNonGeneric.AddMember(_setOnlyElement);
            Assert.AreEqual(elementCount, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestCanOnlyAddElementRestrictedByGeneric()
        {
            _setOnlyElement.AddMember(new TestElement_Abstract(){Value = new decimal()});
            Assert.ThrowsException<ArgumentException>(() => _setOnlyElement.AddMember(new TestElement_Abstract(){Value = new object()}));
        }

        [TestMethod]
        public void TestAddMemberOrSetIncreaseCountByOne()
        {
            var countbeforeAdd = _setNonGeneric.innerMembers.Count;
            _setNonGeneric.AddMember(new object());
            Assert.AreEqual(countbeforeAdd + 1, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestPreventSelfReferential()
        {
            var i = _setAbstract.innerMembers.Count;
            Assert.ThrowsException<ArgumentException>(() => _setAbstract.AddMember(_setAbstract));
            Assert.AreEqual(i, _setAbstract.innerMembers.Count);
        }

        [TestMethod]
        public void TestIsSetTrue()
        {
            var setGenericAbstract = new TestSet1Abstract();
            setGenericAbstract.AddMember(_setNonGeneric);
            setGenericAbstract.AddMember(_setOnlyElement);

            Assert.IsTrue(setGenericAbstract[0].IsSet);
            Assert.IsTrue(setGenericAbstract[1].IsSet);
            Assert.IsFalse(setGenericAbstract[1].IsSetElement);
        }

        [TestMethod]
        public void TestSetElementIsTrue()
        {
            var setGenericElement = new TestSetOnlyElement();
            setGenericElement.AddMember(new TestElement_Abstract() { Value = 1 });
            setGenericElement.AddMember(new TestElement_Abstract() { Value = 2 });
            
            Assert.IsTrue(setGenericElement[0].IsSetElement);
            Assert.IsTrue(setGenericElement[1].IsSetElement);
            Assert.IsFalse(setGenericElement[1].IsSet);
        }

        [TestMethod]
        public void TestCanAddRandomObjectToNongenericSet()
        {
            _setNonGeneric.AddMember(1);
            var h2 = new ArrayList();
            _setNonGeneric.AddMember("asdf");
            _setNonGeneric.AddMember(h2.Add(1));
            _setNonGeneric.AddMember(_elementGenericDecimal);
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

        [TestMethod]
        public void TestContainsMemeber()
        {
            _setOnlyElement.AddMember(_elementAbstract);
           Assert.IsTrue(_setOnlyElement.ContainsMember(_elementAbstract));
           Assert.IsFalse(_setOnlyElement.ContainsMember( new TestElement_Abstract(){Value = 122}));
        }
    }
}