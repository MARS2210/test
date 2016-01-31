using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using System.Data;

namespace WebApplication6.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        Database1Entities1 db = new Database1Entities1();
        public ActionResult Index()
        {
            var subjects = (from subject in db.Subjects select subject).ToList();
            return View(subjects);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            var subjectsDetails = (from subject in db.Subjects
                                   where subject.IdSubject == id
                                   select subject).First();
            return View(subjectsDetails);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            Subjects s = new Subjects();
            return View(s);
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(Subjects s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(s);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            var subjectsEdit = (from subject in db.Subjects
                                where subject.IdSubject == id
                                select subject).First();
            return View(subjectsEdit);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var subjectsEdit = (from subject in db.Subjects
                                where subject.IdSubject == id
                                select subject).First();
            try
            {
                UpdateModel(subjectsEdit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(subjectsEdit);
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            var subjectsDelete = (from subject in db.Subjects
                                  where subject.IdSubject == id
                                  select subject).First();
            return View(subjectsDelete);
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var subjectsDelete = (from subject in db.Subjects
                                  where subject.IdSubject == id
                                  select subject).First();
            try
            {
                db.Subjects.Remove(subjectsDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(subjectsDelete);
            }
        }
    }
}
