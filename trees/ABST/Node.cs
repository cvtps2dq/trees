using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trees.ABST
{
    internal class Node<E>
    {
        public E Value { get; set; }
        public Node<E> LeftChild { get; set; }
        public Node<E> RightChild { get; set; }

        public Node(E value)
        {
            this.Value = value;
        }

        public Node(E value, Node<E> leftChild, Node<E> rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            Value = value;
        }

    }
}
