USE [OSTdb]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegisterNewUser]    Script Date: 5/11/2025 4:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegisterNewUser]
	@firstName NVARCHAR (100),
    @lastName  NVARCHAR (100),
    @email     NVARCHAR (100),
    @password  NVARCHAR (255),
    @gender    NVARCHAR (10),
    @roleId    INT
AS
	BEGIN
		Insert into OstMembers (FirstName, LastName, Email, Password, Gender, RoleId)
		Values(@firstName, @lastName, @email, @password, @gender, @roleId)
	END
GO
