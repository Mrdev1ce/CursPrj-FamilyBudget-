USE [FamilyBudgetDB]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 03.12.2015 6:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
	@userLogin nvarchar(20),
	@categoryName nvarchar(70),
	@categoryId int
AS
BEGIN
	IF (SELECT count(0) FROM [dbo].[Users] WHERE [Login] = @userLogin AND IsAdmin = 1) > 0
	BEGIN
		IF (SELECT count(0) FROM [dbo].[Categories] WHERE [ID] = @categoryId) > 0
		BEGIN
			UPDATE [Categories]
			SET [Name] = @categoryName
			WHERE [ID] = @categoryID
		END
		IF (@categoryId = -1)
		BEGIN
			INSERT INTO [Categories] ([Name])
			VALUES (@categoryName)
		END
	END
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveCategory]    Script Date: 03.12.2015 6:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveCategory]
	@userLogin nvarchar(20),
	@categoryId int
AS
BEGIN
	IF (SELECT count(0) FROM [dbo].[Users] WHERE [Login] = @userLogin AND IsAdmin = 1) > 0
	BEGIN
		DELETE FROM [dbo].[Categories]
			WHERE [ID] = @categoryId
	END
END

GO
