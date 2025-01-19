using Problem04.SinglyLinkedList;

var linkedList = new SinglyLinkedList<int>();
linkedList.AddFirst(1);
linkedList.RemoveFirst();

foreach (var item in linkedList)
{
    Console.WriteLine(item);
}

