using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Household
    {
        public Household()
        {
        this.Households = new HashSet<Household>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser Members { get; set; }
        public string Accounts { get; set; }
        public string Categories { get; set; }
        public string Budgets { get; set; }

        public virtual ICollection<Household>Households { get; set; } 
    }
}