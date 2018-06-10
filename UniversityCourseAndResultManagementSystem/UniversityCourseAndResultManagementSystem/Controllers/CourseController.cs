using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        //public ActionResult Index()
        //{
        //    return View();
        //}

        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();

        public ActionResult ViewCourseStatics()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            return View();
        }

        public JsonResult GetCourseStatics(int departmentId)
        {
            var coursesStatics = aCourseManager.GetAllCouseStatics();
            var courseStaticsList = coursesStatics.Where(a => a.DepartmentId == departmentId).ToList();
            
            return Json(courseStaticsList);
        }
        public ActionResult CreateCourse()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.semesters = aCourseManager.GetAllSemester();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.semesters = aCourseManager.GetAllSemester();
            ViewBag.message = aCourseManager.Save(course);
            return View();
        }
    }
}