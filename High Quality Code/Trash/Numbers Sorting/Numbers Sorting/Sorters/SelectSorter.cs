using Numbers_Sorting.Interfaces;

namespace Numbers_Sorting.Sorters
{
    public class SelectSorter : ISorter
    {
        public void Sort(int[] numbers)
        {
            int length = numbers.Length;
            for (int currentIndex = 0; currentIndex < length - 1; currentIndex++)
            {
                for (int movingIndex = currentIndex; movingIndex < length; movingIndex++)
                {
                    if (numbers[currentIndex] > numbers[movingIndex])
                    {
                        int oldValue = numbers[currentIndex];
                        numbers[currentIndex] = numbers[movingIndex];
                        numbers[movingIndex] = oldValue;
                    }
                }
            }
        }
    }
}
