namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.RightChild = right;
            this.LeftChild = left;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.InOrder());
            }

            result.Add(this);

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PostOrder());
            }
            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PostOrder());
            }

            result.Add(this);
            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            result.Add(this);

            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PreOrder());
            }
            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PreOrder());
            }

            return result;
        }
    }
}
