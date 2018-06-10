using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //public ActionResult Index()
        //{
        //    return View();
        //}

        DepartmentManager aDepartmentManager =new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
        CourseManager aCourseManager = new CourseManager();
        EnrollStudentInCourseManager aEnrollStudentInCourseManager = new EnrollStudentInCourseManager();

        public JsonResult GetStudentDetails(int studentId)
        {
            Student student = aStudentManager.GetAllStudent().FirstOrDefault(c => c.Id == studentId);
            Department department = aDepartmentManager.ViewAllDepartments().FirstOrDefault(c => c.Id == student.DepartmentId);
            var data = new
            {
                StudentName = student.Name,
                StudentEmail = student.Email,
                StudentDepartment = department.Name
                //DepartmentName = department.Name
            };

            return Json(data);
        }

        public JsonResult GetAllEnrolledCousesByStudentId(int studentId)
        {
            var courses = aEnrollStudentInCourseManager.GetEnrollStudentCourses();
            var courseList = courses.Where(a => a.StudentId == studentId).ToList();
            return Json(courseList);
        }

        public JsonResult GetCoursesOfaStudentByDepartment(int studentId)
        {
            var courses = aEnrollStudentInCourseManager.GetCoursesOfaStudentByDepartment(studentId);
            return Json(courses);
        }

        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = aDepartmentManager.ViewAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            ViewBag.Departments = aDepartmentManager.ViewAllDepartments();
            student.RegistrationNumber = GetStudentRegNo(student);
            ViewBag.message = aStudentManager.Save(student);
            //if (ViewBag.message == "Student is registered")
            //{
                ViewBag.student = aStudentManager.GetAllStudent().FirstOrDefault(c => c.Email == student.Email);
            //}
            return View();
        }


        private string GetStudentRegNo(Student aStudent)
        {

            Department aDepartment = aDepartmentManager.ViewAllDepartments().FirstOrDefault(aDept => aDept.Id == aStudent.DepartmentId);
            int countDeptStd =
                aStudentManager.GetAllStudent().Count(aStd => (aStd.DepartmentId == aStudent.DepartmentId) && (aStd.Date.Year == aStudent.Date.Year)) + 1;
            int noOfZeroToBeAdded = 3 - countDeptStd.ToString().Length;
            string noOfZero = "";
            for (int i = 0; i < noOfZeroToBeAdded; i++)
            {
                noOfZero += "0";
            }
            return aDepartment.Code + "-" + aStudent.Date.Year + "-" + noOfZero + countDeptStd;
        }

        public ActionResult EnrollStudentInCourse()
        {
            ViewBag.students = aStudentManager.GetAllStudent();
            //ViewBag.courses = aCourseManager.GetAllCouses();
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult EnrollStudentInCourse(EnrollStudentInCourse enrollStudentInCourse)
        {
            ViewBag.students = aStudentManager.GetAllStudent();
            //ViewBag.courses = aCourseManager.GetAllCouses();
            ViewBag.message = aEnrollStudentInCourseManager.Save(enrollStudentInCourse);
            return View();
        }

        public ActionResult SaveStudentResult()
        {
            ViewBag.students = aStudentManager.GetAllStudent();
            ViewBag.grades = aStudentManager.GetGrages();
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudentResult(SaveStudentResult saveStudentResult)
        {
            ViewBag.students = aStudentManager.GetAllStudent();
            ViewBag.grades = aStudentManager.GetGrages();
            ViewBag.message = aStudentManager.SaveResult(saveStudentResult); 
            return View();
        }

         
    }
}