using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Home()
        {
            return View();
        }
        DepartmentManager aDepartmentManager = new DepartmentManager();
        //public string Save(Department department)
        //{
        //    return aDepartmentManager.Save(department);
        //}

        public ActionResult ViewDepartments()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            return View();
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            ViewBag.message = aDepartmentManager.Save(department);
            return View();
        }

    }
}