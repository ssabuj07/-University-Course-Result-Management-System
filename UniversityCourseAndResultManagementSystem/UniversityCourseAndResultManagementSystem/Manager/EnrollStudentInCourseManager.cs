using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
     
    public class EnrollStudentInCourseManager
    {
        EnrollStudentInCourseGateway aEnrollStudentInCourseGateway = new EnrollStudentInCourseGateway();
        public string Save(EnrollStudentInCourse enrollStudentInCourse)
        {
            if (AlreadyEnrolledInCourse(enrollStudentInCourse.StudentId, enrollStudentInCourse.CourseId))
            {
                return "Student has already been enrolled the Course.";
            }
            else
            {
                if (aEnrollStudentInCourseGateway.Save(enrollStudentInCourse) > 0)
                {
                    return "Course is Enrolled.";
                }
                return "Course enroll failed!";
            }
        }

        public bool AlreadyEnrolledInCourse(int studentId, int courseId)
        {
            return aEnrollStudentInCourseGateway.AlreadyEnrolledInCourse(studentId,courseId);
        }

        public List<EnrollStudentInCourse> GetEnrollStudentCourses()
        {
            return aEnrollStudentInCourseGateway.GetEnrollStudentCourses();
        }

        public List<Course> GetCoursesOfaStudentByDepartment(int studentId)
        {
            return aEnrollStudentInCourseGateway.GetCoursesOfaStudentByDepartment(studentId);
        }
    }
}