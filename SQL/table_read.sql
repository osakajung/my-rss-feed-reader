USE [RSSFeedDatabase]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_READ_ITEM]') AND parent_object_id = OBJECT_ID(N'[dbo].[READ]'))
ALTER TABLE [dbo].[READ] DROP CONSTRAINT [FK_READ_ITEM]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_READ_USER]') AND parent_object_id = OBJECT_ID(N'[dbo].[READ]'))
ALTER TABLE [dbo].[READ] DROP CONSTRAINT [FK_READ_USER]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[READ]    Script Date: 10/29/2011 14:10:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[READ]') AND type in (N'U'))
DROP TABLE [dbo].[READ]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[READ]    Script Date: 10/29/2011 14:10:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[READ](
	[user_id] [bigint] NOT NULL,
	[item_id] [bigint] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[READ]  WITH CHECK ADD  CONSTRAINT [FK_READ_ITEM] FOREIGN KEY([item_id])
REFERENCES [dbo].[ITEM] ([item_id])
GO

ALTER TABLE [dbo].[READ] CHECK CONSTRAINT [FK_READ_ITEM]
GO

ALTER TABLE [dbo].[READ]  WITH CHECK ADD  CONSTRAINT [FK_READ_USER] FOREIGN KEY([user_id])
REFERENCES [dbo].[USER] ([user_id])
GO

ALTER TABLE [dbo].[READ] CHECK CONSTRAINT [FK_READ_USER]
GO

