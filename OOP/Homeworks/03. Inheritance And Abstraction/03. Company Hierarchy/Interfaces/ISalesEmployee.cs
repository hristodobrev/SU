using System;

namespace _03.Company_Hierarchy.Interfaces
{
    using Projects_and_Sales;
using System.Collections.Generic;
    interface ISalesEmployee
    {
        List<Sale> Sales { get; set; }
    }
}
