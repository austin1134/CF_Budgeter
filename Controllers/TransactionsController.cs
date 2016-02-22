using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using CF_Budgeter.Models;
using Microsoft.AspNet.Identity;

namespace CF_Budgeter.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            return View(await db.Transactions.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create(int accountId)
        {
            CreateTransactionViewModel createTransactionViewModel = new CreateTransactionViewModel();

            createTransactionViewModel.AccountId = accountId;
            createTransactionViewModel.Categories = new SelectList(db.Categories, "Id", "Name");

            return View(createTransactionViewModel);
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [RequireHttps]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,AccountId,Description,Date,Amount,TransactionTypeId,CategoryId,Reconciled,ReconciledAmount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                if (user != null)

                {
                    transaction.AccountId = user.HouseholdId;
                    //transaction.Date = DateTimeOffset.Now;
                    ////transaction.CategoryId =  ;
                    //transaction.TransactionTypeId = transaction.TransactionTypeId;

                    db.Transactions.Add(transaction);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name", transaction.Category);

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", transaction.AccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,AccountId,Description,Date,Amount,TransactionTypeId,CategoryId,Reconciled,ReconciledAmount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", transaction.AccountId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", transaction.CategoryId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction transaction = await db.Transactions.FindAsync(id);
            db.Transactions.Remove(transaction);
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
