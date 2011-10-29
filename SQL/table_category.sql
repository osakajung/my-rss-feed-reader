USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[CATEGORY]    Script Date: 10/29/2011 14:09:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CATEGORY]') AND type in (N'U'))
DROP TABLE [dbo].[CATEGORY]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[CATEGORY]    Script Date: 10/29/2011 14:09:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CATEGORY](
	[category_id] [bigint] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

