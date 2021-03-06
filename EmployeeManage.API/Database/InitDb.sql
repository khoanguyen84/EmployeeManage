USE [EmployeeManageDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/15/2020 10:02:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/15/2020 10:02:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[DoB] [datetime] NOT NULL,
	[Gender] [bit] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[AvatarPath] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (1, N'IT')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (2, N'HR')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (3, N'Admin')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (4, N'Sale')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (6, N'Care Customers')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (7, N'Managerment')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (8, N'Managerment2')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (9, N'đf')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (10, N'sdfsdf')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (11, N'dfgfhfj')
SET IDENTITY_INSERT [dbo].[Department] OFF
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDepartment]    Script Date: 7/15/2020 10:02:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/14/2020
-- Description:	delete department by departmentID
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteDepartment]
	@DepartmentId INT
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again'
	BEGIN TRY
		DELETE FROM [dbo].[Department]
		WHERE DepartmentId = @DepartmentId

		SET @Message = 'Department has been deleted successfully'
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]
	END CATCH
	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartment]    Script Date: 7/15/2020 10:02:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/14/2020
-- Description:	Get department by departmentID
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDepartment]
	@DepartmentId INT
AS
BEGIN

	SELECT [DepartmentId]
      ,[DepartmentName]
  FROM [dbo].[Department]
  WHERE DepartmentId = @DepartmentId

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 7/15/2020 10:02:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/14/2020
-- Description:	Get all department
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDepartments]
AS
BEGIN

	SELECT [DepartmentId]
      ,[DepartmentName]
  FROM [dbo].[Department]

END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveDepartment]    Script Date: 7/15/2020 10:02:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/14/2020
-- Description:	create/update department
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveDepartment]
	@DepartmentId INT,
	@DeparmentName NVARCHAR(50)
AS
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again!'
	BEGIN TRY
		--Create new Department
		IF(@DepartmentId IS NULL OR @DepartmentId = 0)
		BEGIN
			INSERT INTO [dbo].[Department]
			   ([DepartmentName])
			VALUES
			   (@DeparmentName)
		
			SET @DepartmentId = SCOPE_IDENTITY()
			SET @Message = 'Department has been created successfully'

		END
		ELSE --Update Department by Id
		BEGIN
			UPDATE [dbo].[Department]
			   SET [DepartmentName] = @DeparmentName
			 WHERE DepartmentId = @DepartmentId
			 SET @Message = 'Department has been updated successfully'
		END

		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SET @DepartmentId = 0
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]
	END CATCH
END
GO
