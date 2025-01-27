namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input =
                new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" };

            IntegerTreeFactory factory = new IntegerTreeFactory();
            IntegerTree tree = factory.CreateTreeFromStrings(input);
            Console.WriteLine(tree.AsString());
            Console.WriteLine(string.Join(", ", tree.GetLeafKeys()));
        }
    }
}
