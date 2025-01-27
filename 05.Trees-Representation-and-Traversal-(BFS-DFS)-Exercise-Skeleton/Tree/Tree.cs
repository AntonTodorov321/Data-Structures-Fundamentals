namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.children = new List<Tree<T>>();
            this.Key = key;

            foreach (var child in children)
            {
                this.children.Add(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            StringBuilder sb = new StringBuilder();
            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return this.DfsWithResultKeys(tree => tree.children.Count > 0 && tree.Parent != null);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.DfsWithResultKeys(tree => tree.children.Count == 0);
        }

        public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }

        private IEnumerable<T> DfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            List<T> result = new List<T>();

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (predicate.Invoke(subtree))
                {
                    result.Add(subtree.Key);
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
