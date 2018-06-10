using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class StudentGateway:Gateway
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public int Save(Student student)
        {
            Query = "INSERT INTO Student_tb(Name,Email,Contact,Date,Address,DepartmentId,RegistrationNumber) VALUES(@name,@email,@contact,@date,@address,@departmentId,@regNumber)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", student.Name);
            Command.Parameters.AddWithValue("email", student.Email);
            Command.Parameters.AddWithValue("contact", student.Contact);
            Command.Parameters.AddWithValue("date", student.Date);
            Command.Parameters.AddWithValue("address", student.Address);
            Command.Parameters.AddWithValue("departmentId", student.DepartmentId);
            Command.Parameters.AddWithValue("regNumber", student.RegistrationNumber);
            Connection.Open();
            int rowaffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffected;
        }

        public int SaveResult(SaveStudentResult saveStudentResult)
        {
            Query = " INSERT INTO StudentResult_tb(StudentId,CourseId,Grade) VALUES(@StudentId,@CourseId,@Grade)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("StudentId", saveStudentResult.StudentId);
            Command.Parameters.AddWithValue("CourseId", saveStudentResult.CourseId);
            Command.Parameters.AddWithValue("Grade", saveStudentResult.Grade);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsEmailExit(string email)
        {
            Query = "SELECT * FROM Student_tb WHERE Email = '" + email + "' ";
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

        public int UpdateResult(int studentId, string grade)
        {
            Query = "UPDATE StudentResult_tb SET Grade ='"+grade+"' WHERE StudentId = '" + studentId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsCourseResultExist(int studentId, int courseId)
        {
            Query = "SELECT * FROM StudentResult_tb WHERE StudentId = '" + studentId + "' AND CourseId = '" + courseId + "'  ";
            Command = new SqlCommand(Query, Connection);
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
        public List<Student> GetAllStudent()
        {
            Query = "SELECT * FROM Student_tb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Contact = Reader["Contact"].ToString(),
                    Date = (DateTime)Reader["Date"],
                    Address = Reader["Address"].ToString(),
                    DepartmentId =(int) Reader["DepartmentId"],
                    RegistrationNumber = Reader["RegistrationNumber"].ToString()
                };
                Department department = aDepartmentGateway.ViewAllDepartments().FirstOrDefault( c => c.Id == student.DepartmentId);
                student.DepartmentName = department.Name;
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public List<Grade> GetGrages()
        {
            Query = "SELECT * FROM GradesName_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (Reader.Read())
            {
                Grade grade = new Grade
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()  
                };
                grades.Add(grade);
            }
            Reader.Close();
            Connection.Close();
            return grades;
        }
    }
}