USE [EmployeeManageDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetEmployeesByDepartId]    Script Date: 7/22/2020 10:04:02 AM ******/
DROP PROCEDURE [dbo].[sp_GetEmployeesByDepartId]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetEmployeesByDepartId]    Script Date: 7/22/2020 10:04:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/22/2020
-- Description:	Get employees by departmentId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetEmployeesByDepartId]
	@DepartmentId INT
AS
BEGIN


SELECT [EmployeeId]
      ,[EmployeeName]
      ,FORMAT([DoB], 'MMM dd yyyy') AS [DoB]
      ,(CASE WHEN [Gender] = 1 THEN 'Male' ELSE 'Female' END) AS Gender
      ,[DepartmentId]
      ,[AvatarPath]
	  ,FORMAT([CreatedDate], 'dd/MM/yyyy') AS [CreatedDate]
  FROM [dbo].[Employee]
  WHERE DepartmentId = @DepartmentId AND IsDeleted = 0

END
GO

