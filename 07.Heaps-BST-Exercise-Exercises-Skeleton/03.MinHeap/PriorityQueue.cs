namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> elements;
        private Dictionary<T, int> indexes;

        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indexes = new Dictionary<T, int>();
        }

        public int Count => this.elements.Count;

        public void Enqueue(T element)
        {
            this.elements.Add(element);
            this.indexes.Add(element, this.Count - 1);
            this.HeapifyUp(this.Count - 1);
        }

        public T Dequeue()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.Count - 1);
            this.indexes.Remove(element);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            int smallerChildIndex = this.GetSmallerChildIndex(index);

            while (IsIndexValid(smallerChildIndex) && this.IsGrater(index, smallerChildIndex))
            {
                this.Swap(smallerChildIndex, index);
                index = smallerChildIndex;
                smallerChildIndex = this.GetSmallerChildIndex(index);
            }
        }

        private bool IsGrater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGrater(parentIndex, index))
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

            this.indexes[this.elements[index]] = index;
            this.indexes[this.elements[parentIndex]] = parentIndex;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetSmallerChildIndex(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.IsGrater(secondChildIndex, firstChildIndex))
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

        public void DecreaseKey(T key)
        {
           this.HeapifyUp(this.indexes[key]);
        }

        public void DecreaseKey(T key, T newKey)
        {
            int oldIndex = this.indexes[key];
            this.elements[oldIndex] = newKey;
            this.indexes.Remove(key);
            indexes.Add(newKey, oldIndex);

            this.HeapifyUp(oldIndex);
        }
    }
}
