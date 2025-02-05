using Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using TestComponentMathematicsFramework.SanityCheck.SetupForTests;

namespace TestComponentMathematicsFramework
{
    [TestClass]
    public class TestSet
    {
        [TestMethod]
        public void IgnoreDuplicate()
        {
            TestSet_Abstract_NonGeneric _setNonGeneric = new TestSet_Abstract_NonGeneric();
            TestSetCustomElement _setOnlyElement = new TestSetCustomElement() { Comparer=new DefaultComparer<TestElement_Abstract_NonGeneric>()};

            _setNonGeneric.AddMember(_setOnlyElement);
            var elementCount = _setNonGeneric.innerMembers.Count;
            _setNonGeneric.AddMember(_setOnlyElement);
            
            Assert.AreEqual(elementCount, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestCanOnlyAddElementRestrictedToValueType()
        {
            TestSetCustomElement _setOnlyElement = new TestSetCustomElement() { Comparer = new DefaultComparer<TestElement_Abstract_NonGeneric>() };

            _setOnlyElement.AddMember(new TestElement_Abstract_NonGeneric() { Value = new decimal() });
            
            Assert.ThrowsException<ArgumentException>(() =>
                _setOnlyElement.AddMember(new TestElement_Abstract_NonGeneric() { Value = new object() }));
        }

        [TestMethod]
        public void TestAddMemberOrSetIncreaseCountByOne()
        {
            TestSet_Abstract_NonGeneric _setNonGeneric = new TestSet_Abstract_NonGeneric();
            var countbeforeAdd = _setNonGeneric.innerMembers.Count;
            
            _setNonGeneric.AddMember(new object());
            
            Assert.AreEqual(countbeforeAdd + 1, _setNonGeneric.innerMembers.Count);
        }

        [TestMethod]
        public void TestPreventSelfReferential()
        {
            TestSet_Abstract_NonGeneric _setAbstract = new TestSet_Abstract_NonGeneric();
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
            var setGenericAbstract = new TestSetWithElementDecimal() { Comparer = new DefaultComparer<TestElement_Generic_decimal>() };
            //Act
            setGenericAbstract.AddMember(_elementDecimal);
            setGenericAbstract.AddMember(elementDecimal2);
            //Assert
            Assert.IsTrue(setGenericAbstract[0].IsSetElement);
            Assert.IsTrue(setGenericAbstract[1].IsSetElement);
            Assert.IsFalse(setGenericAbstract[0].IsSet);
            Assert.IsFalse(setGenericAbstract[1].IsSet);
        }

        [TestMethod]
        public void TestSetElementIsTrue()
        {
            var setGenericElement = new TestSetCustomElement() { Comparer = new DefaultComparer<TestElement_Abstract_NonGeneric>() };

            setGenericElement.AddMember(new TestElement_Abstract_NonGeneric() { Value = 1 });
            setGenericElement.AddMember(new TestElement_Abstract_NonGeneric() { Value = 2 });

            Assert.IsTrue(setGenericElement[0].IsSetElement);
            Assert.IsTrue(setGenericElement[1].IsSetElement);
            Assert.IsFalse(setGenericElement[0].IsSet); 
            Assert.IsFalse(setGenericElement[1].IsSet);
        }

        [TestMethod]
        public void TestCanAddRandomObjectToNongenericSet()
        {
            TestElement_Generic_decimal _elementGenericDecimal = new TestElement_Generic_decimal();
            TestSet_Abstract_NonGeneric _setNonGeneric = new TestSet_Abstract_NonGeneric();
            _setNonGeneric.AddMember(1);
            var h2 = new ArrayList();
            _setNonGeneric.AddMember("asdf");
            _setNonGeneric.AddMember(h2.Add(1));
            _setNonGeneric.AddMember(_elementGenericDecimal);
        }

        [TestMethod]
        public void TestContainsMemeber()
        {
            TestElement_Abstract_NonGeneric _elementAbstract = new TestElement_Abstract_NonGeneric();
            TestSetCustomElement _setOnlyElement = new TestSetCustomElement() { Comparer = new DefaultComparer<TestElement_Abstract_NonGeneric>() };

            _setOnlyElement.AddMember(_elementAbstract);
            
            Assert.IsTrue(_setOnlyElement.ContainsMember(_elementAbstract).contains);
            Assert.IsFalse(_setOnlyElement.ContainsMember(new TestElement_Abstract_NonGeneric() { Value = 122 }).contains);
        }
    }
}