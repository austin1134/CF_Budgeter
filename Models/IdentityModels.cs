﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CF_Budgeter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Households = new HashSet<Household>();
            this.Transactions = new HashSet<Transaction>();
        }

        public string FirstName { get; set; }
        public bool IsSelected { get; internal set; }
        public string LastName { get; set; }
        public int HouseholdId { get; set; }

        public virtual ICollection<Household> Households { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Account>Accounts { get; set; }
        public DbSet<Budget>Budgets { get; set; }
        public DbSet<BudgetItem>BudgetItems { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Household>Households { get; set; }
        public DbSet<Transaction>Transactions { get; set; }
        public DbSet<Invitations>Invitations { get; set; }
        public DbSet<TransactionType>TransactionTypes { get; set; }
        public DbSet<SendGridCredentials> SendGridCredentials { get; set; }

        //public System.Data.Entity.DbSet<CF_Budgeter.Models.AccountDetailsViewModel> AccountDetailsViewModels { get; set; }
    }
}