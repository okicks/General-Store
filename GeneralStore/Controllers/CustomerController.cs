using GeneralStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GeneralStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Customer customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Customer customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Customer customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return (new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }

            Customer customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}