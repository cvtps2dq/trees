using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trees.ABT
{
    internal class BinaryTree<E> : IAbstractBinaryTree<E>
    {
        public E key;
        public IAbstractBinaryTree<E> left;
        public IAbstractBinaryTree<E> right;

        public BinaryTree(E key)
        {
            SetKey(key);
        }

        public BinaryTree(E key, IAbstractBinaryTree<E> left, IAbstractBinaryTree<E> right)
        {
            this.key = key;
            this.left = left;
            this.right = right;
        }
        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder stringBuilder = new ();
            stringBuilder.Append(string.Join("", Enumerable.Repeat("  ", indent)));
            stringBuilder.Append(key.ToString());
            stringBuilder.Append("\n");

            if(left != null)
            {
                stringBuilder.Append(left.AsIndentedPreOrder(indent + 1));
            }

            if(right != null)
            {
                stringBuilder.Append(right.AsIndentedPreOrder(indent + 1));
            }

            return stringBuilder.ToString();
        }

        public void BreadthFirst()
        {
            Queue<IAbstractBinaryTree<E>> queue = 
                new(new LinkedList<IAbstractBinaryTree<E>>());
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                IAbstractBinaryTree<E> cur = queue.Dequeue();
                Console.WriteLine(cur.GetKey());

                if (cur.GetLeft() != null)
                {
                    queue.Enqueue(cur.GetLeft());
                }

                if(cur.GetRight() != null)
                {
                    queue.Enqueue(cur.GetRight());
                }
                
            }
        }

        public void DepthFirst(IAbstractBinaryTree<E> tree)
        {
            if(tree != null)
            {
                Console.WriteLine(tree.GetKey());
                DepthFirst(tree.GetLeft());
                DepthFirst(tree.GetRight());
            }
        }

        public void ForEachInOrder(Action<E> action)
        {
            if(left != null)
            {
                left.ForEachInOrder(action);
            }

            action.Invoke(key);

            if (right != null)
            {
                right.ForEachInOrder(action);
            }
        }

        public E GetKey()
        {
            return key;
        }

        public IAbstractBinaryTree<E> GetLeft()
        {
            return left;
        }

        public IAbstractBinaryTree<E> GetRight()
        {
            return right;
        }

        public List<IAbstractBinaryTree<E>> InOrder()
        {
            List<IAbstractBinaryTree<E>> list = new();
            if(left != null)
            {
                list.AddRange(left.InOrder());
            }

            list.Add(this);

            if(right != null)
            {
                list.AddRange(right.InOrder());
            }

            return list;
        }

        public List<IAbstractBinaryTree<E>> PostOrder()
        {
            List<IAbstractBinaryTree<E>> list = new();
            if (left != null)
            {
                list.AddRange(left.PostOrder());
            }

            if (right != null)
            {
                list.AddRange(right.PostOrder());
            }

            list.Add(this);

            return list;
            
        }

        public List<IAbstractBinaryTree<E>> PreOrder()
        {
            List<IAbstractBinaryTree<E>> list = new(){this};

            if (left != null)
            {
                list.AddRange(left.PreOrder());
            }

            if (right != null)
            {
                list.AddRange(right.PreOrder());
            }

            return list;
        }

        //i am tired
        public void PrintTree(IAbstractBinaryTree<E> root)
        {
            List<List<string>> lines = new ();
            List<IAbstractBinaryTree<E>> level = new(){root};
            List<IAbstractBinaryTree<E>> next = new();
            int ix = 1;
            int widest = 0;
            while(ix != 0)
            {
                List<string> line = new ();
            }

        }

        public void SetKey(E key)
        {
            if(key != null)
            {
                this.key = key;
            }
        }
    }
}
