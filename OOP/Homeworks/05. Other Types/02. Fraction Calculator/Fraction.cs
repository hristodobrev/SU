namespace _02.Fraction_Calculator
{
    using System;

    struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denumerator cannot be 0.");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long commonDevider = CalculateMCD(f1.Denominator, f2.Denominator);

            long numerator = ((commonDevider / f1.Denominator) * f1.numerator) + ((commonDevider / f2.Denominator) * f2.numerator);

            Fraction result = new Fraction(numerator, commonDevider);
            
            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long commonDevider = CalculateMCD(f1.Denominator, f2.Denominator);

            long numerator = ((commonDevider / f1.Denominator) * f1.numerator) - ((commonDevider / f2.Denominator) * f2.numerator);

            Fraction result = new Fraction(numerator, commonDevider);

            return result;
        }

        private static long CalculateMCD(long a, long b)
        {
            long min = a > b ? a : b;

            for (long i = min; i <= a * b; i++)
            {
                if (i % a == 0 && i % b == 0)
                {
                    min = i;
                    break;
                }
            }

            return min;
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator / this.Denominator).ToString();
        }
    }
}
