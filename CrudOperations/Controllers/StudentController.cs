using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperations.Models;
using System.Data.Entity;
using System.Data;

namespace CrudOperations.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (testEntities TESTMODEL = new testEntities())
            {
                return View(TESTMODEL.students.ToList());
            }
            
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (testEntities TESTMODEL = new testEntities()) {
                return View(TESTMODEL.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(student stud)
        {
            try
            {
                using (testEntities TESTMODEL = new testEntities())
                {
                    TESTMODEL.students.Add(stud);
                    TESTMODEL.SaveChanges();
                }


                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (testEntities TESTMODEL = new testEntities())
            {
                return View(TESTMODEL.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student s)
        {
            try
            {
                using(testEntities TESTMODEL = new testEntities())
                {
                    TESTMODEL.Entry(s).State = EntityState.Modified;
                    TESTMODEL.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (testEntities TESTMODEL = new testEntities())
            {
                return View(TESTMODEL.students.Where(x => x.idstudent == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection )
        {
            try
            {
                using (testEntities TESTMODEL = new testEntities())
                {
                    student s = TESTMODEL.students.Where(x => x.idstudent == id).FirstOrDefault();
                    TESTMODEL.students.Remove(s);
                    TESTMODEL.SaveChanges();

                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
