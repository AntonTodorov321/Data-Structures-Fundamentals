namespace Demo
{
    using _03.MaxHeap;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var heap = new MaxHeap<int>();
            heap.Add(4);
            heap.Add(7);
            heap.Add(11);
            heap.Add(18);
            heap.Add(2);
            heap.Add(5);
            heap.Add(8);
            heap.Add(1);
            heap.Add(21);

            Console.WriteLine(heap.ExtractMax());
        }
    }
}