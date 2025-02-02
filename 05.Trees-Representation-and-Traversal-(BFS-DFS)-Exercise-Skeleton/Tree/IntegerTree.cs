namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            List<List<int>> result = new List<List<int>>();

            LinkedList<int> currentPath = new LinkedList<int>();
            currentPath.AddLast(this.Key);

            int currentSum = this.Key;
            this.Dfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int wantedSum)
        {
            List<Tree<int>> result = new List<Tree<int>>();
            IEnumerable<Tree<int>> allSubtrees = this.GetAllNodesBfs();

            foreach (var subtree in allSubtrees)
            {
                if (this.HasWantedSum(subtree, wantedSum))
                {
                    result.Add(subtree);
                }
            }

            return result;
        }

        private IEnumerable<Tree<int>> GetAllNodesBfs()
        {
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            List<Tree<int>> result = new List<Tree<int>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<int> subtree = queue.Dequeue();
                result.Add(subtree);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void Dfs
            (Tree<int> subtree,
            List<List<int>> result,
            LinkedList<int> currentPath,
            ref int currentSum,
            int wantedSum)
        {
            foreach (var child in subtree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);

                Dfs(child, result, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                result.Add(new List<int>(currentPath));
            }

            currentSum -= subtree.Key;
            currentPath.RemoveLast();
        }

        private bool HasWantedSum(Tree<int> subtree, int wantedSum)
        {
            int sum = subtree.Key;
            this.DfsGetSubtreeSum(subtree, ref sum);

            return sum == wantedSum;
        }

        private void DfsGetSubtreeSum(Tree<int> subtree, ref int sum)
        {
            foreach (var child in subtree.Children)
            {
                sum += child.Key;
                this.DfsGetSubtreeSum(child, ref sum);
            }
        }
    }
}
