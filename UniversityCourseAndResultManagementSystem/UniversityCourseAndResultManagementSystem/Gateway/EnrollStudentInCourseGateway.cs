using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class EnrollStudentInCourseGateway:Gateway
    {
        public int Save(EnrollStudentInCourse enrollStudentInCourse)
        {
            Query = "INSERT INTO EnrollCourse_tb (StudentId,CourseId,EnrollDate) VALUES (@studentId,@courseId,@enrollDate)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("studentId", enrollStudentInCourse.StudentId);
            Command.Parameters.AddWithValue("courseId", enrollStudentInCourse.CourseId);
            Command.Parameters.AddWithValue("enrollDate", enrollStudentInCourse.Date);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool AlreadyEnrolledInCourse(int studentId, int courseId)
        {
            Query = "SELECT * FROM EnrollCourse_tb WHERE StudentId = '" + studentId + "' AND CourseId = '" + courseId + "'  ";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;
        }

        public List<EnrollStudentInCourse> GetEnrollStudentCourses()
        {
            Query = "SELECT ec.Id,ec.CourseId,ec.StudentId,c.Name FROM EnrollCourse_tb AS ec LEFT JOIN Course_tb AS c on ec.CourseId = c.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollStudentInCourse> enrollStudentCourses = new List<EnrollStudentInCourse>();
            while (Reader.Read())
            {
                EnrollStudentInCourse enrollStudentCourse = new EnrollStudentInCourse
                {
                    Id = (int)Reader["Id"],
                    CourseName = Reader["Name"].ToString(),
                    CourseId = (int)Reader["CourseId"],
                    StudentId = (int)Reader["StudentId"],
                };
                enrollStudentCourses.Add(enrollStudentCourse);
            }
            Reader.Close();
            Connection.Close();
            return enrollStudentCourses;
        }

        public List<Course> GetCoursesOfaStudentByDepartment(int studentId)
        {
            Query =
                "select c.Id as CourseId,c.Name as CourseName from Student_tb as s left join Department_tb as d on s.DepartmentId = d.Id left join Course_tb as c on d.Id = c.DepartmentId where s.Id = '" + studentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                if (Reader["CourseName"].ToString() != "")
                {
                    course.Id = (int) Reader["CourseId"];
                    course.Name = Reader["CourseName"].ToString();

                    courses.Add(course);
                }
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
    }
}