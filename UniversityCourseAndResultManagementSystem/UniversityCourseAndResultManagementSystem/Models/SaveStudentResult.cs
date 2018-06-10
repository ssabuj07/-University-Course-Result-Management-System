using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class SaveStudentResult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Select Student registration Number")]
        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Select Course")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Select Grade")]
        public string Grade { get; set; }
    }
}