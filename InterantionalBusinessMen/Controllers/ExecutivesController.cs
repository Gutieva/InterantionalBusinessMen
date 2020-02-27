using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterantionalBusinessMen.DAL;
using InterantionalBusinessMen.Models;

namespace InterantionalBusinessMen.Controllers
{
    public class ExecutivesController : Controller
    {
        private GNBContext db = new GNBContext();

        // GET: Executives
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var executive = from s in db.Executives
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                executive = executive.Where(s => s.Transaction.Contains(searchString) || s.Rates.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    executive = executive.OrderByDescending(s => s.Rates);
                    break;
                case "Date":
                    executive = executive.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    executive = executive.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    executive = executive.OrderBy(s => s.Transaction);
                    break;
            }
            return View(executive.ToList());
        }

        // GET: Executives/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            return View(executive);
        }

        // GET: Executives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Executives/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rates,Transaction,EnrollmentDate")] Executive executive)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Executives.Add(executive);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(executive);
        }

        // GET: Executives/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            return View(executive);
        }

        // POST: Executives/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rates,Transaction,EnrollmentDate")] Executive executive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(executive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(executive);
        }

        // GET: Executives/Delete/5
        public ActionResult Delete(string id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            return View(executive);
        }

        // POST: Executives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                Executive executiveToDelete = new Executive() { ID = id };
                db.Entry(executiveToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Index");
            }
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
