using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using CF_Budgeter.Models;

namespace CF_Budgeter.Controllers
{
    public class AccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            var accounts = db.Accounts.Include(a => a.Household);
            return View(await accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Budget budget = new Budget();
            AccountDetailsViewModel accountDetailsViewModel = new AccountDetailsViewModel();
            var account = await db.Accounts.FindAsync(id);
            var budget = await db.Budgets.FindAsync(id);

            accountDetailsViewModel.Id = account.Id;
            accountDetailsViewModel.HouseholdId = account.HouseholdId;
            accountDetailsViewModel.Balance = account.Balance;
            accountDetailsViewModel.Name = account.Name;
            accountDetailsViewModel.ReconciledBalance = account.ReconciledBalance;
            accountDetailsViewModel.Transactions = account.Transactions;
            accountDetailsViewModel.TransactionCount = account.Transactions.Count();
            accountDetailsViewModel.TotalBudgetAmount = budget.TotalBudgetAmount;
            accountDetailsViewModel.AvailableToSpend = budget.TotalBudgetAmount - account.Balance;

            accountDetailsViewModel.createTransactionViewModel = new CreateTransactionViewModel();
            accountDetailsViewModel.createTransactionViewModel.AccountId = account.Id;
            accountDetailsViewModel.createTransactionViewModel.Categories = new SelectList(db.Categories, "Id", "Name");
            if (accountDetailsViewModel == null)
            {
                return HttpNotFound();
            }
            IEnumerable<Transaction> Transactions = accountDetailsViewModel.Transactions.OrderByDescending(t => t.Date);
            return View(accountDetailsViewModel);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HouseholdId,Balance,Name,ReconciledBalance")] Account account)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user != null)
                {
                    account.HouseholdId = user.HouseholdId;

                    db.Accounts.Add(account);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", account.HouseholdId);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", account.HouseholdId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HouseholdId,Balance,Name,ReconciledBalance")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", account.HouseholdId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Account account = await db.Accounts.FindAsync(id);
            db.Accounts.Remove(account);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
