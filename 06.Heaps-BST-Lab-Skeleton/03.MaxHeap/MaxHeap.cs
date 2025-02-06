namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.Remove(element);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int biggerChildIndex = this.GetBiggerChildIndex(index);

            while (IsIndexValid(biggerChildIndex) && this.IsGrater(biggerChildIndex, index))
            {
                this.Swap(biggerChildIndex, index);
                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGrater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T tepm = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = tepm;
        }

        private bool IsGrater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetBiggerChildIndex(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.IsGrater(firstChildIndex, secondChildIndex))
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }

            return -1;
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }
    }
}
