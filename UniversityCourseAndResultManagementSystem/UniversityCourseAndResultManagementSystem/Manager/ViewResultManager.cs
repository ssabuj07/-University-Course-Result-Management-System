using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    
    public class ViewResultManager
    {
        ViewResultGateway aViewResultGateway = new ViewResultGateway();

        public List<ViewResult> GetAllStudentResults()
        {
            return aViewResultGateway.GetAllStudentResults();
        }
    }
}