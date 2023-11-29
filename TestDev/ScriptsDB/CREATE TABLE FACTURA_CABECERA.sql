USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Factura_Cabecera]    Script Date: 29/11/2023 18:54:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura_Cabecera](
	[FC_ID] [int] IDENTITY(2000,1) NOT NULL,
	[Fecha_Alta] [datetime] NOT NULL,
	[Cli_ID] [int] NOT NULL,
	[Estado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[FC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Factura_Cabecera]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cabecera_Cliente] FOREIGN KEY([Cli_ID])
REFERENCES [dbo].[Cliente] ([Cli_ID])
GO

ALTER TABLE [dbo].[Factura_Cabecera] CHECK CONSTRAINT [FK_Factura_Cabecera_Cliente]
GO


