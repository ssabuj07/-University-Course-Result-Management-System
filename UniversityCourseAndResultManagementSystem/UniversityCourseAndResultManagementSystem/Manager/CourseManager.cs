using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        public List<Semester> GetAllSemester()
        {
            return aCourseGateway.GetAllSemester();
        }

        public string Save(Course course)
        {
            if (IsCourseCodeExist(course.Code))
            {
                return "Course code already exist";
            }
            else if (IsCourseNameExist(course.Name))
            {
                return "Course name already exist";
            }
            else
            {
                if (aCourseGateway.Save(course) > 0)
                {
                    return "Course saved";
                }
                return "Course save failed!";
            }
        }

        public bool IsCourseCodeExist(string courseCode)
        {
            return aCourseGateway.IsCourseCodeExist(courseCode);
        }

        public bool IsCourseNameExist(string courseName)
        {
            return aCourseGateway.IsCourseNameExist(courseName);
        }

        public List<Course> GetAllCouses()
        {
            return aCourseGateway.GetAllCouses();
        }

        public List<CourseStatics> GetAllCouseStatics()
        {
            return aCourseGateway.GetAllCouseStatics();
        } 
    }
}