using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using simplecrudapp.Models;

namespace simplecrudapp.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.employees.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}