using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Shop_Exercise
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {

        }

        public override decimal Price
        {
            get
            {
                return base.Price;
            }
            set
            {
                base.Price = value * 1.30m;
            }
        }
    }
}
