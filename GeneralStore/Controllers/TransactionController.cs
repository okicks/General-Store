using GeneralStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GeneralStore.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            ViewBag.ProductId = new SelectList(_db.Products.ToList(), "ProductId", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            _db.Transactions.Remove(transaction);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            ViewBag.ProductId = new SelectList(_db.Products.ToList(), "ProductId", "Name");

            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
        }

        public ActionResult MoreThan()
        {
            var purchases = _db.Transactions.SqlQuery("SELECT * From Transactions WHERE Quantity > 2").ToList();
            return View(purchases);
        }
    }
}