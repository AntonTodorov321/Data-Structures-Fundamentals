namespace _04.CookiesProblem
{
    using Wintellect.PowerCollections;

    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            OrderedBag<int> priorityQueue = new OrderedBag<int>();
            priorityQueue.AddMany(cookies);

            int currentSweetness = priorityQueue.GetFirst();
            int steps = 0;

            while (currentSweetness < minSweetness && priorityQueue.Count > 1)
            {
                int firstCookie = priorityQueue.RemoveFirst();
                int secondCookie = priorityQueue.RemoveFirst();
                int newCookie = firstCookie + secondCookie * 2;

                priorityQueue.Add(newCookie);
                currentSweetness = priorityQueue.GetFirst();
                steps++;
            }

            return currentSweetness < minSweetness ? -1 : steps;
        }
    }
}
