using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class EnrollStudentInCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select a Student Registration Number")]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Select Course")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Select Date")]
        public DateTime Date { get; set; }
        public string StudentRegNumber { get; set; }
       
       
    }
}