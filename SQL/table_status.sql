USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[STATUS]    Script Date: 10/29/2011 14:06:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[STATUS]') AND type in (N'U'))
DROP TABLE [dbo].[STATUS]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[STATUS]    Script Date: 10/29/2011 14:06:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[STATUS](
	[status_id] [bigint] IDENTITY(1,1) NOT NULL,
	[status_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_STATUS] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

