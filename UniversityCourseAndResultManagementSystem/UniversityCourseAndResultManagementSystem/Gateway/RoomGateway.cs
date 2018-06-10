using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Gateway
{
    public class RoomGateway : Gateway
    {
        public List<Room> GetAllRooms()
        {
            Query = "SELECT * FROM Room_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room()
               {
                   Id = (int)Reader["Id"],
                   Name = Reader["Name"].ToString(),
               };
                rooms.Add(room);
            }
            Reader.Close();
            Connection.Close();
            return rooms;
        }

        public List<Days> GetDays()
        {
            Query = "SELECT * FROM Day_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Days> dayses = new List<Days>();
            while (Reader.Read())
            {
                Days day = new Days()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                };
                dayses.Add(day);
            }
            Reader.Close();
            Connection.Close();
            return dayses;
        }

        public int AllocateRoom(AllocateClassroom allocateClassroom)
        {
            Query = "INSERT INTO AllocateRoom_tb(DepartmentId,CourseId,RoomId,DayId,FromTime,ToTime) VALUES(@DepartmentId,@CourseId,@RoomId,@DayId,@FromTime,@ToTime)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("DepartmentId", allocateClassroom.DepartmentId);
            Command.Parameters.AddWithValue("CourseId", allocateClassroom.CourseId);
            Command.Parameters.AddWithValue("RoomId", allocateClassroom.RoomId);
            Command.Parameters.AddWithValue("DayId", allocateClassroom.DayId);
            Command.Parameters.AddWithValue("FromTime", allocateClassroom.FromTime);
            Command.Parameters.AddWithValue("ToTime", allocateClassroom.ToTime);
            //Command.Parameters.AddWithValue("Ftime", allocateClassroom.Ftime);
            //Command.Parameters.AddWithValue("Ttime", allocateClassroom.Ttime);
            Connection.Open();
            int rowaffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffected;
        }

        public List<AllocateClassroom> IsRoomAlreadyAllocated(int dayId, int roomId)
        {
            Query = "SELECT * FROM AllocateRoom_tb WHERE DayId = '" + dayId + "' AND RoomId = '" + roomId + "'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AllocateClassroom> classrooms = new List<AllocateClassroom>();
            
                while (Reader.Read())
                {
                    AllocateClassroom allocateClassroom = new AllocateClassroom();
                    allocateClassroom.FromTime = (DateTime) (Reader["FromTime"]);
                    allocateClassroom.ToTime = (DateTime) (Reader["ToTime"]);
                    //allocateClassroom.Ftime = Reader["Ftime"].ToString();
                    //allocateClassroom.Ttime = Reader["Ttime"].ToString();
                    classrooms.Add(allocateClassroom);
                }
            

            Reader.Close();
            Connection.Close();
            return classrooms;

        }

        public List<ClassSchedule> GetClassScheduleByDepartment(int departmentId)
        {
            Query = "SELECT * FROM Course_tb WHERE DepartmentId = '"+departmentId+"'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassSchedule> classSchedules = new List<ClassSchedule>();
            while (Reader.Read())
            {
                ClassSchedule classSchedule = new ClassSchedule();
                classSchedule.CourseCode = Reader["Code"].ToString();
                classSchedule.CourseName = Reader["Name"].ToString();
                classSchedule.CourseId = (int) Reader["Id"];
                //string scheduleInfo = GetAllScheduleInfoByCourseId(classSchedule.CourseId);
               // classSchedule.ScheduleInfo = scheduleInfo;
                classSchedules.Add(classSchedule);
            }
            Reader.Close();
            Connection.Close();
            return classSchedules;
        }

        public string GetAllScheduleInfoByCourseId(int courseId)
        {
            //Reader.Close();
            //Connection.Close();
            Query = "SELECT * FROM AllocateRoom_vtb WHERE CourseId = '" + courseId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string scheduleInfo = String.Empty;
            while (Reader.Read())
            {
                scheduleInfo += "R. No :" + Reader["RoomNo"].ToString() + ", " + Reader["DayName"].ToString()+", "+
                               Reader["FromTime"].ToString() + " - " + Reader["ToTime"].ToString() + "<br/>";
            }
            if (scheduleInfo == "")
            {
                scheduleInfo = "Not Scheduled Yet";
            }
            Reader.Close();
            Connection.Close();
            return scheduleInfo;
        }

    }
}