USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 29/11/2023 18:54:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Cli_ID] [int] IDENTITY(1000,1) NOT NULL,
	[Razon_Social] [varchar](50) NOT NULL,
	[CUIT] [varchar](16) NOT NULL,
	[Direccion] [varchar](250) NULL,
	[Deshabilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cli_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


