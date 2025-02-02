namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input =
                 new string[] { "3 9", "3 2", "3 35", "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73", "2 5", "2 11", "2 18", "11 38", "38 87", "18 72", "35 93", "35 23", "23 19", "23 48", "93 42", "93 43", "93 44", "93 45" };

            IntegerTreeFactory factory = new IntegerTreeFactory();
            IntegerTree tree = factory.CreateTreeFromStrings(input);
            Console.WriteLine(tree.AsString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach (var subtree in tree.GetSubtreesWithGivenSum(90))
            {
                Console.WriteLine(subtree.AsString());
            }
        }
    }
}
