USE [Lab]
GO

/****** Object:  Table [dbo].[TabA]    Script Date: 03/03/2020 16:56:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TabA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NULL,
	[value] [float] NULL
) ON [PRIMARY]

GO

