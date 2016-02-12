using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Budget
    {
        public Budget()
        {
            this.Categories = new HashSet<Category>();
            this.Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BudgetItems { get; set; }
        public int HouseholdId { get; set; }
        
        public virtual ICollection<Category> Categories { get; set; } 
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}