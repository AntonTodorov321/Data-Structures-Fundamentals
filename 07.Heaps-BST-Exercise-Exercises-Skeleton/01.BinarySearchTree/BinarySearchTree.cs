﻿namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if(this.root == null)
            {
                throw new InvalidOperationException();
            }

            if(root.Count == 1)
            {
                this.root = null;
            }


            Node node = this.FindElement(element);
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(root);
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        public int Rank(T element)
        {
            return this.Rank(this.root, element);
        }

        public T Select(int rank)
        {
            Node node = this.Select(this.root, rank);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public T Ceiling(T element)
        {
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return this.Select(this.Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            List<T> collection = new List<T>();
            this.Range(this.root, startRange, endRange, collection);

            return collection;
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private void Range(Node node, T startRange, T endRange, List<T> collection)
        {
            if (node == null)
            {
                return;
            }

            bool nodeInLowerRange = startRange.CompareTo(node.Value) < 0;
            bool nodeInUpperRange = endRange.CompareTo(node.Value) > 0;

            if (nodeInLowerRange)
            {
                this.Range(node.Left, startRange, endRange, collection);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                collection.Add(node.Value);
            }

            if (nodeInUpperRange)
            {
                this.Range(node.Right, startRange, endRange, collection);
            }
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
            return node;
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(node.Left, rank);
            }
            else
            {
                return this.Select(node.Right, rank - (leftCount + 1));
            }
        }

        private int Rank(Node node, T element)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.Count(node.Left) + this.Rank(node.Right, element);
            }

            return this.Count(node.Left);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = 1 + this.Count(node.Right) + this.Count(node.Left);
            return node;
        }
    }
}
