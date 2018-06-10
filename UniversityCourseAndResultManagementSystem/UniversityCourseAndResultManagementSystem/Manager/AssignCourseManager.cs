using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class AssignCourseManager
    {
        AssignCourseGateway aAssignCourseGateway = new AssignCourseGateway();
        public string Save(AssignCourse assignCourse)
        {
            if (IsCoursedAlreadyAssigned(assignCourse.CourseId))
            {
                return "Course is Already Assigned";
            }
            else if(aAssignCourseGateway.Save(assignCourse)>0)
            {
                return "Course Assigned";
            }
            else
            {
                return "Course not Assigned!";
            }
        }

        public bool IsCoursedAlreadyAssigned(int courseId)
        {
            return aAssignCourseGateway.IsCoursedAlreadyAssigned(courseId);
        }
    }
}