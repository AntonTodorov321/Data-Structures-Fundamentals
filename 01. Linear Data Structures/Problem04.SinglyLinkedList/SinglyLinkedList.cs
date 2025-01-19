namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element)
                : this(element, null) { }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            this.Count++;
        }


        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            Node node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            Node oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            else if (this.Count == 1)
            {
                Node oldHead = this.head;
                this.head = null;
                this.Count--;
                return oldHead.Element;
            }

            Node node = this.head;

            while (node.Next.Next != null)
            {
                node = node.Next;
            }

            T removedElement = node.Next.Element;
            node.Next = null;

            this.Count--;
            return removedElement;
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