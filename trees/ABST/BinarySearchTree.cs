using System;

namespace trees.ABST
{
    internal class BinarySearchTree<E> : IAbstractBinarySearchTree<E> where E : IComparable<E>
    {
        private Node<E> root;
        public E GetLeftMostElement()
        {
            Node<E> currentNode = GetRoot();
            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode.Value;
        }
        public bool Contains(E element)
        {
            return Search(element) != null;
        }

        public Node<E> GetLeft()
        {
            return root?.LeftChild;
        }

        public Node<E> GetRight()
        {
            return root?.RightChild;
        }

        public Node<E> GetRoot()
        {
            return root;
        }

        public E GetValue()
        {
            return root != null ? root.Value : default;
        }

        public void Insert(E element)
        {
            root = InternalInsertion(root, element);
        }

        private Node<E> InternalInsertion(Node <E> root, E element)
        {
            if (root == null) return new Node<E>(element);
            if (element.CompareTo(root.Value) < 0) root.LeftChild = InternalInsertion(root.LeftChild, element);
            else if (element.CompareTo(root.Value) > 0) root.RightChild = InternalInsertion(root.RightChild, element);
            return root;
        }

        public void Print(Node<E> root)
        {
            List<List<string>> lines = new();
            List<Node<E>> level = new() { root };
            List<Node<E>> next = new();
            int ix = 1;
            int widest = 0;
            while (ix != 0)
            {
                List<string> line = new();
                ix = 0;
                foreach (Node<E> x in level)
                {
                    if (x == null)
                    {
                        line.Add(null);
                        next.Add(null);
                        next.Add(null);
                    }
                    else
                    {
                        string temp = x.Value.ToString();
                        line.Add(temp);
                        if (temp.Length > widest) widest = temp.Length;
                        next.Add(x.LeftChild);
                        next.Add(x.RightChild);
                        if (x.LeftChild != null || x.RightChild != null) ix++;
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
                        if (j % 2 == 1)
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
                            for (int k = 0; k < hpw; k++)
                            {
                                Console.Write(j % 2 == 0 ? " " : "─");
                            }

                            Console.Write(j % 2 == 0 ? "┌" : "┐");

                            for (int k = 0; k < hpw; k++)
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

        public IAbstractBinarySearchTree<E> Search(E element)
        {
            Node<E> node = InternalSearch(root, element);
            if (node == null) return null;
            BinarySearchTree<E> tree = new();
            tree.root = node;
            return tree;
        }

        private Node<E> InternalSearch(Node<E> root, E element)
        {
            if (root == null || root.Value.Equals(element)) return root;
            return element.CompareTo(root.Value) < 0 ?
                InternalSearch(root.LeftChild, element) : InternalSearch(root.RightChild, element);
        }

        
    }
}
