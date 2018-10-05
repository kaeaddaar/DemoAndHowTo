using libDecisionTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace TestDecisionTree
{
    [TestClass]
    public class UnitTestDecisionTree
    {
        [TestMethod]
        public void SimpleTreeCreation()
        {
            SampleNode N = new SampleNode();
            N.Data = 0;
            Assert.IsTrue(ExecutePredicate<int>.Exec(N.Condition(), 0));
        }

    }

    public static class ExecutePredicate<T>
    {
        public static bool Exec(System.Predicate<T> ConditionToExecute, T Data)
        {
            return ConditionToExecute(Data);
        }
    }
}
