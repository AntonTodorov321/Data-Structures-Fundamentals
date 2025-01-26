namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private Tree<T> parent;
        private T value;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parentNode = this.FindNodeWithBfs(parentKey);

            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        public IEnumerable<T> OrderBfs()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            Stack<T> result = new Stack<T>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> subtree = stack.Pop();

                foreach (var child in subtree.children)
                {
                    stack.Push(child);
                }

                result.Push(subtree.value);
            }

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> nodeToBeDeleted = this.FindNodeWithBfs(nodeKey);
            if (nodeToBeDeleted == null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> parentNode = nodeToBeDeleted.parent;
            if (parentNode == null)
            {
                throw new ArgumentException();
            }

            parentNode.children.Remove(nodeToBeDeleted);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firsNode = this.FindNodeWithDfs(firstKey);
            Tree<T> secondNode = this.FindNodeWithDfs(secondKey);

            if (firsNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> parentFirstNode = firsNode.parent;
            Tree<T> parentSecondNode = secondNode.parent;

            if (parentFirstNode is null || parentSecondNode is null)
            {
                throw new ArgumentException();
            }

            int indexFirstChild = parentFirstNode.children.IndexOf(firsNode);
            int indexSecondChild = parentSecondNode.children.IndexOf(secondNode);

            parentFirstNode.children[indexFirstChild] = secondNode;
            parentSecondNode.children[indexSecondChild] = firsNode;
        }

        private Tree<T> FindNodeWithDfs(T firstKey)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                Tree<T> subtree = stack.Pop();

                if (subtree.value.Equals(firstKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    stack.Push(child);
                }
            }

            return null;
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
