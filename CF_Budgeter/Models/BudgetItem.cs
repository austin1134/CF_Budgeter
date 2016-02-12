using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class BudgetItem
    {
        public BudgetItem()
        {
            this.BudgetItems = new HashSet<BudgetItem>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string Budgets { get; set; }

        public virtual ICollection<BudgetItem>BudgetItems { get; set; } 
    }
}