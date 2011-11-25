USE [RSSFeedDatabase]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FEED_CATEGORY]') AND parent_object_id = OBJECT_ID(N'[dbo].[FEED]'))
ALTER TABLE [dbo].[FEED] DROP CONSTRAINT [FK_FEED_CATEGORY]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[FEED]    Script Date: 10/29/2011 14:10:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FEED]') AND type in (N'U'))
DROP TABLE [dbo].[FEED]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[FEED]    Script Date: 10/29/2011 14:10:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FEED](
	[feed_id] [bigint] IDENTITY(1,1) NOT NULL,
	[feed_title] [text] NOT NULL,
	[feed_address] [text] NOT NULL,
	[feed_link] [text] NOT NULL,
	[feed_description] [text] NOT NULL,
	[category_id] [bigint] NULL,
 CONSTRAINT [PK_FEED] PRIMARY KEY CLUSTERED 
(
	[feed_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[FEED]  WITH CHECK ADD  CONSTRAINT [FK_FEED_CATEGORY] FOREIGN KEY([category_id])
REFERENCES [dbo].[CATEGORY] ([category_id]) ON DELETE SET NULL
GO

ALTER TABLE [dbo].[FEED] CHECK CONSTRAINT [FK_FEED_CATEGORY]
GO

