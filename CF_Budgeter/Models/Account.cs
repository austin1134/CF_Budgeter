using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Account
    {
        public Account()
        {
            this.Budgets = new HashSet<Budget>();
            this.Households = new HashSet<Household>();
            this.BudgetItems = new HashSet<BudgetItem>();
        }
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public double Balance { get; set; }
        public double Transactions { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public double ReconciledBalance { get; set; }

        public virtual ICollection<Budget>Budgets { get; set; }  
        public virtual ICollection<Household>Households { get; set; } 
        public virtual ICollection<BudgetItem>BudgetItems { get; set; } 
    }
}