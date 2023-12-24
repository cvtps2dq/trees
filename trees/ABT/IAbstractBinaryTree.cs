
namespace trees.ABT
{
    public interface IAbstractBinaryTree<E>
    {
        E GetKey();
        IAbstractBinaryTree<E> GetLeft();
        IAbstractBinaryTree<E> GetRight();
        void SetKey(E key);
        String AsIndentedPreOrder(int indent);
        List<IAbstractBinaryTree<E>> PreOrder();
        List<IAbstractBinaryTree<E>> InOrder();
        List<IAbstractBinaryTree<E>> PostOrder();
        void ForEachInOrder(Action<E> action);
        void PrintTree(IAbstractBinaryTree<E> root);
        void DepthFirst(IAbstractBinaryTree<E> tree);
        void BreadthFirst();
    }
}
