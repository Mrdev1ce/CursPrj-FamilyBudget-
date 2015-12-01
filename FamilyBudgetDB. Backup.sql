USE [FamilyBudgetDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operations]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WalletID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Type] [bit] NOT NULL,
	[Sum] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Opearations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[Funds] [int] NOT NULL,
	[OwnerID] [int] NOT NULL,
 CONSTRAINT [PK_Wallets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name]) VALUES (3, N'Salary')
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (4, N'Personal')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Operations] ON 

INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (11, 6, 3, 1, 500, CAST(N'2015-11-22' AS Date))
INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (14, 9, 3, 1, 400, CAST(N'2015-11-17' AS Date))
INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (15, 7, 4, 0, 8300, CAST(N'2015-10-09' AS Date))
INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (19, 6, 3, 1, 6836, CAST(N'2015-11-22' AS Date))
INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (21, 7, 4, 0, 3000, CAST(N'2015-11-22' AS Date))
INSERT [dbo].[Operations] ([ID], [WalletID], [CategoryID], [Type], [Sum], [Date]) VALUES (24, 6, 3, 1, 800, CAST(N'2015-11-24' AS Date))
SET IDENTITY_INSERT [dbo].[Operations] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [Password], [Mail], [RegistrationDate], [IsAdmin]) VALUES (3, N'maksim', N'maksim', N'maksim@mail.com', CAST(N'2015-11-09' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Wallets] ON 

INSERT [dbo].[Wallets] ([ID], [Name], [Funds], [OwnerID]) VALUES (6, N'Cash', 3500, 3)
INSERT [dbo].[Wallets] ([ID], [Name], [Funds], [OwnerID]) VALUES (7, N'Bank account', 57300, 3)
INSERT [dbo].[Wallets] ([ID], [Name], [Funds], [OwnerID]) VALUES (9, N'Debet card', 197286, 3)
SET IDENTITY_INSERT [dbo].[Wallets] OFF
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Opearations_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Opearations_Categories]
GO
ALTER TABLE [dbo].[Operations]  WITH CHECK ADD  CONSTRAINT [FK_Opearations_Wallets] FOREIGN KEY([WalletID])
REFERENCES [dbo].[Wallets] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operations] CHECK CONSTRAINT [FK_Opearations_Wallets]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Users] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddOperation]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOperation]
	@walletID int,
	@categoryID int,
	@type bit,
	@sum int
AS
BEGIN
	INSERT INTO [dbo].[Operations] ([WalletID], [CategoryID], [Type], [Sum], [Date])
		VALUES (@walletID, @categoryID, @type, @sum, GETDATE())
END

GO
/****** Object:  StoredProcedure [dbo].[AddWallet]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddWallet]
	@userLogin nvarchar(20),
	@walletID int,
	@walletName nvarchar(70),
	@walletFunds int
AS
BEGIN
	IF (SELECT count(0) FROM [dbo].[Wallets] WHERE [ID] = @walletID) > 0
		BEGIN
			UPDATE [Wallets]
			SET [Name] = @walletName, [Funds] = @walletFunds
			WHERE [ID] = @walletID
		END
	IF (@walletID = -1)
		BEGIN
			DECLARE @LocalOwnerID int
			EXEC [dbo].[GetOwnerIDByLogin] @userLogin = @userLogin, @ownerID = @LocalOwnerID OUTPUT
			IF (@LocalOwnerID > -1)
			BEGIN
				INSERT INTO [Wallets] ([Name], [Funds], [OwnerID])
				VALUES (@walletName, @walletFunds, @LocalOwnerID)
			END
		END
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategories]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT *
		FROM [dbo].Categories
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllUsersInRole]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetAllWallets]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetOperationsByLogin]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOperationsByLogin]
	@userLogin nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @LocalOwnerID int

	EXEC [dbo].[GetOwnerIDByLogin] @userLogin = @userLogin, @ownerID = @LocalOwnerID OUTPUT

	Select op.ID, w.Name as WalletName, w.ID as WalletID, op.[Type], op.[Sum], op.[Date], cat.Name as CategoryName
		FROM [dbo].[Wallets] AS w
		JOIN [dbo].[Operations] AS op on [w].[ID] = [op].[WalletID]
		JOIN [dbo].[Categories] AS cat on [op].[CategoryID] = [cat].[ID]
		WHERE [OwnerID] = @LocalOwnerID
END

GO
/****** Object:  StoredProcedure [dbo].[GetOperationsByWalletID]    Script Date: 01.12.2015 11:48:13 AM ******/
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
	SELECT o.[ID], o.[WalletID], o.[Type], o.[Sum], o.[Date], cat.[Name] as CategoryName
		FROM [dbo].[Operations] as o
		JOIN [dbo].[Categories] as cat ON o.[CategoryID] = cat.[ID]
		WHERE [WalletID] = @WalletID
END



GO
/****** Object:  StoredProcedure [dbo].[GetOperationsByWalletIDAndType]    Script Date: 01.12.2015 11:48:13 AM ******/
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
		FROM [dbo].[Operations]
		WHERE [WalletID] = @WalletID AND [Type] = @Type
END



GO
/****** Object:  StoredProcedure [dbo].[GetOwnerIDByLogin]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOwnerIDByLogin]
	@userLogin nvarchar(20),
	@ownerID int output
AS
BEGIN
	SET NOCOUNT ON;

	Select @ownerID = [ID]
		From [Users]
		Where [Login] = @userLogin
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByCredentional]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetWalletByLoginAndID]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWalletByLoginAndID]
	@userLogin nvarchar(20),
	@walletID int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @LocalOwnerID int

	SELECT @LocalOwnerID = [ID]
		FROM [Users]
		WHERE [Login] = @userLogin

	SELECT *
		FROM [Wallets]
		WHERE [Wallets].[OwnerID] = @LocalOwnerID AND [Wallets].[ID] = @walletID
END

GO
/****** Object:  StoredProcedure [dbo].[GetWalletsByLogin]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetWalletsByLogin]
	@userLogin nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @LocalOwnerID int

	Select @LocalOwnerID = [ID]
		From [Users]
		Where [Login] = @userLogin

	EXEC [dbo].GetWalletsByOwnerID @OwnerID = @LocalOwnerID
END



GO
/****** Object:  StoredProcedure [dbo].[GetWalletsByOwnerID]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[IsAdmin]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[IsUserInRole]    Script Date: 01.12.2015 11:48:13 AM ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveOperation]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveOperation]
	@operationId int,
	@userLogin nvarchar(20)
AS
BEGIN
    DECLARE @LocalOwnerID int

	EXEC [dbo].[GetOwnerIDByLogin] @userLogin = @userLogin, @ownerID = @LocalOwnerID OUTPUT

	IF(SELECT count(0)
		FROM [dbo].[Wallets] as w
		JOIN [dbo].[Operations] as op ON w.[ID] = op.[WalletID]
		WHERE w.[OwnerID] = @LocalOwnerID AND op.[ID] = @operationId) > 0
		BEGIN
			DELETE FROM [dbo].[Operations]
			WHERE [Operations].[ID] = @operationId
		END

END

GO
/****** Object:  StoredProcedure [dbo].[RemoveWallet]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveWallet] 
	@walletId int,
	@userLogin nvarchar(20)
AS
BEGIN
    DECLARE @LocalOwnerID int

	EXEC [dbo].[GetOwnerIDByLogin] @userLogin = @userLogin, @ownerID = @LocalOwnerID OUTPUT

	DELETE FROM [dbo].[Wallets]
	WHERE [OwnerID] = @LocalOwnerID AND [ID] = @walletId
END

GO
/****** Object:  Trigger [dbo].[CalculateFundsInWallets]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[CalculateFundsInWallets]
   ON [dbo].[Operations]
   AFTER INSERT
AS 
BEGIN
	DECLARE @sum int, @walletID int, @type bit
	SELECT @sum = [Sum], @walletID = [WalletID], @type = [Type]
		FROM [inserted]
	IF (@type = 1)
		BEGIN
			UPDATE [dbo].[Wallets]
			SET [Funds] = [Funds] + @sum
			WHERE [ID] = @walletID
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Wallets]
			SET [Funds] = [Funds] - @sum
			WHERE [ID] = @walletID
		END

END

GO
/****** Object:  Trigger [dbo].[CalculateFundsInWalletsDelete]    Script Date: 01.12.2015 11:48:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[CalculateFundsInWalletsDelete]
   ON [dbo].[Operations]
   AFTER DELETE
AS 
BEGIN
	DECLARE @sum int, @walletID int, @type bit
	SELECT @sum = [Sum], @walletID = [WalletID], @type = [Type]
		FROM [deleted]
	IF (@type = 1)
		BEGIN
			UPDATE [dbo].[Wallets]
			SET [Funds] = [Funds] - @sum
			WHERE [ID] = @walletID
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Wallets]
			SET [Funds] = [Funds] + @sum
			WHERE [ID] = @walletID
		END

END

GO
