USE NPoint
Go
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

DECLARE @result int
exec OrderConfim  'al5i1329694:1','Tina.H.Huang@newegg.com','Tina.H.Huang@newegg.com',1,'th40', @result output
SELECT @result AS Result
go

drop  procedure OrderConfim

SELECT * from Products
SELECT * from OrderList
SELECT * from NPointsHistory

SELECT * from Account WHERE ShortName = 'th40'

SELECT convert(varchar(19),getdate(),126)
