using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityCourseAndResultManagementSystem.Manager;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        ViewResultManager aViewResultManager = new ViewResultManager();
        StudentManager aStudentManager = new StudentManager();
        public ActionResult ViewResult()
        {
            ViewBag.students = aStudentManager.GetAllStudent();
            return View();
        }

        public JsonResult GetStudentsByDepartmentId(int studentId)
        {
            var result = aViewResultManager.GetAllStudentResults();
            var resultList = result.Where(a => a.StudentId == studentId).ToList();
            return Json(resultList);
        }



        public FileResult CreatePdf(int studentId)
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            string strPDFFileName = string.Format("Result" + dTime.ToString("yyyyMMdd") + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(3);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF(tableLayout,studentId));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout,int studentId)
        {

            float[] headers = { 50, 24, 45 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            //var employees = aViewResultManager.GetAllStudentResults();
            var result = aViewResultManager.GetAllStudentResults();
            Student student = aStudentManager.GetAllStudent().FirstOrDefault(c => c.Id == studentId); 
            var resultList = result.Where(a => a.StudentId == studentId).ToList();
            //List<ViewResult> employees = aViewResultManager.GetAllStudentResults().ToList<ViewResult>();



            tableLayout.AddCell(new PdfPCell(new Phrase("Result Sheet", new Font(Font.FontFamily.HELVETICA, 13, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("\n", new Font(Font.FontFamily.HELVETICA, 11, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("Name: " + student.Name, new Font(Font.FontFamily.HELVETICA, 10, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("Reg. Number: " + student.RegistrationNumber, new Font(Font.FontFamily.HELVETICA, 10, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("Email: " + student.Email, new Font(Font.FontFamily.HELVETICA, 10, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            });
            tableLayout.AddCell(new PdfPCell(new Phrase("Department: " + student.DepartmentName, new Font(Font.FontFamily.HELVETICA, 10, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_LEFT
            });

            ////Add header  
            AddCellToHeader(tableLayout, "Course Code");
            AddCellToHeader(tableLayout, "Name");
            AddCellToHeader(tableLayout, "Grade");
            //AddCellToHeader(tableLayout, "City");
            //AddCellToHeader(tableLayout, "Hire Date");

            ////Add body  

            foreach (var emp in resultList)
            {

                AddCellToBody(tableLayout, emp.CourseCode);
                AddCellToBody(tableLayout, emp.CourseName);
                AddCellToBody(tableLayout, emp.Grade);
                //AddCellToBody(tableLayout, emp.City);
                //AddCellToBody(tableLayout, emp.Hire_Date.ToString());

            }

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 10, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 9, 1, iTextSharp.text.BaseColor.BLACK)))
             {
                 HorizontalAlignment = Element.ALIGN_LEFT,
                 Padding = 5,
                 BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
             });
        }
    }
}