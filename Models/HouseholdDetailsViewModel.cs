using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class HouseholdDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Invitations> Invitations { get; set; }

        public AccountDetailsViewModel accountDetailsViewModel { get; set; }
        public CreateTransactionViewModel createTransactionViewModel { get; set; }
    }
}