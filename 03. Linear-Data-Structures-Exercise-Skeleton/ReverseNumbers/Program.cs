int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> reversedNumbers = new Stack<int>();

foreach (var number in numbers)
{
    reversedNumbers.Push(number);
}

Console.WriteLine(string.Join(", ", reversedNumbers));

