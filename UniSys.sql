USE [master]
GO
/****** Object:  Database [UniSysContext]    Script Date: 2023/10/19 9:53:56 ******/
DROP DATABASE IF EXISTS [UniSysContext]
GO
/****** Object:  Database [UniSysContext]    Script Date: 2023/10/19 9:53:56 ******/
CREATE DATABASE [UniSysContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniSysContext-2edf9bbc-3353-4827-8ebe-6af69877afc3', FILENAME = N'C:\Users\Administrator\UniSysContext-2edf9bbc-3353-4827-8ebe-6af69877afc3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniSysContext-2edf9bbc-3353-4827-8ebe-6af69877afc3_log', FILENAME = N'C:\Users\Administrator\UniSysContext-2edf9bbc-3353-4827-8ebe-6af69877afc3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
USE [UniSysContext]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTutor]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spUpdateTutor]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSubject]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spUpdateSubject]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudent]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spUpdateStudent]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateExamResult]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spUpdateExamResult]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEnrollment]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spUpdateEnrollment]
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelTutor]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spSoftDelTutor]
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelSubject]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spSoftDelSubject]
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelStudent]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spSoftDelStudent]
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelExamResult]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spSoftDelExamResult]
GO
/****** Object:  StoredProcedure [dbo].[spGetTutorByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetTutorByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetSubjectsForStudent]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetSubjectsForStudent]
GO
/****** Object:  StoredProcedure [dbo].[spGetSubjectByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetSubjectByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentSubjectByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetStudentSubjectByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetStudentByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetRemainingEnrollmentSlots]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetRemainingEnrollmentSlots]
GO
/****** Object:  StoredProcedure [dbo].[spGetExamResultByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetExamResultByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetEnrollmentByID]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetEnrollmentByID]
GO
/****** Object:  StoredProcedure [dbo].[spGetAvailableSubject]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAvailableSubject]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllTutors]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAllTutors]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllSubjects]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAllSubjects]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllStudents]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAllStudents]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllExamResults]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAllExamResults]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEnrollments]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spGetAllEnrollments]
GO
/****** Object:  StoredProcedure [dbo].[spCreateTutor]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spCreateTutor]
GO
/****** Object:  StoredProcedure [dbo].[spCreateSubject]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spCreateSubject]
GO
/****** Object:  StoredProcedure [dbo].[spCreateStudent]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spCreateStudent]
GO
/****** Object:  StoredProcedure [dbo].[spCreateExamResult]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spCreateExamResult]
GO
/****** Object:  StoredProcedure [dbo].[spCreateEnrollment]    Script Date: 2023/10/19 9:53:56 ******/
DROP PROCEDURE IF EXISTS [dbo].[spCreateEnrollment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subject]') AND type in (N'U'))
ALTER TABLE [dbo].[Subject] DROP CONSTRAINT IF EXISTS [FK_Subject_Tutor_Tutor_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExamResult]') AND type in (N'U'))
ALTER TABLE [dbo].[ExamResult] DROP CONSTRAINT IF EXISTS [FK_ExamResult_Enrollment_Enrollment_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment] DROP CONSTRAINT IF EXISTS [FK_Enrollment_Subject_Subject_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment] DROP CONSTRAINT IF EXISTS [FK_Enrollment_Student_Student_ID]
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[Tutor]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[Subject]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[Student]
GO
/****** Object:  Table [dbo].[ExamResult]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[ExamResult]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[Enrollment]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023/10/19 9:53:56 ******/
DROP TABLE IF EXISTS [dbo].[__EFMigrationsHistory]
GO
ALTER DATABASE [UniSysContext] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
EXEC [UniSysContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniSysContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniSysContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniSysContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniSysContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniSysContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniSysContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UniSysContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniSysContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniSysContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniSysContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniSysContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniSysContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniSysContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniSysContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniSysContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniSysContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniSysContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniSysContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniSysContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniSysContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniSysContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UniSysContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniSysContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniSysContext] SET  MULTI_USER 
GO
ALTER DATABASE [UniSysContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniSysContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniSysContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniSysContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniSysContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniSysContext] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniSysContext] SET QUERY_STORE = OFF
GO
USE [UniSysContext]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[Enrollment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Student_ID] [int] NOT NULL,
	[Subject_ID] [int] NOT NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[Enrollment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamResult]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResult](
	[Exam_ID] [int] IDENTITY(1,1) NOT NULL,
	[Mark] [decimal](4, 1) NOT NULL,
	[ExamDate] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsDeletedDate] [datetime] NULL,
	[Enrollment_ID] [int] NOT NULL,
 CONSTRAINT [PK_ExamResult] PRIMARY KEY CLUSTERED 
(
	[Exam_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Email] [varchar](50) NULL,
	[IsDelete] [bit] NOT NULL,
	[IsDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Subject_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsDeletedDate] [datetime] NULL,
	[Tutor_ID] [int] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Subject_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutor](
	[Tutor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [int] NOT NULL,
	[Gender] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Email] [varchar](50) NULL,
	[IsDelete] [bit] NOT NULL,
	[IsDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Tutor] PRIMARY KEY CLUSTERED 
(
	[Tutor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student_Student_ID] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student_Student_ID]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Subject_Subject_ID] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[Subject] ([Subject_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Subject_Subject_ID]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Enrollment_Enrollment_ID] FOREIGN KEY([Enrollment_ID])
REFERENCES [dbo].[Enrollment] ([Enrollment_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_Enrollment_Enrollment_ID]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Tutor_Tutor_ID] FOREIGN KEY([Tutor_ID])
REFERENCES [dbo].[Tutor] ([Tutor_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Tutor_Tutor_ID]
GO
/****** Object:  StoredProcedure [dbo].[spCreateEnrollment]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateEnrollment]
    @StudentID INT,
    @SubjectID INT
AS
BEGIN
declare @message varchar
    -- check duplicate enrollment
    IF NOT EXISTS (
        SELECT 1
        FROM Enrollment
        WHERE Student_ID = @StudentID AND Subject_ID = @SubjectID
    )BEGIN
    -- insert new Enrollment
    INSERT INTO Enrollment (Student_ID, Subject_ID)
    VALUES (@StudentID, @SubjectID);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateExamResult]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateExamResult](
@Student_ID int,
@Subject_ID int,
@Mark decimal(4,1),
@ExamDate datetime,
@IsDelete bit,
@Status int OUTPUT)
AS BEGIN
	SET NOCOUNT ON;

	DECLARE @Enrollment_ID int
	SELECT @Enrollment_ID = e.Enrollment_ID FROM Enrollment e 
	JOIN Student s ON s.Student_ID = e.Student_ID
	JOIN Subject sj ON sj.Subject_ID = e.Subject_ID
	WHERE s.Student_ID = @Student_ID and sj.Subject_ID = @Subject_ID

	IF @Enrollment_ID is NULL 
	BEGIN 
		-- Student is not enrolled in this Subject
		SET @Status = 1;
	END
		ElSE BEGIN
			IF EXISTS (SELECT 1 FROM ExamResult WHERE Enrollment_ID = @Enrollment_ID)
			BEGIN
            -- Set @Status to indicate that an exam result already exists
            SET @Status = 2;
        END
		ELSE BEGIN 
			INSERT INTO ExamResult (Mark, ExamDate, IsDelete, IsDeletedDate, Enrollment_ID)
			VALUES (@Mark, @ExamDate, @IsDelete, NULL, @Enrollment_ID)
			-- Exam result successfully added
			SET @Status = 3;
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateStudent]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateStudent](
	@Name NVARCHAR(50), 
	@Gender bit,
	@PhoneNumber VARCHAR (15),
	@Email VARCHAR (50),
	@IsDelete bit)

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Student (Name, Gender, PhoneNumber, Email, IsDelete, IsDeletedDate)
	VALUES (@Name, @Gender, @PhoneNumber, @Email, @IsDelete, NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateSubject]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateSubject](
@Title VARCHAR(50),
@Tutor_ID int,
@IsDelete bit)

AS BEGIN
SET NOCOUNT ON;
INSERT INTO Subject (Title,Tutor_ID,IsDelete,IsDeletedDate)
VALUES (@Title, @Tutor_ID, @IsDelete, NULL)
END

GO
/****** Object:  StoredProcedure [dbo].[spCreateTutor]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateTutor](
	@Name NVARCHAR(50),
	@Position int,
	@Gender bit,
	@PhoneNumber VARCHAR (15),
	@Email VARCHAR (50), 
	@IsDelete bit)

AS BEGIN
SET NOCOUNT ON;
	INSERT INTO Tutor (Name, Position, Gender, PhoneNumber, Email, IsDelete, IsDeletedDate)
	VALUES (@Name, @Position, @Gender, @PhoneNumber, @Email, @IsDelete, NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEnrollments]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetAllEnrollments]
AS
BEGIN
SET NOCOUNT ON;
SELECT e.Enrollment_ID, s.Student_ID, t.subject_ID, s.Name, t.Title FROM Enrollment e WITH(NOLOCK)
JOIN Student s ON e.Student_ID = s.Student_ID
JOIN Subject t ON e.Subject_ID = t.Subject_ID
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllExamResults]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAllExamResults]
AS BEGIN
SET NOCOUNT ON;
SELECT er.Exam_ID,er.Mark,er.ExamDate,er.IsDelete,er.IsDeletedDate,er.Enrollment_ID,
	s.Student_ID, s.Name, sj.Subject_ID, sj.Title 
	FROM ExamResult er WITH(NOLOCK)
JOIN Enrollment e ON e.Enrollment_ID = er.Enrollment_ID
JOIN Student s ON s.Student_ID = e.Student_ID
JOIN Subject sj ON e.Subject_ID = sj.Subject_ID
END

GO
/****** Object:  StoredProcedure [dbo].[spGetAllStudents]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllStudents]
AS BEGIN
SET NOCOUNT ON;
SELECT Student_ID, Name, Gender,PhoneNumber, Email,IsDelete,IsDeletedDate 
FROM Student WITH(NOLOCK)
WHERE IsDelete = 0
END

GO
/****** Object:  StoredProcedure [dbo].[spGetAllSubjects]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAllSubjects]
AS BEGIN
SET NOCOUNT ON;
SELECT s.Subject_ID, s.Title, s.IsDelete, s.IsDeletedDate, s.Tutor_ID, 
		t.Name 
FROM Subject s WITH(NOLOCK)
inner JOIN Tutor t ON t.Tutor_ID = s.Tutor_ID
WHERE s.IsDelete = 0
END

GO
/****** Object:  StoredProcedure [dbo].[spGetAllTutors]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllTutors]
AS BEGIN
SET NOCOUNT ON;
SELECT Tutor_ID,Name,Position,Gender,PhoneNumber,Email,IsDelete,IsDeletedDate FROM TUTOR WITH(NOLOCK)
WHERE IsDelete = 0
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAvailableSubject]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAvailableSubject]
    @Student_ID INT
AS
BEGIN
    SELECT s.Subject_ID, s.Title, s.IsDelete, s.IsDeletedDate, s.Tutor_ID
    FROM Subject s WITH(NOLOCK)
    WHERE s.Subject_ID NOT IN (
        SELECT Enrollment.Subject_ID
        FROM Enrollment WITH(NOLOCK)
        WHERE Enrollment.Student_ID = @Student_ID
    )
    AND s.IsDelete = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetEnrollmentByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetEnrollmentByID](
@id int)
AS BEGIN
SET NOCOUNT ON;
Select e.Enrollment_ID, s.Student_ID, t.subject_ID, s.Name, t.Title 
	FROM enrollment e WITH(NOLOCK)
JOIN Student s ON e.Student_ID = s.Student_ID
JOIN Subject t ON e.Subject_ID = t.Subject_ID
WHERE Enrollment_ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spGetExamResultByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetExamResultByID](
@id int)
AS BEGIN
SET NOCOUNT ON;
SELECT er.Exam_ID,er.Mark,er.ExamDate,er.IsDelete,er.IsDeletedDate,er.Enrollment_ID, 
	s.Student_ID, s.Name, 
	sj.Subject_ID, sj.Title 
	FROM ExamResult er WITH(NOLOCK)
JOIN Enrollment e ON e.Enrollment_ID = er.Enrollment_ID
JOIN Student s ON s.Student_ID = e.Student_ID
JOIN Subject sj ON e.Subject_ID = sj.Subject_ID 
WHERE Exam_ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[spGetRemainingEnrollmentSlots]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRemainingEnrollmentSlots]
    @Student_ID int,
	@RemainingSlots int OUTPUT
AS
BEGIN 
    DECLARE @TotalSubjects int
    DECLARE @PassedSubjects int
    
    -- calculate Student Subject enrollment count
    SELECT @TotalSubjects = COUNT(*)
    FROM Enrollment WITH(NOLOCK)
    WHERE Student_ID = @Student_ID

    -- calculate Student pass exam number
    SELECT @PassedSubjects = COUNT(*)
    FROM ExamResult ER WITH(NOLOCK)
	JOIN Enrollment E ON ER.Enrollment_ID = E.Enrollment_ID
    WHERE Student_ID = @Student_ID AND er.Mark >= 50 AND IsDelete = 0

    -- calculate remaining slot
    SET @RemainingSlots = 10 - @TotalSubjects + @PassedSubjects

    -- return remain slot 
    SELECT @RemainingSlots AS RemainingSlots
	return @RemainingSlots
End
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetStudentByID](
@id int)
AS
BEGIN
SET NOCOUNT ON;
Select Student_ID, Name, Gender, PhoneNumber, Email, IsDelete, IsDeletedDate FROM Student WITH(NOLOCK)
WHERE Student_ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetStudentSubjectByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetStudentSubjectByID](
@Student_ID int)
AS BEGIN

SELECT e.Enrollment_ID, sj.Subject_ID, sj.Title, s.Student_ID, s.name FROM Enrollment e WITH(NOLOCK)
JOIN Subject sj ON e.subject_ID = sj.subject_ID
JOIN Student s ON s.Student_ID = e.Student_ID 
WHERE s.Student_ID = @Student_ID


END
GO
/****** Object:  StoredProcedure [dbo].[spGetSubjectByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSubjectByID](
@id int)
AS BEGIN
SET NOCOUNT ON;
SELECT Subject_ID, Title, IsDelete, IsDeletedDate, Tutor_ID FROM Subject WITH(NOLOCK)
WHERE Subject_ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[spGetSubjectsForStudent]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSubjectsForStudent]
    @Student_ID int
AS BEGIN
    SET NOCOUNT ON;

    SELECT s.Subject_ID, s.Title, s.IsDelete, s.IsDeletedDate, s.Tutor_ID
    FROM Subject s WITH(NOLOCK)
    JOIN Enrollment e ON s.Subject_ID = e.Subject_ID
    WHERE e.Student_ID = @Student_ID
        AND s.IsDelete = 0
		AND NOT EXISTS (
        SELECT 1 
        FROM ExamResult ER WITH(NOLOCK)
        WHERE ER.Enrollment_ID = e.Enrollment_ID);
END
GO
/****** Object:  StoredProcedure [dbo].[spGetTutorByID]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetTutorByID](
@id int)
AS
BEGIN
SET NOCOUNT ON;
Select Tutor_ID, Name, Position, Gender, PhoneNumber, Email, IsDelete, IsDeletedDate FROM Tutor WITH(NOLOCK)
WHERE Tutor_ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelExamResult]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSoftDelExamResult](
@id int)

AS BEGIN SET NOCOUNT ON 
UPDATE ExamResult WITH(ROWLOCK)
SET 
	IsDelete = 1, 
	IsDeletedDate=CURRENT_TIMESTAMP
WHERE  
	Exam_ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelStudent]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSoftDelStudent](
@id int)

AS BEGIN SET NOCOUNT ON 
UPDATE Student WITH(ROWLOCK)
SET 
	IsDelete = 1, 
	IsDeletedDate=CURRENT_TIMESTAMP
WHERE  
	Student_ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelSubject]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSoftDelSubject](
@id int)

AS BEGIN SET NOCOUNT ON 
UPDATE Subject WITH(ROWLOCK)
SET 
	IsDelete = 1, 
	IsDeletedDate=CURRENT_TIMESTAMP
WHERE  
	Subject_ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spSoftDelTutor]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSoftDelTutor](
@id int)

AS BEGIN SET NOCOUNT ON 
UPDATE Tutor WITH(ROWLOCK)
SET 
	IsDelete = 1, 
	IsDeletedDate=CURRENT_TIMESTAMP
WHERE  
	Tutor_ID = @id 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEnrollment]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateEnrollment](
    @id int,
    @Student_ID int, 
    @Subject_ID int,
    @StatusCode int OUTPUT
)
AS 
BEGIN
    SET NOCOUNT ON;

    -- Check if the combination of Student_ID and Subject_ID already exists
    IF EXISTS (
        SELECT 1 FROM Enrollment WITH (NOLOCK)
        WHERE 
            Student_ID = @Student_ID 
            AND Subject_ID = @Subject_ID
    )
    BEGIN 
		-- Indicates that the Student is already enrolled in this Subject
        SET @StatusCode = 2; 
        RETURN;
    END

    -- Perform the update
    BEGIN TRY
        UPDATE Enrollment WITH (ROWLOCK)
        SET
            Student_ID = @Student_ID,
            Subject_ID = @Subject_ID
        WHERE  
            Enrollment_ID = @id

        SET @StatusCode = 1; -- Indicates a successful update
    END TRY
    BEGIN CATCH
        SET @StatusCode = -1; -- Indicates a general update failure
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateExamResult]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateExamResult](
@id int,
@Mark decimal(4,1),
@ExamDate datetime)

AS BEGIN
SET NOCOUNT ON;
UPDATE ExamResult WITH (ROWLOCK)
SET    
	Mark = @Mark,
    ExamDate = @ExamDate
WHERE  
	Exam_ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateStudent]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateStudent](
@Student_ID int,
@Name NVARCHAR(50),
@Gender bit,
@PhoneNumber VARCHAR (15),
@Email VARCHAR (50))

AS BEGIN
SET NOCOUNT ON;
UPDATE Student WITH (ROWLOCK)
SET    
	Name = @Name,
    Gender = @Gender,
	PhoneNumber = @PhoneNumber, 
	Email = @Email
WHERE  
	Student_ID = @Student_ID
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSubject]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateSubject](
@id int,
@Title NVARCHAR(50),
@Tutor_ID int)

AS BEGIN
SET NOCOUNT ON;
UPDATE Subject WITH (ROWLOCK)
SET    
	Title = @Title,
    Tutor_ID = @Tutor_ID
WHERE  
	Subject_ID = @id
END

GO
/****** Object:  StoredProcedure [dbo].[spUpdateTutor]    Script Date: 2023/10/19 9:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateTutor](
@id int,
@Name NVARCHAR(50),
@Position int,
@Gender bit,
@PhoneNumber VARCHAR (15),
@Email VARCHAR (50))

AS BEGIN
SET NOCOUNT ON;
UPDATE Tutor WITH (ROWLOCK)
SET    
	Name = @Name,
	Position = @Position,
    Gender = @Gender,
	PhoneNumber = @PhoneNumber, 
	Email = @Email
WHERE  
	Tutor_ID = @id
END
GO
USE [master]
GO
ALTER DATABASE [UniSysContext] SET  READ_WRITE 
GO
