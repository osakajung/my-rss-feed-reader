INSERT INTO [RSSFeedDatabase].[dbo].[SUBSCRIBE]
           ([FEED_feed_id]           
           ,[USER_user_id])           
     SELECT 1, [user_id] FROM [RSSFeedDatabase].[dbo].[USER] WHERE [user_email] = 'admin@admin.com'
GO