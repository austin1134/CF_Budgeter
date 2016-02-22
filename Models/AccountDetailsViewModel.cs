using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class AccountDetailsViewModel
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public decimal? ReconciledBalance { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

        public CreateTransactionViewModel createTransactionViewModel { get; set; }
    }
}