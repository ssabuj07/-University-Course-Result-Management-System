using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class AssignCourseGateway:Gateway
    {

        public int Save(AssignCourse assignCourse)
        {
            Query = "INSERT INTO AssignCourseToTeacher_tb(DepartmentId,TeacherId,CourseId,CourseCredit) VALUES(@departmentId,@teacherId,@courseId,@courseCredit)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("departmentId", assignCourse.DepartmentId);
            Command.Parameters.AddWithValue("teacherId", assignCourse.TeacherId);
            Command.Parameters.AddWithValue("courseId", assignCourse.CourseId);
            Command.Parameters.AddWithValue("courseCredit", assignCourse.CourseCredit);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsCoursedAlreadyAssigned(int courseId)
        {
            Query = "SELECT * FROM AssignCourseToTeacher_tb WHERE CourseId = '" + courseId + "' ";
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
    }
}