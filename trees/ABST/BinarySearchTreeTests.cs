using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trees.ABST
{
    internal class BinarySearchTreeTests
    {
        public static void Test()
        {
            IAbstractBinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Print(tree.GetRoot());
            Console.WriteLine("Tree contains element 4: " + tree.Contains(4));

            Console.WriteLine("Searching for element 2: ");
            IAbstractBinarySearchTree<int> temp = tree.Search(2);
            Console.WriteLine("Found. Tree hashcode: " + temp.GetHashCode());

            temp.Print(temp.GetRoot());
            Console.WriteLine();

            Console.WriteLine("Most left element: " + tree.GetLeftMostElement());

        }
    }
    
}
