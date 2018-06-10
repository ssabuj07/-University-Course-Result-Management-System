using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class TeacherGateway:Gateway
    {
        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT * FROM Designation_tb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation designation = new Designation
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();
            return designations;
        }

        public int Save(Teacher teacher)
        {
            Connection.Close();
            Query = "INSERT INTO Teacher_tb(Name,Address,Email,Contact,TeacherCredit,DesignationId,DepartmentId) values(@name,@address,@email,@contact,@creditTaken,@designation,@department)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", teacher.Name);
            Command.Parameters.AddWithValue("address", teacher.Address);
            Command.Parameters.AddWithValue("email", teacher.Email);
            Command.Parameters.AddWithValue("contact", teacher.Contact);
            Command.Parameters.AddWithValue("designation", teacher.DesignationId);
            Command.Parameters.AddWithValue("department", teacher.DepartmentId);
            Command.Parameters.AddWithValue("creditTaken",teacher.TeacherCredit );
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsEmailExit(string email)
        {
            Query = "SELECT * FROM Teacher_tb WHERE Email = '"+email+"' ";
            Command = new SqlCommand(Query,Connection);
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

        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM Teacher_vtb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher();

                teacher.Id = (int) Reader["Id"];
                teacher.Name = Reader["Name"].ToString();
                teacher.TeacherCredit = (decimal) Reader["TeacherCredit"];
                string teacherTakenCredit = Reader["TakenCredit"].ToString();
                if (teacherTakenCredit != "")
                {
                    teacher.TeacherTakenCredit = (decimal) Reader["TakenCredit"];
                }
                else
                {
                    teacher.TeacherTakenCredit = 0;
                }
                teacher.DepartmentId = (int) Reader["DepartmentId"]; 
                teachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
    }
}