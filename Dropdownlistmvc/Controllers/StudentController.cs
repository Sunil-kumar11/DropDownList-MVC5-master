using Dropdownlistmvc.Data;
using Dropdownlistmvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dropdownlistmvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent StdRepository;
        private readonly IDepartment DptRepository;

        public StudentController(IStudent StdRepo, IDepartment DptRepo)
        {
            StdRepository = StdRepo;
            DptRepository = DptRepo;
        }
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> model;
           //model = StdRepository.GetStudents;
           // model.Department = DptRepository.GetDepartments;
            return View();
        }
        public ActionResult AddStudent()
        {
            Student Std=new Student();
            Std.Id = 0;
            Std.DepartmentsEnum = DptRepository.GetDepartments;
            return View("Edit",Std);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Student Std = StdRepository.GetStudent(Id);
            Std.DepartmentsEnum = DptRepository.GetDepartments;
            return View(Std);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student data)
        {
            if (ModelState.IsValid)
            {
                StdRepository.Save(data);
                TempData["message"] = "Save";
                return RedirectToAction("Index");
            }
            //Refill DropDL again 
            data.DepartmentsEnum = DptRepository.GetDepartments;
            return View(data);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
            StdRepository.Delete(Id);
            TempData["message"] = "Deleted";
            return RedirectToAction("Index");
        }
    }
}
