using System;
using System.Collections.Generic;

namespace libDecisionTree
{

    public class Node<T>
    {
        public T Data { get; set; }
        public Predicate<T> Condition { get; set; }
        
        public Node(T Data)
        {
            this.Data = Data;
        }

        //public HashSet<Node<T>> Children {get; set;}
        public Node<T> TrueChild { get; set; }
        public Node<T> FalseChild { get; set; }
        public bool Eval()
        {
            if (Condition(Data))
            {
                return (TrueChild == null) ? true : TrueChild.Eval();
            }
            else
            {
                return (FalseChild == null) ? false : FalseChild.Eval();
            }
        }
    }

    public class NotZeroIsTrue : Node<int>
    {
        public NotZeroIsTrue(int Data) : base(Data)
        {
            this.Condition = (x) => { return x != 0; };
        }
    }

    public class SampleNode : Node<int>
    {
        public SampleNode(int Data) : base(Data)
        {
        }
    }
}
