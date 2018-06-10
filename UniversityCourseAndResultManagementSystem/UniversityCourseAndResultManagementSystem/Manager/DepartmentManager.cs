using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string Save(Department department)
        {
            if (IsDepartmentCodeExist(department.Code))
            {
                return "Department Code already exist!";
            }

            else if (IsDepartmentNameExist(department.Name))
            {
                return "Department name already exist!";
            }
            else
            {
                int rowAffected = aDepartmentGateway.Save(department);
                if (rowAffected > 0)
                {
                    return "Department saved";
                }
                return "Department save failed";
            }
            
        }

        public bool IsDepartmentNameExist(string departmentName)
        {
            return aDepartmentGateway.IsDepartmentNameExist(departmentName);
        }
        public bool IsDepartmentCodeExist(string departmentCode)
        {
            return aDepartmentGateway.IsDepartmentCodeExist(departmentCode);
        }

        public List<Department> ViewAllDepartments()
        {
            return aDepartmentGateway.ViewAllDepartments();
        }
    }
}