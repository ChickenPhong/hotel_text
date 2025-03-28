SELECT TOP (1000) [roomid]
      ,[roomNo]
      ,[roomType]
      ,[bed]
      ,[price]
      ,[booked]
  FROM [hoteldb].[dbo].[rooms]
DELETE FROM [hoteldb].[dbo].[rooms]
WHERE roomid = 4;