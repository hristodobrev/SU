namespace Data_Structures_Tests
{
    using System;

    public class CustomStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public CustomStack(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
            this.Count = 0;
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            var element = this.elements[this.Count];
            this.elements[this.Count] = default(T);

            return element;
        }

        public T Peek()
        {
            return this.elements[this.Count - 1];
        }

        public bool Contains(T element)
        {
            bool doesExist = false;
            foreach (var el in this.elements)
            {
                if (element.Equals(el))
                {
                    doesExist = true;
                    break;
                }
            }

            return doesExist;
        }

        private void Resize()
        {
            var newElements = new T[this.Capacity*2];
            Array.Copy(this.elements, newElements, this.Capacity);

            this.elements = newElements;
            this.Capacity *= 2;
        }
    }
}
