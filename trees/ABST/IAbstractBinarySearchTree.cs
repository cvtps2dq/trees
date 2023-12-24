using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trees.ABST
{
    internal interface IAbstractBinarySearchTree <E> where E : IComparable<E>
    {
        public E GetLeftMostElement();
        void Insert(E element);
        bool Contains(E element);
        IAbstractBinarySearchTree<E> Search(E element);
        Node<E> GetRoot();
        Node<E> GetLeft();
        Node<E> GetRight();
        E GetValue();
        void Print(Node<E> root);
    }
}
