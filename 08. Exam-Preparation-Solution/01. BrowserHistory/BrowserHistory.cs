namespace _01._BrowserHistory
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private LinkedList<ILink> links;

        public BrowserHistory()
        {
            this.links = new LinkedList<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear()
        {
            this.links.Clear();
        }

        public bool Contains(ILink link)
        {
            return this.links.Contains(link);
        }

        public ILink DeleteFirst()
        {
            this.ValidateLinks();

            ILink deleted = this.links.Last();
            this.links.RemoveLast();
            return deleted;
        }

        public ILink DeleteLast()
        {
            this.ValidateLinks();

            ILink deleted = this.links.First();
            this.links.RemoveFirst();
            return deleted;
        }

        public ILink GetByUrl(string url)
        {
            return this.links.FirstOrDefault(link => link.Url == url);
        }

        public ILink LastVisited()
        {
            this.ValidateLinks();
            return this.links.First();
        }

        public void Open(ILink link)
        {
            this.links.AddFirst(link);
        }

        public int RemoveLinks(string url)
        {
            url = url.ToLower();
            int count = 0;

            LinkedListNode<ILink> node = this.links.First;

            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.Url.Contains(url.ToLower()))
                {
                    this.links.Remove(node);
                    count++;
                }

                node = nextNode;
            }

            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return count;
        }

        public ILink[] ToArray()
        {
            return this.links.ToArray();
        }

        public List<ILink> ToList()
        {
            return this.links.ToList();
        }

        public string ViewHistory()
        {
            if (this.links.Count == 0)
            {
                return "Browser history is empty!";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var link in this.links)
            {
                sb.AppendLine(link.ToString());
            }

            return sb.ToString();
        }

        private void ValidateLinks()
        {
            if (this.links.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
