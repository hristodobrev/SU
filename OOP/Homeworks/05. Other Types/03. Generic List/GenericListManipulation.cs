namespace _03.Generic_List
{
    using System;

    class GenericListManipulation
    {
        static void Main()
        {
            GenericList<string> glist = new GenericList<string>();
            glist.Add("First");
            glist.Add("Second");
            glist.Add("Third");
            glist.Add("Pesho");
            glist.Add("Gosho");
            glist.Add("Tosho");

            glist.Insert(0, "Purvi Pesho");

            Console.WriteLine(glist);
            Console.WriteLine("Index of \"Second\": {0}", glist.IndexOf("Second"));
            Console.WriteLine("Does contain \"Toshkata\": {0}", glist.Contains("Toshkata"));
            Console.WriteLine("Does contain \"Pesho\": {0}", glist.Contains("Pesho"));

            Console.WriteLine();

            glist.Remove(2);
            glist.Remove(2);

            Console.WriteLine(glist);
            Console.WriteLine("Min Value: {0}", glist.Min());
            Console.WriteLine("Max Value: {0}", glist.Max());

            glist.Clear();

            Console.WriteLine(glist);
        }
    }
}
