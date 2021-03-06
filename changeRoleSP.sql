USE [FamilyBudgetDB]
GO
/****** Object:  StoredProcedure [dbo].[ChangeUserRole]    Script Date: 04.12.2015 6:03:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeUserRole]
	@userRequestedChangeLogin nvarchar(20),
	@userForChangeLogin nvarchar(20),
	@roleIsAdmin bit
AS
BEGIN
	IF (SELECT count(0) FROM [dbo].[Users] WHERE [Login] = @userRequestedChangeLogin AND IsAdmin = 1) > 0
	BEGIN
		IF  (@roleIsAdmin = 0 AND (SELECT count(0) FROM [dbo].[Users] WHERE [IsAdmin] = 1) > 1) OR @roleIsAdmin = 1
		BEGIN
			UPDATE [Users]
			SET [IsAdmin] = @roleIsAdmin
			WHERE [Login] = @userForChangeLogin
		END
	END
END

GO
