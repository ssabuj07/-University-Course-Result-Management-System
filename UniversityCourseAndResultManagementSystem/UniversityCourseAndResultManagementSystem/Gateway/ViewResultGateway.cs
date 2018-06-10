using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class ViewResultGateway:Gateway
    {
        public List<ViewResult> GetAllStudentResults()
        {
            Query = "select c.Code,c.Name, e.CourseId, e.StudentId,s.Grade from EnrollCourse_tb as e left join StudentResult_tb as s on e.CourseId = s.CourseId left join Course_tb as c on e.CourseId = c.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewResult> viewResults = new List<ViewResult>();
            while (Reader.Read())
            {
                ViewResult viewResult = new ViewResult
                {
                    StudentId = (int)Reader["StudentId"],
                    CourseCode = Reader["Code"].ToString(),
                    CourseName = Reader["Name"].ToString(),
                    Grade = Reader["Grade"].ToString()
                };
                if (viewResult.Grade == "")
                {
                    viewResult.Grade = "Not Graded Yet";
                }
                viewResults.Add(viewResult);
            }
            Reader.Close();
            Connection.Close();
            return viewResults;
        }
    }
}