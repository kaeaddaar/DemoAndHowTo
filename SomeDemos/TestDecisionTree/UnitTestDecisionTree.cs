using libDecisionTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace TestDecisionTree
{
    [TestClass]
    public class UnitTestDecisionTree
    {
        [TestMethod]
        public void SimpleTreeCreation()
        {
            SampleNode N = new SampleNode(0);
            N.Condition = (x) => { return true; };
            Assert.IsTrue(ExecutePredicate<int>.Exec(N.Condition, 0));
        }

        [TestMethod]
        public void NotZeroIsTrue_NodeTest()
        {
            NotZeroIsTrue N2 = new NotZeroIsTrue(0);
            Assert.IsFalse(ExecutePredicate<int>.Exec(N2.Condition, N2.Data));
            Assert.IsTrue(ExecutePredicate<int>.Exec(N2.Condition, 1));

        }

        [TestMethod]
        public void ModelANestedIf_AsAndMatrix()
        {
            //      | true | false
            //---------------------
            // true | true | false
            // false| false| false

            List<bool> lstIf = new List<bool>();
            List<bool> lstTree = new List<bool>();

            Tuple<bool, bool> TT = new Tuple<bool, bool>(true, true);
            Tuple<bool, bool> TF = new Tuple<bool, bool>(true, false);
            Tuple<bool, bool> FT = new Tuple<bool, bool>(false, true);
            Tuple<bool, bool> FF = new Tuple<bool, bool>(false, false);

            Predicate<Tuple<bool, bool>> IfVersionOfAnd = (Tuple<bool, bool> x) =>
            {
                if (x.Item1)
                {
                    if (x.Item2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (x.Item2)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                };
            };

            lstIf.Add(IfVersionOfAnd(TT));
            lstIf.Add(IfVersionOfAnd(TF));
            lstIf.Add(IfVersionOfAnd(FT));
            lstIf.Add(IfVersionOfAnd(FF));

            // build up the same thing as an expression tree
            Node<Tuple<bool, bool>> T = new Node<Tuple<bool, bool>>(TT);
            T.Condition = (Tuple<bool, bool> x) => { return x.Item1; };
            Node<Tuple<bool, bool>> TrueChild = new Node<Tuple<bool, bool>>(TT);
            TrueChild.Condition = (Tuple<bool, bool> x) => { return x.Item2; };
            TrueChild.Data = T.Data;
            Node<Tuple<bool, bool>> FalseChild = new Node<Tuple<bool, bool>>(TT);
            FalseChild.Condition = (Tuple<bool, bool> x) => { return false; };
            FalseChild.Data = T.Data;

            T.TrueChild = TrueChild;
            T.FalseChild = FalseChild;

            T.Data = TT; TrueChild.Data = TT; FalseChild.Data = TT;
            lstTree.Add(T.Eval());
            T.Data = TF; TrueChild.Data = TF; FalseChild.Data = TF;
            lstTree.Add(T.Eval());
            T.Data = FT; TrueChild.Data = FT; FalseChild.Data = FT;
            lstTree.Add(T.Eval());
            T.Data = FF; TrueChild.Data = FF; FalseChild.Data = FF;
            lstTree.Add(T.Eval());

            Assert.AreEqual(lstIf[0], lstTree[0]);
            Assert.AreEqual(lstIf[1], lstTree[1]);
            Assert.AreEqual(lstIf[2], lstTree[2]);
            Assert.AreEqual(lstIf[3], lstTree[3]);

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
