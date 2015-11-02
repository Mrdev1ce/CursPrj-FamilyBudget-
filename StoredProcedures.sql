USE [FamilyBudgetDB]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
	@UserID int
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF (SELECT count(0) FROM [dbo].[Users] WHERE ID = @UserID AND IsAdmin = 1) > 0
	BEGIN
	SELECT *
		FROM [dbo].[Users]
	END
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllUsersInRole]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsersInRole]
	@role bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
		FROM [dbo].[Users]
		WHERE IsAdmin = @role
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllWallets]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllWallets]
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Wallets]
END


GO
/****** Object:  StoredProcedure [dbo].[GetOperationsByWalletID]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOperationsByWalletID]
	@WalletID int
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Opearations]
		WHERE [WalletID] = @WalletID
END


GO
/****** Object:  StoredProcedure [dbo].[GetOperationsByWalletIDAndType]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOperationsByWalletIDAndType]
	@Type bit,
	@WalletID int
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Opearations]
		WHERE [WalletID] = @WalletID AND [Type] = @Type
END


GO
/****** Object:  StoredProcedure [dbo].[GetUserByCredentional]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByCredentional]
	@Login nvarchar(20),
	@Password nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Users]
		WHERE [Login] = @Login AND [Password] = @Password
END


GO
/****** Object:  StoredProcedure [dbo].[GetWalletsByOwnerID]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWalletsByOwnerID]
	@OwnerID int
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Wallets]
		WHERE [OwnerID] = @OwnerID
END


GO
/****** Object:  StoredProcedure [dbo].[IsAdmin]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsAdmin] 
	@userLogin nvarchar(20),
	@isAdmin bit output
AS
BEGIN
	SET NOCOUNT ON;

	IF (SELECT count(0) FROM [dbo].[Users] WHERE [Login] = @userLogin AND IsAdmin = 1) > 0
	SET @isAdmin = 1
	ELSE
	SET @isAdmin = 0
END

GO
/****** Object:  StoredProcedure [dbo].[IsUserInRole]    Script Date: 03.11.2015 0:00:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsUserInRole]
	@userLogin nvarchar(20),
	@role bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
		FROM [dbo].[Users]
		WHERE [Login] = @userLogin AND [IsAdmin] = @role
END

GO
