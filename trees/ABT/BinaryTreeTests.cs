using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace trees.ABT
{
    internal class BinaryTreeTests
    {
        public static void Test()
        {
            IAbstractBinaryTree<int> tree = new BinaryTree<int>(1);
            IAbstractBinaryTree<int> tree1 = new BinaryTree<int>(3);
            IAbstractBinaryTree<int> tree2 = new BinaryTree<int>(2, tree, tree1);

            IAbstractBinaryTree<int> tree3 = new BinaryTree<int>(5);
            IAbstractBinaryTree<int> tree4 = new BinaryTree<int>(7);
            IAbstractBinaryTree<int> tree5 = new BinaryTree<int>(6, tree3, tree4);

            IAbstractBinaryTree<int> mainTree = new BinaryTree<int>(4, tree2, tree5);
            mainTree.PrintTree(mainTree);

            Console.WriteLine("PreOrder:");
            foreach (var item in mainTree.PreOrder())
            {
                Console.WriteLine(item.GetKey());
            }

            Console.WriteLine("InOrder:");
            foreach (var item in mainTree.InOrder())
            {
                Console.WriteLine(item.GetKey());
            }

            Console.WriteLine("PostOrder:");
            foreach (var item in mainTree.PostOrder())
            {
                Console.WriteLine(item.GetKey());
            }

            Console.WriteLine("Tree structure:");
            Console.WriteLine(mainTree.AsIndentedPreOrder(1));

            Console.WriteLine("In order traversal:");
            mainTree.ForEachInOrder(action => Console.WriteLine(action + " "));
            Console.WriteLine();
            Console.WriteLine("Output in width:");
            mainTree.BreadthFirst();
            Console.WriteLine();
            Console.WriteLine("Output in depth:");
            mainTree.DepthFirst(mainTree);
        }
        
    }
}
