USE [RSSFeedDatabase]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USER_ROLE]') AND parent_object_id = OBJECT_ID(N'[dbo].[USER]'))
ALTER TABLE [dbo].[USER] DROP CONSTRAINT [FK_USER_ROLE]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_USER_STATUS]') AND parent_object_id = OBJECT_ID(N'[dbo].[USER]'))
ALTER TABLE [dbo].[USER] DROP CONSTRAINT [FK_USER_STATUS]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[USER]    Script Date: 11/03/2011 15:33:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USER]') AND type in (N'U'))
DROP TABLE [dbo].[USER]
GO

USE [RSSFeedDatabase]
GO

/****** Object:  Table [dbo].[USER]    Script Date: 11/03/2011 15:33:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USER](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_email] [nvarchar](50) NOT NULL UNIQUE,
	[user_password] [nvarchar](32) NOT NULL,
	[user_connected] [smallint] NOT NULL,
	[user_key] [nvarchar](32) NOT NULL UNIQUE,
	[status_id] [bigint] NOT NULL,
	[role_id] [bigint] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLE] FOREIGN KEY([role_id])
REFERENCES [dbo].[ROLE] ([role_id])
GO

ALTER TABLE [dbo].[USER] CHECK CONSTRAINT [FK_USER_ROLE]
GO

ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [FK_USER_STATUS] FOREIGN KEY([status_id])
REFERENCES [dbo].[STATUS] ([status_id])
GO

ALTER TABLE [dbo].[USER] CHECK CONSTRAINT [FK_USER_STATUS]
GO


