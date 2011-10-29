USE [RSSFeedDatabase]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SUBSCRIBE_FEED]') AND parent_object_id = OBJECT_ID(N'[dbo].[SUBSCRIBE]'))
ALTER TABLE [dbo].[SUBSCRIBE] DROP CONSTRAINT [FK_SUBSCRIBE_FEED]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SUBSCRIBE_USER]') AND parent_object_id = OBJECT_ID(N'[dbo].[SUBSCRIBE]'))
ALTER TABLE [dbo].[SUBSCRIBE] DROP CONSTRAINT [FK_SUBSCRIBE_USER]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[SUBSCRIBE]    Script Date: 10/29/2011 14:11:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SUBSCRIBE]') AND type in (N'U'))
DROP TABLE [dbo].[SUBSCRIBE]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[SUBSCRIBE]    Script Date: 10/29/2011 14:11:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SUBSCRIBE](
	[user_id] [bigint] NOT NULL,
	[feed_id] [bigint] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SUBSCRIBE]  WITH CHECK ADD  CONSTRAINT [FK_SUBSCRIBE_FEED] FOREIGN KEY([feed_id])
REFERENCES [dbo].[FEED] ([feed_id])
GO

ALTER TABLE [dbo].[SUBSCRIBE] CHECK CONSTRAINT [FK_SUBSCRIBE_FEED]
GO

ALTER TABLE [dbo].[SUBSCRIBE]  WITH CHECK ADD  CONSTRAINT [FK_SUBSCRIBE_USER] FOREIGN KEY([user_id])
REFERENCES [dbo].[USER] ([user_id])
GO

ALTER TABLE [dbo].[SUBSCRIBE] CHECK CONSTRAINT [FK_SUBSCRIBE_USER]
GO

