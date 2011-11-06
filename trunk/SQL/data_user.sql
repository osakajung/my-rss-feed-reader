INSERT INTO [RSSFeedDatabase].[dbo].[USER]
           ([user_email]
           ,[user_password]
           ,[user_connected]
           ,[user_key]
           ,[status_id]
           ,[role_id])
     VALUES
           ('admin@admin.com'
           ,CONVERT(VARCHAR(32), HashBytes('MD5', 'admin'), 2)
           ,0
		   ,CONVERT(VARCHAR(32), HashBytes('MD5', 'admin@admin.com'), 2)
           ,2
           ,1)
GO


