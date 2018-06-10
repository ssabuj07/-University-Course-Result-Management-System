using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Student
    {
        public int  Id { get; set; }
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Contact")]
        public string Contact { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please enter Contact")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }
       
    }
}