using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Manager
{
    public class RoomManager
    {
        private RoomGateway aRoomGateway = new RoomGateway();

        public List<Room> GetAllRooms()
        {
            return aRoomGateway.GetAllRooms();
        }
        public List<Days> GetDays()
        {
            return aRoomGateway.GetDays();
        }

        public string AllocateRoom(AllocateClassroom allocateClassroom)
        {
            if (IsRoomAlreadyAllocated(allocateClassroom))
            {
                return "Room is already allocated.";
            }
            else
            {
                if (aRoomGateway.AllocateRoom(allocateClassroom) > 0)
                {
                    return "Classroom Successfully allocated.";
                }
                return "Classroom allocation failed!";
            }
                
        }

        public bool IsRoomAlreadyAllocated(AllocateClassroom allocateClassroom)
        {
            TimeSpan ftime = allocateClassroom.FromTime.TimeOfDay;
            TimeSpan ttime =allocateClassroom.ToTime.TimeOfDay;

            List<AllocateClassroom> allocateClassrooms = aRoomGateway.IsRoomAlreadyAllocated(allocateClassroom.DayId, allocateClassroom.RoomId);
            foreach (AllocateClassroom classroom in allocateClassrooms)
            {
                TimeSpan aFtime = classroom.FromTime.TimeOfDay;
                TimeSpan aTtime = classroom.ToTime.TimeOfDay;
                if (TimeSpan.Compare(ftime, aFtime) >= 0 && TimeSpan.Compare(ftime, aTtime) < 0)
                {     
                        return true;   
                }
                else if (TimeSpan.Compare(ttime,aFtime)>0 && TimeSpan.Compare(ttime,aTtime)<0)
                {
                    return true;
                }
                else if (TimeSpan.Compare(ftime, aFtime) <= 0 && TimeSpan.Compare(ttime, aTtime) > 0)
                {
                    return true;
                }
                //if (allocateClassroom.FromTime >= classroom.FromTime && allocateClassroom.FromTime<classroom.ToTime)
                //{
                //    return true;
                //}
                //else if (allocateClassroom.ToTime > classroom.FromTime && allocateClassroom.ToTime < classroom.ToTime)
                //{
                //    return true;
                //}
            }
            return false;
        }

        public List<ClassSchedule> GetClassScheduleByDepartment(int departmentId)
        {
            return aRoomGateway.GetClassScheduleByDepartment(departmentId);
        }

        public string GetAllScheduleInfoByCourseId(int courseId)
        {
            return aRoomGateway.GetAllScheduleInfoByCourseId(courseId);
        }
    }
}