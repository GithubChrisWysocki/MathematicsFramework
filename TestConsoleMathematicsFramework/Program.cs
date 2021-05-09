using MathematicsFramework;
using System;

namespace TestConsoleMathematicsFramework
{
    class Program
    {
        private class TestSet : Set<SetMember> { }
        private class TestElement : SetElement<int> { }
        static void Main(string[] args)
        {
            TestSet testSet = new TestSet();
            testSet.AddMember(new TestElement());
            var result=  testSet[0];
        }
    }
}
