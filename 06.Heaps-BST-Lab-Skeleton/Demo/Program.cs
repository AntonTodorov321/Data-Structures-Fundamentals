namespace Demo
{
    using _02.BinarySearchTree;
    using System;
    using System.Diagnostics.CodeAnalysis;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6); 
            tree.EachInOrder(x => Console.Write(x + ", "));

            tree.Search(4);
        }
    }
}