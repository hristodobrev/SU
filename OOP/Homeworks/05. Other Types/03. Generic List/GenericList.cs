namespace _03.Generic_List
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T>
        where T : IComparable<T>
    {
        private int index = 0;
        private T[] array;

        public GenericList(int size = 16)
        {
            this.array = new T[size];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.index)
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} is invalid.", index));
                }
                return this.array[index];
            }

            set
            {
                if (index < 0 || index >= this.index)
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} is invalid.", index));
                }
                this.array[index] = value;
            }
        }

        public int Length
        {
            get { return this.index; }
        }

        public void Add(T element)
        {
            this.CheckSize();

            this.array[this.index] = element;

            this.index++;
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);

            for (int i = index + 1; i <= this.index; i++)
            {
                this.array[i - 1] = this.array[i];
            }

            this.index--;
        }

        public void Insert(int index, T element)
        {
            this.CheckSize();
            this.ValidateIndex(index);

            for (int i = this.index; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
            this.array[index] = element;

            this.index++;
        }

        public void Clear()
        {
            this.array = new T[16];
            this.index = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.index; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T Max()
        {
            T max = this.array[0];
            for (int i = 1; i < this.index; i++)
            {
                if (this.array[i].CompareTo(max) > 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public T Min()
        {
            T min = this.array[0];
            for (int i = 1; i < this.index; i++)
            {
                if (this.array[i].CompareTo(min) < 0)
                {
                    min = this.array[i];
                }
            }

            return min;
        }

        private void CheckSize()
        {
            if (this.index == this.array.Length - 1)
            {
                T[] newArray = new T[this.array.Length * 2];
                for (int i = 0; i < this.array.Length; i++)
                {
                    newArray[i] = this.array[i];
                }

                this.array = newArray;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.index)
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is invalid.", index));
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(this.array[0]);
            for (int i = 1; i < this.index; i++)
            {
                output.Append(", " + this.array[i]);
            }

            return output.ToString();
        }
    }
}
