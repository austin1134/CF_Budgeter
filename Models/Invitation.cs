using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public int HouseholdId { get; set; }
        public bool Joined { get; set; }

        public virtual Household Household { get; set; }
    }
}