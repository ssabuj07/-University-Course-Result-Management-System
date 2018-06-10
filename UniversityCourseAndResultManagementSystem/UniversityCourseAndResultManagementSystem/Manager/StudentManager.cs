using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway =new StudentGateway();
        public string Save(Student student)
        {
            
            if (IsEmailExit(student.Email))
            {
                return "Email already exist!";
            }
            else
            {
                if (aStudentGateway.Save(student) > 0)
                {
                    return "Student is registered";
                }
                return "Student registration is failed!";
            }
        }

        public string SaveResult(SaveStudentResult saveStudentResult)
        {
            if (IsCourseResultExist( saveStudentResult.StudentId,saveStudentResult.CourseId))
            {
                if(aStudentGateway.UpdateResult(saveStudentResult.StudentId, saveStudentResult.Grade)>0)
                    return "Course result Updated.";
                else
                {
                    return "Not updated";
                }
            }
            else
            {
                if (aStudentGateway.SaveResult(saveStudentResult) > 0)
                {
                    return "Result saved.";
                }
                return "Result save failed!";
            }
            
        }
        public bool IsEmailExit(string email)
        {
            return aStudentGateway.IsEmailExit(email);
        }

        public bool IsCourseResultExist(int studentId, int courseId)
        {
            return aStudentGateway.IsCourseResultExist(studentId, courseId);
        }

        public List<Student> GetAllStudent()
        {
            return aStudentGateway.GetAllStudent();
        }

        public List<Grade> GetGrages()
        {
            return aStudentGateway.GetGrages();
        } 
    }
}