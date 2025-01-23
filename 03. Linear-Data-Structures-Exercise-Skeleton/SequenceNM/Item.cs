public class Item
{
    public int Value { get; set; }
    public Item Previous { get; set; }

    public Item(int number, Item previous)
    {
        this.Value = number;
        this.Previous = previous;
    }
}