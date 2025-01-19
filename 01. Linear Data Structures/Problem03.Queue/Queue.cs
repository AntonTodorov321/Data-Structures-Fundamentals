namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
                : this(element, null) { }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node node = head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            Node oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public bool Contains(T item)
        {
            Node node = head;

            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}