using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthDemo.EF;
using AuthDemo.DTOs;
using AuthDemo.Auth;


namespace AuthDemo.Controllers
{
    public class StudentController : Controller
    {
        AuthDBEntities db = new AuthDBEntities();

        public Student Convert(StudentDTO s)
        {
            return new Student()
            {
                Name = s.FName + " " + s.LName,
                Semester = s.Semester,
                Email = s.Email,
                Year = DateTime.Now.Year,
                SId = "XX-XXXXX-X"
                //SId = DateTime.Now.Year-2000+"-"+"10000"+"-"+s.Semester
            };
        }

        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentDTO());
        }
        [HttpPost]
        public ActionResult Create(StudentDTO stu)
        {
            if (ModelState.IsValid)
            {
                var efobj = Convert(stu);
                db.Students.Add(efobj);
                db.SaveChanges();
                efobj.SId = DateTime.Now.Year - 2000 + "-" + efobj.Id + "-" + efobj.Semester;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");

            }
            return View(stu);
        }

        public ActionResult List()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [AdminAccess]
        public ActionResult Delete(int id)
        {
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("List", "Student");
        }
    }
}