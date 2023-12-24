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
                ix = 0;
                foreach(IAbstractBinaryTree<E> x in level)
                {
                    if(x == null)
                    {
                        line.Add(null);
                        next.Add(null);
                        next.Add(null);
                    }
                    else
                    {
                        string temp = x.GetKey().ToString();
                        line.Add(temp);
                        if (temp.Length > widest) widest = temp.Length;
                        next.Add(x.GetLeft());
                        next.Add(x.GetRight());
                        if (x.GetLeft() != null || x.GetRight != null) ix++;
                    }
                }
                if (widest % 2 == 1) widest++;
                lines.Add(line);
                (next, level) = (level, next);
                next.Clear();
            }

            int piece = lines.ElementAt(lines.Count() - 1).Count() * (widest + 4);
            for (int i = 0; i < lines.Count(); i++)
            {
                List<string> line = lines.ElementAt(i);
                int hpw = (int)Math.Floor(piece / 2.0) - 1;
                if (i > 0)
                {
                    for (int j = 0; j < line.Count(); j++)
                    {
                        char c = ' ';
                        if(j % 2 == 1)
                        {
                            if (line.ElementAt(j - 1) != null)
                            {
                                c = (line.ElementAt(j) != null) ? '┴' : '┘';
                            }

                            else if (j < line.Count() && line.ElementAt(j) != null) c = '└';
                        }

                        Console.Write(c);

                        if (line.ElementAt(j) == null)
                        {
                            for (int k = 0; k < piece - 1; k++)
                            {
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            for(int k = 0; k < hpw; k++)
                            {
                                Console.Write(j % 2 == 0 ? " " : "─");
                            }

                            Console.Write(j % 2 == 0 ? "┌" : "┐");

                            for(int k = 0; k < hpw; k++)
                            {
                                Console.Write(j % 2 == 0 ? "─" : " ");
                            }
                        }
                    }

                    Console.WriteLine();
                    
                }

                for (int z = 0; z < line.Count(); z++)
                {
                    if (line.ElementAt(z) == null) line[z] = "";
                    int gap1 = (int)Math.Ceiling(piece / 2.0 - line.ElementAt(z).Length / 2.0);
                    int gap2 = (int)Math.Floor(piece / 2.0 - line.ElementAt(z).Length / 2.0);
                    for (int k = 0; k < gap1; k++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(line.ElementAt(z));

                    for (int k = 0; k < gap2; k++)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
                piece /= 2;
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
