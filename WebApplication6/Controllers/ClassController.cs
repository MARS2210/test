using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using System.Data;

namespace WebApplication6.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        Database1Entities1 db = new Database1Entities1();
        public ActionResult Index()
        {
            var classes = (from clas in db.Classes select clas).ToList();
            return View(classes);
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            var classesDetails = (from clas in db.Classes
                                  where clas.IdClass == id
                                  select clas).First();
            return View(classesDetails);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            
            Classes clas = new Classes();
            return View(clas);
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(Classes clas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Classes.Add(clas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(clas);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            var classesEdit = (from clas in db.Classes
                               where clas.IdClass == id
                               select clas).First();
            return View(classesEdit);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var classesEdit = (from clas in db.Classes
                               where clas.IdClass == id
                               select clas).First();
            try
            {
                UpdateModel(classesEdit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(classesEdit);
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            var classesDelete = (from clas in db.Classes
                                 where clas.IdClass == id
                                 select clas).First();
            return View(classesDelete);
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var classesDelete = (from clas in db.Classes
                                 where clas.IdClass == id
                                 select clas).First();

            try
            {
                db.Classes.Remove(classesDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(classesDelete);
            }
        }
    }
}
