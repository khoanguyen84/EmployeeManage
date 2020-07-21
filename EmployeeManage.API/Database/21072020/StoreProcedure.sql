USE [EmployeeManageDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_SearchDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
DROP PROCEDURE [dbo].[sp_SearchDepartment]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
DROP PROCEDURE [dbo].[sp_DeleteDepartment]
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
DROP PROCEDURE [dbo].[sp_SaveDepartment]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 7/21/2020 9:48:01 AM ******/
DROP PROCEDURE [dbo].[sp_GetDepartments]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 7/21/2020 9:48:01 AM ******/
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

	SELECT d.[DepartmentId]
      ,d.[DepartmentName]
	  ,(SELECT COUNT(*) FROM Employee e WHERE e.DepartmentId = d.DepartmentId) AS Employees
  FROM [dbo].[Department] d

END
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
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
			SET @Message = 'Department has been created successfully!'

		END
		ELSE --Update Department by Id
		BEGIN
			UPDATE [dbo].[Department]
			   SET [DepartmentName] = @DeparmentName
			 WHERE DepartmentId = @DepartmentId
			 SET @Message = 'Department has been updated successfully!'
		END

		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SET @DepartmentId = 0
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]
	END CATCH
END
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
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

		SET @Message = 'Department has been deleted successfully!'
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SELECT @DepartmentId AS DepartmentId, @Message AS [Message]
	END CATCH
	

END
GO

/****** Object:  StoredProcedure [dbo].[sp_SearchDepartment]    Script Date: 7/21/2020 9:48:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Khoa Nguyen
-- Create date: 7/16/2020
-- Description:	search department
-- =============================================
CREATE PROCEDURE [dbo].[sp_SearchDepartment]
	@keyword NVARCHAR(50)
AS
BEGIN

	IF(@keyword IS NULL)
		SET @keyword = ''

	SELECT [DepartmentId]
      ,[DepartmentName]
  FROM [dbo].[Department]
  WHERE DepartmentName LIKE '%'+@keyword+'%'

END
GO

