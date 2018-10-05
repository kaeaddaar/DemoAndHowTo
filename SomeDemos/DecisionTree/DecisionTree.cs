using System;
using System.Collections.Generic;

namespace libDecisionTree
{
    public class DecisionTree : SampleNode
    {
        
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Predicate<T> Condition()
        {
            return ((T data) => { return true; });
        }

        public HashSet<Node<T>> Children {get; set;}
    }

    public class SampleNode : Node<int>
    {
        new public HashSet<SampleNode> Children { get; set; }
    }
}
