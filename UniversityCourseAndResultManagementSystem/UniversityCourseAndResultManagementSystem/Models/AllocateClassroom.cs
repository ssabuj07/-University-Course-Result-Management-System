using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        //public string Ftime { get; set; }
        //public string Ttime { get; set; }
    }
}