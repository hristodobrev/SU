namespace Numbers_Sorting.Sorters
{
    using Numbers_Sorting.Interfaces;

    public class BubbleSorter : ISorter
    {
        public void Sort(int[] numbers)
        {
            bool swapped;
            int indexOfLastUnsortedNumber = numbers.Length;
            do
            {
                swapped = false;
                for (int index = 1; index < indexOfLastUnsortedNumber; index++)
                {
                    if (numbers[index - 1] > numbers[index])
                    {
                        int oldValue = numbers[index - 1];
                        numbers[index - 1] = numbers[index];
                        numbers[index] = oldValue;

                        swapped = true;
                    }
                }

                indexOfLastUnsortedNumber--;
            } while (swapped);
        }
    }
}
