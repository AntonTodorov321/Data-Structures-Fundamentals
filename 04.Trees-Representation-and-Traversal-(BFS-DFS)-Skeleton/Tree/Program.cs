namespace Tree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(34,
                                 new Tree<int>(36,
                                    new Tree<int>(42),  
                                    new Tree<int>(3,
                                        new Tree<int>(78)
                                    )
                                 ),
                                 new Tree<int>(1),
                                 new Tree<int>(103)
                             );
        }
    }
}
