using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Transaction
    {
        public Transaction()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool Reconciled { get; set; }
        public double ReconciledAmount { get; set; }

        public virtual ICollection<Transaction>Transactions { get; set; }
    }
}