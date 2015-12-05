namespace _04.Generic_List_Version
{
    using System;
    using _03.Generic_List;

    class Versions
    {
        static void Main(string[] args)
        {
            Type types = typeof(GenericList<>);
            Object[] attributes = types.GetCustomAttributes(false);

            foreach (Attribute attribute in attributes)
            {
                if (attribute is VersionAttribute)
                {
                    Console.WriteLine(((VersionAttribute)attribute).Version);
                }
            }
        }
    }
}
