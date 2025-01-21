namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node oldHead = this.head;
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = oldHead.Next;
                this.head.Previous = null;
            }

            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            Node oldTail = this.tail;
            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = oldTail.Previous;
                this.tail.Next = null;
            }

            this.Count--;
            return oldTail.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}