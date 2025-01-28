namespace Tree
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

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
            return this.BfsWithResultKeys(tree => tree.children.Count > 0 && tree.Parent != null)
                .Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.BfsWithResultKeys(tree => tree.children.Count == 0)
                .Select(tree => tree.Key);
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode().Key;
        }

        public IEnumerable<T> GetLongestPath()
        {
            Tree<T> deepestNode = this.GetDeepestNode();
            Stack<T> result = new Stack<T>();
            result.Push(deepestNode.Key);

            while (deepestNode.Parent != null)
            {
                deepestNode = deepestNode.Parent;
                result.Push(deepestNode.Key);
            }

            return result;
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

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            List<Tree<T>> result = new List<Tree<T>>();

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (predicate.Invoke(subtree))
                {
                    result.Add(subtree);
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private Tree<T> GetDeepestNode()
        {
            IEnumerable<Tree<T>> leafs = this.BfsWithResultKeys(tree => tree.children.Count == 0);
            Tree<T> deepestNode = null;
            int maxDepth = 0;

            foreach (var leaf in leafs)
            {
                int depth = this.GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            Tree<T> tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }
    }
}
