using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AndersonPayEntity;
using AndersonPayContext;

namespace AndersonPay.Controllers
{
    public class AddEmployeesController : Controller
    {
        private Context db = new Context();




        // GET: AddEmployees
        public ActionResult Index()
        {
            ViewBag.CompanyName = new SelectList(db.Client, "CompanyName", "CompanyName");
            
            return View(db.Employees.ToList());
        }

        // GET: AddEmployees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EEmployee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound(); 
            }
            return View(employee);
        }

        // GET: AddEmployees/Create
        public ActionResult Create()
        {

            ViewBag.JobName = new SelectList(db.jobs, "JobName", "JobName");
            ViewBag.CompanyName = new SelectList(db.Client, "CompanyName", "CompanyName");
            return PartialView();
        }

        // POST: AddEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullName,StartDate,EndDate,JobName,CompanyName")] EEmployee employee/*, company company*/)
        {
            if (ModelState.IsValid)
            {
                //string TempData = company.CompanyName;
                //employee.CompanyName = TempData;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        // GET: AddEmployees/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.JobName = new SelectList(db.jobs, "JobName", "JobName");
            ViewBag.CompanyName = new SelectList(db.Client, "CompanyName", "CompanyName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EEmployee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return PartialView(employee);
        }

        // POST: AddEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FullName,StartDate,EndDate,JobName,CompanyName")] EEmployee employee)
        {

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: AddEmployees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EEmployee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return PartialView(employee);
        }

        // POST: AddEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EEmployee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
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
        public ActionResult List(string compName)
        {
            var results = from s in db.Employees select s;
            if (compName != null)
            {
                return PartialView(results.Where(x => x.CompanyName.StartsWith(compName)));
            }

            return PartialView(compName);
        }
    }
}