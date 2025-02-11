namespace Playground
{
    using System;
    using _04.CookiesProblem;


    class Program
    {
        static void Main(string[] args)
        {
            var queue = new CookiesProblem();
            Console.WriteLine(queue.Solve(7, new int[] { 1, 1, 1 }));
        }
    }
}
