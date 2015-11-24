using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Shop_Exercise
{
    class BookShop
    {
        static void Main(string[] args)
        {
            Book book = new Book("bookche", "nqkuv si", 10);
            Console.WriteLine(book);

            GoldenEditionBook goldenBook = new GoldenEditionBook("golden bookche", "unknown", 22.90m);
            Console.WriteLine(goldenBook);
        }
    }
}
