using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Invitations
    {
        public int Id { get; set; } 
        public string ToEmail { get; set; }
        public int Userid { get; set; }
        public int HouseholdId { get; set; }
        public int JoinCode { get; set; }
        public bool Joined { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Household Household { get; set; }
    }
}
