namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = FindBfs(first, this);
            BinaryTree<T> secondNode = FindBfs(second, this);

            if (firstNode == null || secondNode == null)
            {
                throw new InvalidOperationException();
            }

            Queue<T> firstNodeAncestors = this.FindAncestor(firstNode);
            Queue<T> secondNodeAncestors = this.FindAncestor(secondNode);

            T current = firstNodeAncestors.Dequeue();

            while (firstNodeAncestors.Count > 0)
            {
                if (secondNodeAncestors.Contains(current))
                {
                    return current;
                }

                current = firstNodeAncestors.Dequeue();
            }

            return current;

            //return firstNodeAncestor.Intersect(secondNodeAncestor).First();
        }

        private Queue<T> FindAncestor(BinaryTree<T> root)
        {
            Queue<T> ancestors = new Queue<T>();
            BinaryTree<T> current = root;

            while (current != null)
            {
                ancestors.Enqueue(current.Value);
                current = current.Parent;
            }

            return ancestors;
        }

        private BinaryTree<T> FindBfs(T element, BinaryTree<T> root)
        {
            Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                BinaryTree<T> current = queue.Dequeue();

                if (element.Equals(current.Value))
                {
                    return current;
                }

                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return null;
        }
    }
}
