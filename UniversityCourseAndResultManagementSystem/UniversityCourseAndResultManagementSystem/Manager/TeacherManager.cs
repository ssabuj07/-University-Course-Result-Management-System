using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class TeacherManager
    {

        TeacherGateway aTeacherGateway = new TeacherGateway();
        public List<Designation> GetAllDesignations()
        {
            return aTeacherGateway.GetAllDesignations();
        }

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        }



        public string Save(Teacher teacher)
        {
            if (IsEmailExit(teacher.Email))
            {
                return "Email already exist!";
            }
            else
            {
                if (aTeacherGateway.Save(teacher) > 0)
                {
                    return "Teacher Saved";
                }
                return "Teacher Save failed!";
            }
        }

        public bool IsEmailExit(string email)
        {
            return aTeacherGateway.IsEmailExit(email);
        }
    }
}