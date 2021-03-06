USE [master]
GO
/****** Object:  Database [CourseAndResultMS_DB]    Script Date: 6/6/2018 11:23:10 AM ******/
CREATE DATABASE [CourseAndResultMS_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseAndResultMS_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CourseAndResultMS_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CourseAndResultMS_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CourseAndResultMS_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CourseAndResultMS_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseAndResultMS_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseAndResultMS_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseAndResultMS_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CourseAndResultMS_DB', N'ON'
GO
USE [CourseAndResultMS_DB]
GO
/****** Object:  Table [dbo].[AllocateRoom_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateRoom_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromTime] [datetime] NOT NULL,
	[ToTime] [datetime] NOT NULL,
 CONSTRAINT [PK_AllocateRoom_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignCourseToTeacher_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignCourseToTeacher_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[CourseCredit] [numeric](3, 2) NOT NULL,
 CONSTRAINT [PK_AssignCourseToTeacher_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Credit] [numeric](3, 2) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Day_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day_tb](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Day_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](7) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollDate] [date] NOT NULL,
 CONSTRAINT [PK_EnrollCourse_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GradesName_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradesName_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](5) NOT NULL,
 CONSTRAINT [PK_GradesName_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](15) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResult_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentResult_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [varchar](3) NOT NULL,
 CONSTRAINT [PK_StudentResult_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher_tb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [int] NOT NULL,
	[TeacherCredit] [numeric](5, 2) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DesignationId] [int] NOT NULL,
 CONSTRAINT [PK_Teacher_tb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[TeacherTakenCredit_vtb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TeacherTakenCredit_vtb] AS
SELECT TeacherId, SUM(CourseCredit) AS TakenCredit FROM AssignCourseToTeacher_tb GROUP BY TeacherId;
GO
/****** Object:  View [dbo].[Teacher_vtb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Teacher_vtb] as
select * from Teacher_tb as t left join TeacherTakenCredit_vtb as ttc on t.Id = ttc.TeacherId
GO
/****** Object:  View [dbo].[AllocateRoom_vtb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AllocateRoom_vtb] 
AS
SELECT AR.DepartmentId, AR.CourseId, R.Name AS RoomNo,D.Name AS DayName, RIGHT(Convert(VARCHAR(20), FromTime,100),7) as FromTime, 
       RIGHT(Convert(VARCHAR(20), ToTime,100),7) as ToTime
FROM AllocateRoom_tb AS AR LEFT JOIN Room_tb AS R ON AR.RoomId= R.Id LEFT JOIN Day_tb AS D ON AR.DayId = D.Id;

GO
/****** Object:  View [dbo].[CourseStatics_vtb]    Script Date: 6/6/2018 11:23:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseStatics_vtb] 
as
select D.Id as DepartmentId, c.code AS CourseCode,c.Name AS CourseName,s.Name as SemesterName,t.Name as TeacherName from Department_tb as d left join Course_tb as c on d.Id = c.DepartmentId left join Semester_tb as s on c.SemesterId = s.Id left join AssignCourseToTeacher_tb as ac on c.Id = ac.CourseId left join Teacher_tb as t on ac.TeacherId=t.Id
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course_tb] ON [dbo].[Course_tb]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_tb_1]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course_tb_1] ON [dbo].[Course_tb]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department_tb] ON [dbo].[Department_tb]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_tb_1]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department_tb_1] ON [dbo].[Department_tb]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Student_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student_tb] ON [dbo].[Student_tb]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teacher_tb]    Script Date: 6/6/2018 11:23:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher_tb] ON [dbo].[Teacher_tb]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourseToTeacher_tb_Course_tb] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course_tb] ([Id])
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb] CHECK CONSTRAINT [FK_AssignCourseToTeacher_tb_Course_tb]
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourseToTeacher_tb_Department_tb] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department_tb] ([Id])
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb] CHECK CONSTRAINT [FK_AssignCourseToTeacher_tb_Department_tb]
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourseToTeacher_tb_Teacher_tb] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher_tb] ([Id])
GO
ALTER TABLE [dbo].[AssignCourseToTeacher_tb] CHECK CONSTRAINT [FK_AssignCourseToTeacher_tb_Teacher_tb]
GO
ALTER TABLE [dbo].[Course_tb]  WITH CHECK ADD  CONSTRAINT [FK_Course_tb_Department_tb] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department_tb] ([Id])
GO
ALTER TABLE [dbo].[Course_tb] CHECK CONSTRAINT [FK_Course_tb_Department_tb]
GO
ALTER TABLE [dbo].[Course_tb]  WITH CHECK ADD  CONSTRAINT [FK_Course_tb_Semester_tb] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester_tb] ([Id])
GO
ALTER TABLE [dbo].[Course_tb] CHECK CONSTRAINT [FK_Course_tb_Semester_tb]
GO
ALTER TABLE [dbo].[Student_tb]  WITH CHECK ADD  CONSTRAINT [FK_Student_tb_Department_tb] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department_tb] ([Id])
GO
ALTER TABLE [dbo].[Student_tb] CHECK CONSTRAINT [FK_Student_tb_Department_tb]
GO
ALTER TABLE [dbo].[Teacher_tb]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_tb_Department_tb] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department_tb] ([Id])
GO
ALTER TABLE [dbo].[Teacher_tb] CHECK CONSTRAINT [FK_Teacher_tb_Department_tb]
GO
USE [master]
GO
ALTER DATABASE [CourseAndResultMS_DB] SET  READ_WRITE 
GO
