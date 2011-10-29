USE [RSSFeedDatabase]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ITEM_FEED]') AND parent_object_id = OBJECT_ID(N'[dbo].[ITEM]'))
ALTER TABLE [dbo].[ITEM] DROP CONSTRAINT [FK_ITEM_FEED]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[ITEM]    Script Date: 10/29/2011 14:10:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITEM]') AND type in (N'U'))
DROP TABLE [dbo].[ITEM]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[ITEM]    Script Date: 10/29/2011 14:10:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ITEM](
	[item_id] [bigint] IDENTITY(1,1) NOT NULL,
	[item_title] [nvarchar](150) NOT NULL,
	[item_link] [nvarchar](150) NOT NULL,
	[item_description] [text] NOT NULL,
	[feed_id] [bigint] NOT NULL,
 CONSTRAINT [PK_ITEM] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_FEED] FOREIGN KEY([feed_id])
REFERENCES [dbo].[FEED] ([feed_id])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_FEED]
GO

