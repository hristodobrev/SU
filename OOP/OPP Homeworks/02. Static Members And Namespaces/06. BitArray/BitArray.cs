using System;
using System.Text;

namespace _06.BitArray
{
    class BitArray
    {
        private int numberOfBits;
        private uint value;

        public BitArray(int numberOfBits)
        {
            this.NumberOfBits = numberOfBits;
            this.value = 0;
        }

        private int NumberOfBits
        {
            set
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("Number of bits must be in range [1..100 000]");
                }
                this.numberOfBits = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 99999)
                {
                    if ((this.value & (1 << index)) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }

            set
            {
                if (index < 0 || index > 99999)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException(String.Format("Value {0} is invalid!", value));
                }
                this.value &= ~((uint)(1 << index));
                this.value |= (uint)(value << index);
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
