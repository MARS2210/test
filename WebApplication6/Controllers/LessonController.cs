using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using System.Data;

namespace WebApplication6.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        Database1Entities1 db = new Database1Entities1();
        public ActionResult Index()
        {
            var lessons = (from lesson in db.Lessons select lesson).ToList();

            return View(lessons);
        }

        // GET: Lesson/Details/5
        public ActionResult Details(int id)
        {
            var lessonsDetails = (from lesson in db.Lessons
                                  where lesson.IdLesson == id
                                  select lesson).First();
            return View(lessonsDetails);
        }

        // GET: Lesson/Create
        public ActionResult Create()
        {
            Lessons lesson = new Lessons();
            return View(lesson);
        }

        // POST: Lesson/Create
        [HttpPost]
        public ActionResult Create(Lessons lesson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Lessons.Add(lesson);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(lesson);
        }

        // GET: Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            var lessonsEdit = (from lesson in db.Lessons
                               where lesson.IdLesson == id
                               select lesson).First();
            return View(lessonsEdit);
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var lessonsEdit = (from lesson in db.Lessons
                               where lesson.IdLesson == id
                               select lesson).First();
            try
            {
                UpdateModel(lessonsEdit);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(lessonsEdit);
            }
        }

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {

            var lessonsDelete = (from lesson in db.Lessons
                                 where lesson.IdLesson== id
                                 select lesson).First();
            return View(lessonsDelete);
        }

        // POST: Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var lessonsDelete = (from lesson in db.Lessons
                                 where lesson.IdLesson == id
                                 select lesson).First();

            try
            {
                db.Lessons.Remove(lessonsDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(lessonsDelete);
            }
        }
    }
}
