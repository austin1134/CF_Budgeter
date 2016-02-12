using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_Budgeter.Models
{
    public class Category
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Households { get; set; }
        public int Transactions { get; set; }

        public virtual ICollection<Category>Categories { get; set; } 
    }
}