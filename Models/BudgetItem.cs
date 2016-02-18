using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string BudgetId { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual Category Category { get; set; }
    }
}