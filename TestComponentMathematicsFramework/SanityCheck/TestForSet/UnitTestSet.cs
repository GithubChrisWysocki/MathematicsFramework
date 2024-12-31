using System;
using System.Collections;
using MathematicsFramework.Settheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class UnitTestSet
    {
        [TestMethod]
        public void IgnoreDuplicate()
        {
            TestSet_Abstract _setNonGeneric = new TestSet_Abstract();
            TestSetOnlyElement _setOnlyElement = new TestSetOnlyElement();

            _setNonGeneric.AddMember(_setOnlyElement);
            var elementCount = _setNonGeneric.innerMembers.Count;
            _setNonGeneric.AddMember(_setOnlyElement);
            
            Assert.AreEqual(elementCount, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestCanOnlyAddElementRestrictedByGeneric()
        {
            TestSetOnlyElement _setOnlyElement = new TestSetOnlyElement();

            _setOnlyElement.AddMember(new TestElement_Abstract() { Value = new decimal() });
            
            Assert.ThrowsException<ArgumentException>(() =>
                _setOnlyElement.AddMember(new TestElement_Abstract() { Value = new object() }));
        }

        [TestMethod]
        public void TestAddMemberOrSetIncreaseCountByOne()
        {
            TestSet_Abstract _setNonGeneric = new TestSet_Abstract();
            var countbeforeAdd = _setNonGeneric.innerMembers.Count;
            
            _setNonGeneric.AddMember(new object());
            
            Assert.AreEqual(countbeforeAdd + 1, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestPreventSelfReferential()
        {
            TestSet_Abstract _setAbstract = new TestSet_Abstract();
            var i = _setAbstract.innerMembers.Count;
            
            Assert.ThrowsException<ArgumentException>(() => _setAbstract.AddMember(_setAbstract));
            Assert.AreEqual(i, _setAbstract.innerMembers.Count);
        }

        [TestMethod]
        public void TestIsSetTrue()
        {
            //Arrange
            TestElement_Generic_decimal _elementDecimal = new TestElement_Generic_decimal(){Value = 1};
            TestElement_Generic_decimal elementDecimal2 = new TestElement_Generic_decimal(){Value = 2};
            var setGenericAbstract = new TestSet1Abstract();
            //Act
            setGenericAbstract.AddMember(_elementDecimal);
            setGenericAbstract.AddMember(elementDecimal2);
            //Assert
            Assert.IsTrue(setGenericAbstract[0].IsSetElement);
            Assert.IsTrue(setGenericAbstract[1].IsSetElement);
            Assert.IsFalse(setGenericAbstract[1].IsSet);
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
            TestElement_Generic_decimal _elementGenericDecimal = new TestElement_Generic_decimal();
            TestSet_Abstract _setNonGeneric = new TestSet_Abstract();
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
        public void TestSetFactorySanity()
        {
            var testSet2 = SetFactory.CreateSet<TestSetOnlyElement,TestElement_Abstract>(null);
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
            TestElement_Abstract _elementAbstract = new TestElement_Abstract();
            TestSetOnlyElement _setOnlyElement = new TestSetOnlyElement();
            
            _setOnlyElement.AddMember(_elementAbstract);
            
            Assert.IsTrue(_setOnlyElement.ContainsMember(_elementAbstract).contains);
            Assert.IsFalse(_setOnlyElement.ContainsMember(new TestElement_Abstract() { Value = 122 }).contains);
        }
    }
}