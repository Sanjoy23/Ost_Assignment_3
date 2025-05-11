USE [OSTdb]
GO
/****** Object:  StoredProcedure [dbo].[FindMember]    Script Date: 5/11/2025 4:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindMember]
	@UserName nvarchar(50)
AS
	BEGIN
		SELECT Email FROM OSTMembers WHERE Email = @UserName
	END
RETURN 0
GO
