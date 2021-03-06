USE [master]
GO
/****** Object:  Database [Talycapglobal]    Script Date: 11/04/2021 17:53:22 ******/
CREATE DATABASE [Talycapglobal] 
GO
USE [Talycapglobal]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 11/04/2021 17:53:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Author](
	[Id] [bigint] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/04/2021 17:54:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[Id] [bigint] NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[PageCount] [int] NOT NULL,
	[Excerpt] [varchar](max) NOT NULL,
	[PublishDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorBook]    Script Date: 11/04/2021 17:54:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AuthorBook](
	[IdBook] [bigint] NOT NULL,
	[IdAuthor] [bigint] NOT NULL,
 CONSTRAINT [PK_AuthorBook] PRIMARY KEY CLUSTERED 
(
	[IdBook] ASC,
	[IdAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AuthorBook]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBook_Author] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Author] ([Id])
GO

ALTER TABLE [dbo].[AuthorBook] CHECK CONSTRAINT [FK_AuthorBook_Author]
GO

ALTER TABLE [dbo].[AuthorBook]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBook_Book] FOREIGN KEY([IdBook])
REFERENCES [dbo].[Book] ([Id])
GO

ALTER TABLE [dbo].[AuthorBook] CHECK CONSTRAINT [FK_AuthorBook_Book]
GO

USE [master]
GO
ALTER DATABASE [Talycapglobal] SET  READ_WRITE 
GO

/*Application Login and user creation*/
USE [master]
GO

CREATE LOGIN [Talycapglobal] WITH PASSWORD='123456', DEFAULT_DATABASE=[Talycapglobal], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [master]
GO
ALTER LOGIN [Talycapglobal] WITH PASSWORD=N'Zemog@!P@ssword'
GO
USE [Talycapglobal]
GO
CREATE USER [Talycapglobal] FOR LOGIN [Talycapglobal]
GO
USE [Talycapglobal]
GO
ALTER USER [Talycapglobal] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [Talycapglobal]
GO
ALTER ROLE [db_owner] ADD MEMBER [Talycapglobal]
GO

/*End of script*/
