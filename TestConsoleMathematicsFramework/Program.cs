using MathematicsFramework;
using System;

namespace TestConsoleMathematicsFramework
{
    class Program
    {
        private class TestMathSet : MathSet<SetMember> { }
        private class TestElement : SetElement<int> { }
        static void Main(string[] args)
        {
            TestMathSet testMathSet = new TestMathSet();
            testMathSet.AddMember(new TestElement());
            var result=  testMathSet[0];
        }
    }
}
