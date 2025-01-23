int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n = numbers[0];
int m = numbers[1];

if(n > m)
{
    Console.WriteLine("(no solution)");
}

Queue<Item> queue = new Queue<Item>();
queue.Enqueue(new Item(n, null));

while (queue.Count > 0)
{
    Item item = queue.Dequeue();

    if (item.Value == m)
    {
        List<int> sequence = new List<int>();

        while (item != null)
        {
            sequence.Add(item.Value);
            item = item.Previous;
        }

        sequence.Reverse();
        Console.WriteLine(string.Join(" -> ", sequence));

        return;
    }

    if (item.Value < m)
    {
        queue.Enqueue(new Item(item.Value + 1, item));
        queue.Enqueue(new Item(item.Value + 2, item));
        queue.Enqueue(new Item(item.Value * 2, item));
    }

}