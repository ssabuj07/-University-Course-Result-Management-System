using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class CourseGateway:Gateway
    {
        public List<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM Semester_tb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                semesters.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }

        public List<Course> GetAllCouses()
        {
            Query = "SELECT * FROM Course_TB";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Credit = (decimal) Reader["Credit"],
                    DepartmentId = (int)Reader["DepartmentId"],
                    SemesterId = (int)Reader["SemesterId"]
                };
                courses.Add(course);

            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public int Save(Course course)
        {
            Query = "INSERT INTO Course_tb (Code,Name,Credit,Description,DepartmentId,SemesterId) values(@code,@name,@credit,@description,@departmentId,@semesterId)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code",course.Code);
            Command.Parameters.AddWithValue("name",course.Name);
            Command.Parameters.AddWithValue("credit",course.Credit);
            Command.Parameters.AddWithValue("description", course.Description);
            Command.Parameters.AddWithValue("departmentId",course.DepartmentId);
            Command.Parameters.AddWithValue("semesterId",course.SemesterId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCourseNameExist(string courseName)
        {
            Query = "SELECT * FROM Course_tb where Name = '" + courseName + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            //Connection.Close();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;

        }
        public bool IsCourseCodeExist(string courseCode)
        {
            Query = "SELECT * FROM Course_tb where Code = '" + courseCode + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }

        public List<CourseStatics> GetAllCouseStatics()
        {
            Query = "SELECT * FROM CourseStatics_vtb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStatics> coursesStatics= new List<CourseStatics>();
            while (Reader.Read())
            {
                CourseStatics courseStatics = new CourseStatics
                {
                    DepartmentId = (int) Reader["DepartmentId"],
                    Code = Reader["CourseCode"].ToString(),
                    Name = Reader["CourseName"].ToString(),
                    Semester = Reader["SemesterName"].ToString(),
                    AssignedTo = Reader["TeacherName"].ToString()

                };
                if (courseStatics.AssignedTo == "")
                {
                    courseStatics.AssignedTo = "Not Assigned Yet";
                }
                if (courseStatics.Code != "")
                {
                    coursesStatics.Add(courseStatics);
                }
            }
            Reader.Close();
            Connection.Close();
            return coursesStatics;
        } 
    }
}