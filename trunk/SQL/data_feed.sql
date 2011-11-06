INSERT INTO [RSSFeedDatabase].[dbo].[FEED]
           ([feed_title]           
           ,[feed_address]
           ,[feed_link]
           ,[feed_description]
           ,[category_id])           
     VALUES
           ('Christophe Fiessinger Blog'
           ,'http://blogs.msdn.com/b/chrisfie/rss.aspx'
           ,'http://blogs.msdn.com/b/chrisfie/'
		   ,'The latest news you need to know about Microsoft Project'
           ,1)
GO