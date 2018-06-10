using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public decimal TeacherCredit { get; set; }
        public decimal TeacherTakenCredit { get; set; }
    }
}