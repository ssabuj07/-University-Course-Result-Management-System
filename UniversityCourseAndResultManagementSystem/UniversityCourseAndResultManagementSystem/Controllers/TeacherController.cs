using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        //public ActionResult Index()
        //{
        //    return View();
        //}

        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherManager aTeacherManager = new TeacherManager();
        AssignCourseManager aAssignCourseManager = new AssignCourseManager();
        CourseManager aCourseManager = new CourseManager();

        
        public JsonResult GetAllTeachersByDepartmentId(int departmentId)
        {
            var teachers = aTeacherManager.GetAllTeachers();
            var teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList);
        }

        public JsonResult GetTeacherDetails(int teacherId)
        {
            Teacher teacher = aTeacherManager.GetAllTeachers().FirstOrDefault(c => c.Id == teacherId);
            //Department department = GetDepartments().FirstOrDefault(c => c.DepartmentId == student.DepartmentId);
            var data = new 
            {
                CreditToBeTaken = teacher.TeacherCredit,
                RemainingCredit = (teacher.TeacherCredit - teacher.TeacherTakenCredit)
                //DepartmentName = department.Name
            };

            return Json(data);
        }

        public JsonResult GetAllCousesByDepartmentId(int departmentId)
        {
            var courses = aCourseManager.GetAllCouses();
            var courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList);
        }

        public JsonResult GetCourseDetails(int courseId)
        {
            Course course = aCourseManager.GetAllCouses().FirstOrDefault(c => c.Id == courseId);
            // Department department = GetDepartments().FirstOrDefault(c => c.DepartmentId == student.DepartmentId);
            var data = new
            {
                CourseName = course.Name,
                CourseCredit = course.Credit
            };

            return Json(data);
        }

        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.message = "";
            //ViewBag.teachers = GetAllTeachersByDepartmentId(null);
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(AssignCourse assignCourse)
        {
            //CourseAssignToTeacher();
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.message = aAssignCourseManager.Save(assignCourse);
            return View();
        }

        public ActionResult CreateTeacher()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.designations = aTeacherManager.GetAllDesignations();
            return View();
        }
        //[HttpGet]

        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.designations = aTeacherManager.GetAllDesignations();

            ViewBag.message = aTeacherManager.Save(teacher);
            return View();
        }
    }
}