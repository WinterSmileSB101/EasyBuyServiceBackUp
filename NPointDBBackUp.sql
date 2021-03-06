USE [master]
GO
/****** Object:  Database [NPoint]    Script Date: 1/5/2018 11:18:32 上午 ******/
CREATE DATABASE [NPoint] ON  PRIMARY 
( NAME = N'NPoint', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.S7OVSDB04\MSSQL\DATA\NPoint.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NPoint_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10_50.S7OVSDB04\MSSQL\DATA\NPoint_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NPoint] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NPoint].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NPoint] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NPoint] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NPoint] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NPoint] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NPoint] SET ARITHABORT OFF 
GO
ALTER DATABASE [NPoint] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NPoint] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NPoint] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NPoint] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NPoint] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NPoint] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NPoint] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NPoint] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NPoint] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NPoint] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NPoint] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NPoint] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NPoint] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NPoint] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NPoint] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NPoint] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NPoint] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NPoint] SET RECOVERY FULL 
GO
ALTER DATABASE [NPoint] SET  MULTI_USER 
GO
ALTER DATABASE [NPoint] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NPoint] SET DB_CHAINING OFF 
GO
USE [NPoint]
GO
/****** Object:  UserDefinedTableType [dbo].[ProductTableType]    Script Date: 1/5/2018 11:18:33 上午 ******/
CREATE TYPE [dbo].[ProductTableType] AS TABLE(
	[ProductID] [varchar](50) NULL,
	[number] [int] NULL
)
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/5/2018 11:18:33 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [char](4) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Telephone] [varchar](50) NULL,
	[NPoints] [int] NOT NULL,
	[RestPoints] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Link] [varchar](100) NOT NULL,
	[ImageUrl] [nvarchar](200) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
	[Enable] [bit] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HomePage]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HomePage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[ProductID] [varchar](50) NOT NULL,
	[Priority] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_HomePage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modules]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](20) NOT NULL,
	[Priority] [int] NOT NULL,
	[Enable] [bit] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NPointApply]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NPointApply](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[ApplyTo] [varchar](max) NOT NULL,
	[IsApply] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_NPointApply] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NPointsHistory]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NPointsHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[State] [bit] NOT NULL,
	[Number] [int] NOT NULL,
	[Comment] [nvarchar](100) NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_NPointsHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderListID] [varchar](30) NOT NULL,
	[ProductID] [varchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderList]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderListID] [varchar](30) NOT NULL,
	[OrderState] [nvarchar](6) NOT NULL,
	[CostomerEmail] [varchar](100) NOT NULL,
	[OrderTotal] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[PayManEmail] [varchar](100) NOT NULL,
	[FeaturesProduct] [bit] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderRemark]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderRemark](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderListID] [varchar](30) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[IsShowOut] [bit] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderRemark] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [varchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Stock] [int] NOT NULL,
	[FeaturesProduct] [bit] NOT NULL,
	[ForbidBuy] [bit] NOT NULL,
	[IsPublish] [bit] NOT NULL,
	[HomeDisplay] [bit] NOT NULL,
	[Priority] [int] NOT NULL,
	[BriefExplanation] [nvarchar](100) NULL,
	[DetailInfo] [nvarchar](max) NULL,
	[CategoryID] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
	[OriginalPrice] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[MaxNumber] [int] NOT NULL,
	[Discount] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[ProductID] [varchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WishList]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WishList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductUrl] [nvarchar](100) NOT NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Enable] [bit] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WishListProduct]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WishListProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WishListID] [int] NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[Number] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[InUser] [varchar](15) NOT NULL,
	[LastEditUser] [varchar](15) NOT NULL,
	[LastEditDate] [datetime] NOT NULL,
 CONSTRAINT [PK_WishListProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[OrderConfim]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*================================================================================  
Server:    MISDBS101\S7OVSDB04  
DataBase:  NPoint
Team:	   ?  
Author:    Tina
Object:    ? 
Version:   1.0  
Date:      12/9/2017
Content:   确认订单
----------------------------------------------------------------------------------  
ModIFied history:      
      
Date        ModIFied by    VER    Description      
------------------------------------------------------------  
12/9/2017  ??			   1.0    Create.  
================================================================================*/  

CREATE PROCEDURE [dbo].[OrderConfim] 
	@ListIDNNum VARCHAR(MAX),
	@BuyMan_Email VARCHAR(100),
	@PayMan_Email VARCHAR(100),
	@TotalPoint INT,
	@ShortName VARCHAR(15),
	@orderLsitID VARCHAR(16),
	@PA3 INT OUTPUT
AS
SET NOCOUNT ON
--Put your code in here
DECLARE 
				@outlength INT,
				@inlength INT,
				@tmp VARCHAR(50),
				@productID VARCHAR(50),
				@tmpstock INT,
				@PNumber INT

BEGIN TRANSACTION t1
BEGIN TRY
	WHILE @ListIDNNum <> ''
				BEGIN 
				IF charindex(',',@ListIDNNum)>0
					BEGIN
						SET @outlength = charindex(',',@ListIDNNum)
						SET @tmp = left(@ListIDNNum,@outlength-1)
						SET @inlength = charindex(':',@tmp)
						SET @productID = left(@tmp,@inlength-1)
						SET @PNumber = substring(@tmp,@inlength+1,len(@ListIDNNum)-@inlength)
						SET @ListIDNNum = substring(@ListIDNNum,@outlength+1,len(@ListIDNNum)-@outlength)
					END
				ELSE 
					BEGIN
						SET @inlength = charindex(':',@ListIDNNum)
						SET @productID = left(@ListIDNNum,@inlength-1)
						SET @PNumber = substring(@ListIDNNum,@inlength+1,len(@ListIDNNum)-@inlength)
						SET @ListIDNNum = ''
					END
				SELECT @tmpstock = Stock FROM Products WHERE ProductID = @productID
				IF @tmpstock-@PNumber>0
					UPDATE Products SET Stock = Stock - @PNumber WHERE ProductID = @productID
				ELSE
					BEGIN 
						SET @PA3 = 2
						GOTO ERROR
						--	商品库存不足
					END
				INSERT INTO OrderDetail(OrderListID,ProductID,Number,InDate,InUser,LastEditUser,LastEditDate)VALUES(@orderLsitID,@productID,@PNumber,getdate(),@ShortName,@ShortName,getdate())
				END
			INSERT INTO OrderList (OrderListID,OrderState,CostomerEmail,OrderTotal,Discount,PayManEmail,FeaturesProduct,Comment,InDate,InUser,LastEditUser,LastEditDate) 
				VALUES (@orderLsitID,N'新订单',@BuyMan_Email,@TotalPoint,0,@PayMan_Email,0,N'无',getdate(),@ShortName,@ShortName,getdate())
			
			UPDATE Account SET restPoints = restPoints - @TotalPoint WHERE Email = @PayMan_Email
				
			INSERT INTO NPointsHistory(AccountName,State,Number,Comment,InDate,InUser,LastEditUser,LastEditDate)VALUES(@BuyMan_Email,0,@TotalPoint,N'购买商品',getdate(),@ShortName,@ShortName,getdate())
		
		SET @PA3 = 1 --订单成功
	COMMIT TRANSACTION t1
END TRY
BEGIN CATCH
		SET @PA3 = 0 --订单生成失败
		GOTO ERROR
END CATCH
ERROR:
		IF @@trancount > 0 ROLLBACK TRANSACTION t1
GO
/****** Object:  StoredProcedure [dbo].[P_npoint_apply_az8g]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[P_npoint_apply_az8g]
(@applyTo VARCHAR(MAX),
@SplitFlag VARCHAR(50),
@ApplyName NVARCHAR(200))
AS
SET NOCOUNT ON
BEGIN TRY
	DECLARE @temp NVARCHAR(MAX),
	@people NVARCHAR(200),
	@npoints INT;

	WHILE(@applyTo<>'')--循环放入,
	BEGIN
	--SELECT @applyTo AS 现在字符串
	--SELECT CHARINDEX(@SplitFlag,@applyTo) AS 现在位置
		IF(CHARINDEX(@SplitFlag,@applyTo) > 0)
		BEGIN
			SET @temp = LEFT(@applyTo,CHARINDEX(@SplitFlag,@applyTo)-1);--从字符串左边获取指定长度的字符串
			SELECT @temp AS [次时插入]
			IF(@temp=@SplitFlag)
			BEGIN
				SET @applyTo = SUBSTRING(@applyTo,2,LEN(@applyTo));
			END
			ELSE
			BEGIN
				SET @applyTo = REPLACE(@applyTo,@temp,'');--去掉重复，删除已经添加的
			END
		SET @temp = REPLACE(@temp,@SplitFlag,'');
		SET @people = SUBSTRING(@temp,1,CHARINDEX(':',@temp)-1)--取出名称
		--SELECT @people AS 人名1
		SET @npoints = REPLACE(@temp,@people+':','');
		--SELECT @npoints AS 积点数量1
		--进行发钱操作
		BEGIN TRANSACTION T1
		BEGIN TRY
			--加钱
			UPDATE Account
			SET [RestPoints] = [RestPoints] + @npoints,
			NPoints = NPoints + @npoints,
			[LastEditDate] = GETDATE()
			WHERE [Email] = @people+'@newegg.com';
								
			--增加交易记录
			--入账的
			INSERT INTO NPointsHistory
			([AccountName],[State],[Number],
			[Comment],[InDate],[InUser],[LastEditUser],[LastEditDate])
			VALUES
			(@people,1,@npoints
			,@ApplyName+ N' 所积点申请发放',GETDATE(),
			'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
			--提交事务
			COMMIT TRANSACTION T1;
			--SELECT @applyTo AS 替换前字符串
			SET @applyTo = REPLACE(@applyTo,@SplitFlag,'');--去掉存入了得data
			--SELECT @applyTo AS 现在字符串
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE();--获取错误信息
			ROLLBACK TRANSACTION T1;
			--SET @exchangeReturnNum = -1;
			--SET @exchangeReturnText = ERROR_MESSAGE();
			RETURN -1;--返回错误值（异常退出）
		END CATCH
		END
		ELSE IF(CHARINDEX(@SplitFlag,@applyTo) = 0)
		BEGIN
		--SELECT @applyTo AS 最后一个字符串
			IF(@applyTo<>'')
				BEGIN
					SET @people = SUBSTRING(@applyTo,1,CHARINDEX(':',@applyTo)-1)--取出名称
					--SELECT @people AS 人名
					SET @npoints = REPLACE(@applyTo,@people+':','');
					--SELECT @npoints AS 积点数量
					--进行发钱操作
		BEGIN TRANSACTION T2
		BEGIN TRY
			--加钱
			UPDATE Account
			SET [RestPoints] = [RestPoints] + @npoints,
			NPoints = NPoints + @npoints,
			[LastEditDate] = GETDATE()
			WHERE [Email] = @people+'@newegg.com';
								
			--增加交易记录
			--入账的
			INSERT INTO NPointsHistory
			([AccountName],[State],[Number],
			[Comment],[InDate],
			[InUser],[LastEditUser],[LastEditDate])
			VALUES
			(@people,1,@npoints
			,@ApplyName+ N' 所积点申请发放',GETDATE(),
			'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
			--提交事务
			COMMIT TRANSACTION T2;
			--SET @exchangeReturnNum = 1;
			--SET @exchangeReturnText = N'成功';
			RETURN 1;--返回正常值
		END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE();--获取错误信息
			ROLLBACK TRANSACTION T2;
			--SET @exchangeReturnNum = -1;
			--SET @exchangeReturnText = ERROR_MESSAGE();
			RETURN -1;--返回错误值（异常退出）
		END CATCH
		SET @applyTo = '';--赋值空串，退出循环
		END
		END
	END
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE();--获取错误信息
	--SET @exchangeReturnNum = -1;
	--SET @exchangeReturnText = ERROR_MESSAGE();
	RETURN -1;--返回错误值（异常退出）
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[P_npoint_exchange_az8g]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[P_npoint_exchange_az8g]
(@exchangeOutName VARCHAR(200),
@exchangeAmount DECIMAL(12,2),
@exchangeToName VARCHAR(200))
AS
SET NOCOUNT ON
BEGIN TRY
	DECLARE @CardState INT,
            @Balance DECIMAL(12,2),
            @InBalance DECIMAL(12,2),
            @TempEmail VARCHAR(20),
			@CardNum INT,
			@exchangeToEmail VARCHAR(200),
			@exchangeOutEmail VARCHAR(200);
	--检查收款人是否存在
	SET @exchangeToEmail = @exchangeToName+'@newegg.com';
	SET @exchangeOutEmail = @exchangeOutName+'@newegg.com';
	--SELECT @exchangeToEmail,@exchangeOutEmail
	IF(@exchangeOutEmail<>@exchangeToEmail)
	BEGIN
		SELECT @CardNum = COUNT(*) 
		FROM Account WITH(NOLOCK)
		WHERE [Email] = @exchangeToEmail;
		IF(@CardNum=1)
		BEGIN
			--SELECT @exchangeOutEmail AS Email
			--正确，判定余额
			SELECT @Balance = [RestPoints] 
			FROM dbo.Account WITH(NOLOCK)
			WHERE [Email] = @exchangeOutEmail;
			--SELECT @Balance AS 余额
			--Kayla.H.Shu@newegg.com
			IF(@Balance >= @exchangeAmount)
				BEGIN
				--足够，开始转账
								--正常，开始更新数据
								--使用事务，好回滚
								BEGIN TRANSACTION T1
								BEGIN TRY
									--减钱
									UPDATE Account
									SET [RestPoints] = @Balance - @exchangeAmount,
									[LastEditDate] = GETDATE()
									WHERE [Email] = @exchangeOutEmail;
									--增加交易记录
									--出账的
									INSERT INTO NPointsHistory
									([AccountName],[State],[Number],
									[Comment],[InDate],[InUser],
									[LastEditUser],[LastEditDate])
									VALUES
									(@exchangeOutName,0,@exchangeAmount
									,@exchangeOutName+N' 积点转赠给 '+@exchangeToName
									,GETDATE(),'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
									--加钱
									UPDATE Account
									SET [RestPoints] = [RestPoints] + @exchangeAmount,
									[NPoints] = [NPoints] + @exchangeAmount,
									[LastEditDate] = GETDATE()
									WHERE [Email] = @exchangeToEmail;
								
									--增加交易记录
									--入账的
									INSERT INTO NPointsHistory
									([AccountName],[State],[Number],
									[Comment],[InDate],[InUser],
									[LastEditUser],
									[LastEditDate])
									VALUES
									(@exchangeToName,1,@exchangeAmount
									,@exchangeOutName+N' 积点转赠给 '+@exchangeToName
									,GETDATE(),'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
									--提交事务
									COMMIT TRANSACTION T1;
									--SET @exchangeReturnNum = 1;
									--SELECT @exchangeReturnText = N'成功';
									RETURN 1;--返回正常值
								END TRY
								BEGIN CATCH
									--SELECT ERROR_MESSAGE();--获取错误信息
									ROLLBACK TRANSACTION T1;
									--SET @exchangeReturnNum = -1;
									--SELECT @exchangeReturnText = ERROR_MESSAGE();
									RETURN -1;--返回错误值（异常退出）
								END CATCH
				END
				ELSE
					BEGIN
						INSERT INTO NPointsHistory
							([AccountName],[State],[Number],
							[Comment],[InDate],
							[InUser],[LastEditUser],[LastEditDate])
							VALUES
							(@exchangeOutName,0,@exchangeAmount
							,@exchangeOutName+N' 积点转赠给 '+@exchangeToName+N'失败，账户余额不足'
							,GETDATE(),'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
						--SET @exchangeReturnNum = 0;
						--SELECT @exchangeReturnText = N'账户余额不足';
						RETURN 0;--返回错误值（逻辑退出）
					END
		END
		ELSE
		BEGIN
			--增加交易记录
			--出账的
			INSERT INTO NPointsHistory
					([AccountName],[State],[Number],
					[Comment],[InDate],[InUser],[LastEditUser],[LastEditDate])
					VALUES
					(@exchangeOutName,0,@exchangeAmount
					,@exchangeOutName+N' 积点转赠给 '+@exchangeToName+N'失败,对方账户不存在'
					,GETDATE(),'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
			--SET @exchangeReturnNum = 2;
			--SELECT @exchangeReturnText = N'对方账户不存在';
			RETURN -2;--返回错误值（逻辑退出）
		END
	END
	ELSE
	BEGIN
	--增加交易记录
			--出账的
			INSERT INTO NPointsHistory
					([AccountName],[State],[Number],
					[Comment],[InDate],[InUser],[LastEditUser],[LastEditDate])
					VALUES
					(@exchangeOutName,0,@exchangeAmount
					,@exchangeOutName+N' 积点转赠给 '+@exchangeToName+N'失败,无法自己转赠自己'
					,GETDATE(),'Alvin.X.Zhang','Alvin.X.Zhang',GETDATE());
			RETURN -3;--返回错误值（逻辑退出）
	END
END TRY
BEGIN CATCH
--SELECT ERROR_MESSAGE();--获取错误信息
--SET @exchangeReturnNum = -1;
--SELECT @exchangeReturnText = ERROR_MESSAGE();
RETURN -1;--返回错误值（异常退出）
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[TEST1]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TEST1]
  @PA1 INT,
  @PA2 INT
AS
  RETURN @PA1+@PA2

GO
/****** Object:  StoredProcedure [dbo].[UP_YourProcName]    Script Date: 1/5/2018 11:18:34 上午 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*================================================================================  
Server:    ?  
DataBase:  ?
Team:	   ?  
Author:    ?
Object:    ? 
Version:   1.0  
Date:      ??/??/????
Content:   ?
----------------------------------------------------------------------------------  
Modified history:      
      
Date        Modified by    VER    Description      
------------------------------------------------------------  
??/??/????  ??			   1.0    Create.  
================================================================================*/  

CREATE PROCEDURE [dbo].[UP_YourProcName] 
	@Parameter   INT
AS
SET NOCOUNT ON
--Put your code in here
GO
USE [master]
GO
ALTER DATABASE [NPoint] SET  READ_WRITE 
GO
