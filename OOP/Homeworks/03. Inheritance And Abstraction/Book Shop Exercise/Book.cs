using System;
using System.Text;

namespace Book_Shop_Exercise
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Title cannot be empty");
                }
                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Author cannot be empty");
                }
                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("-Type: {0}{1}", this.GetType().Name, Environment.NewLine);
            output.AppendFormat("-Title: {0}{1}", this.Title, Environment.NewLine);
            output.AppendFormat("-Author: {0}{1}", this.Author, Environment.NewLine);
            output.AppendFormat("-Price: {0}{1}", this.Price, Environment.NewLine);

            return output.ToString();
        }
    }
}
