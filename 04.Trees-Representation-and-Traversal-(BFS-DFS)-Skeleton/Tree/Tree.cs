namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> currentChildren;
        private Tree<T> parent;
        private T value;

        public Tree(T value)
        {
            this.value = value;
            this.currentChildren = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.currentChildren.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBfs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderDfs()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
