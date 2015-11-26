using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Company_Hierarchy.Persons
{
    using Enumerations;
    using Projects_and_Sales;
    using Interfaces;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(string firstName, string lastName, int id,
            decimal salary, Department department, params Sale[] sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.sales = new List<Sale>();
            foreach (Sale sale in sales)
            {
                this.Sales.Add(sale);
            }
        }

        public List<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            List<string> sales = new List<string>();
            foreach (Sale sale in this.Sales)
            {
                sales.Add(sale.ToString());
            }

            output.AppendFormat("{0}-Projects:{0}{1}", Environment.NewLine, String.Join("\n", sales));

            return output.ToString();
        }
    }
}
