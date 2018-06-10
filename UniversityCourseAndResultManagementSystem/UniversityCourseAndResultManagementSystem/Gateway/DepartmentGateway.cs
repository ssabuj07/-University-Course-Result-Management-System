using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class DepartmentGateway:Gateway
    {
        public int Save(Department department)
        {
            Query = "INSERT INTO Department_tb (Code,Name) Values(@code,@name)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", department.Code);
            Command.Parameters.AddWithValue("name", department.Name);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsDepartmentNameExist(string departmentName)
        {
            Query = "SELECT * FROM Department_tb where Name = '" + departmentName + "'";

            Command = new SqlCommand(Query,Connection);

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
        public bool IsDepartmentCodeExist(string departmentCode)
        {
            Query = "SELECT * FROM Department_tb where Code = '" + departmentCode + "'";
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

        public List<Department> ViewAllDepartments()
        {

            Query = "SELECT * FROM Department_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments= new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        } 
    }
    
}