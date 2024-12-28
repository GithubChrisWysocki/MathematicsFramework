﻿using MathematicsFramework;
using System;
using MathematicsFramework.Settheory.Element;
using MathematicsFramework.Settheory.Set;

namespace TestConsoleMathematicsFramework
{
    class Program
    {
        private class TestMathSet : MathGenericSet<TestElement> { }
        private class TestElement : SetElement<int> { }
        static void Main(string[] args)
        {
            TestMathSet testMathSet = new TestMathSet();
            testMathSet.AddMember(new TestElement() { Value=1});
            testMathSet.AddMember(new TestElement() { Value = 1 });
            var result=  testMathSet[0];
        }
    }
}
