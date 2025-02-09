namespace Playground
{
    using _03.MinHeap;

    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Enqueue(4);
            queue.Enqueue(7);
            queue.Enqueue(2);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(8);
            queue.Enqueue(3);
            queue.Enqueue(11);
            queue.Enqueue(5);

            queue.DecreaseKey(11, 6);
        }
    }
}
