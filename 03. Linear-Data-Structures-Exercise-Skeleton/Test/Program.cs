var list = new Problem02.DoublyLinkedList.DoublyLinkedList<int>();

list.AddFirst(1);
list.AddFirst(2);
list.AddFirst(3);
list.AddLast(4);

foreach (var item in list)
{
    Console.WriteLine(item);
}