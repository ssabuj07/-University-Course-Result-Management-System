using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        DepartmentManager aDepartmentManager = new DepartmentManager();
        RoomManager aRoomManager = new RoomManager();
        TeacherManager aTeacherManager = new TeacherManager();
        AssignCourseManager aAssignCourseManager = new AssignCourseManager();
        CourseManager aCourseManager = new CourseManager();
        public ActionResult AllocateClassrooms()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.rooms = aRoomManager.GetAllRooms();
            ViewBag.days = aRoomManager.GetDays();
            ViewBag.message = "";
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassrooms(AllocateClassroom allocateClassroom)
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            ViewBag.rooms = aRoomManager.GetAllRooms();
            ViewBag.days = aRoomManager.GetDays();
            //string fromTime = allocateClassroom.FromTime.ToShortTimeString();

            

            //string toTime = allocateClassroom.ToTime.ToShortTimeString();
            //DateTime t = DateTime.Parse(toTime);
            //allocateClassroom.Ttime = toTime;
            //allocateClassroom.Ftime = fromTime;

            //DateTime time = DateTime.Parse("6/22/2009 09:30AM");
            //DateTime compare = DateTime.Parse(time.ToShortDateString() + " 2:00PM");
            //bool greater = (time < compare);


            //TimeSpan t1 = allocateClassroom.FromTime.TimeOfDay;
            //TimeSpan t2 = time.TimeOfDay;

            //int com = TimeSpan.Compare(t1, t2);


            //DateTime time1 = DateTime.Parse("6/21/2009 10:00AM");
            //DateTime compare1 = DateTime.Parse("5/23/2009 10:00PM");
            //bool greater1 = (time > compare);

            //DateTime time2 = DateTime.Parse("5/21/2009 10:00AM");
            //DateTime compare2 = DateTime.Parse("5/21/2009 10:00AM");
            //bool greater2 = (time == compare);

            //dt.ToString("HH:mm"); // 07:00 // 24 hour clock // hour is always 2 digits



            //if (allocateClassroom.FromTime>allocateClassroom.ToTime)
            //{
            //    Response.Write("totime");
            //    //Console.WriteLine("tym_one is before tym_two");
            //}
            //else if (allocateClassroom.FromTime < allocateClassroom.ToTime)
            //{
            //    Response.Write("fromtime");
            //    //Console.WriteLine("tym_one is after tym_two");
            //}
            //else
            //{
            //    Response.Write("same");
            //    //Console.WriteLine("tym_one is the same as tym_two");
            //}
            ViewBag.message = aRoomManager.AllocateRoom(allocateClassroom);
            return View();
        }


        public ActionResult ViewClassSchedule()
        {
            ViewBag.departments = aDepartmentManager.ViewAllDepartments();
            return View();
        }

        public JsonResult GetAllCousesByDepartmentId(int departmentId)
        {
            //List<ClassSchedule> classSchedules = aRoomManager.GetClassScheduleByDepartment(departmentId);
            var classSchedules = aRoomManager.GetClassScheduleByDepartment(departmentId);
            foreach (ClassSchedule classSchedule in classSchedules)
            {
                classSchedule.ScheduleInfo = aRoomManager.GetAllScheduleInfoByCourseId(classSchedule.CourseId);
            }
            //Department department = aDepartmentManager.ViewAllDepartments().FirstOrDefault(c => c.Id == student.DepartmentId);
            //var data = new
            //{
            //    StudentName = student.Name,
            //    StudentEmail = student.Email,
            //    StudentDepartment = department.Name

            //    //DepartmentName = department.Name
            //};
            return Json(classSchedules);
        }
    }
}