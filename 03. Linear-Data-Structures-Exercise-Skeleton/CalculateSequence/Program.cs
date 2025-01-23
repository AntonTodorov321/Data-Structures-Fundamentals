int input = int.Parse(Console.ReadLine());

Queue<int> queue = new Queue<int>();

queue.Enqueue(input);

for (int i = 1; i <= 50; i++)
{
    int current = queue.Dequeue();
    Console.Write($"{current}, ");

    queue.Enqueue(current + 1);       
    queue.Enqueue(2 * current + i);  
    queue.Enqueue(current + 2);      
}
