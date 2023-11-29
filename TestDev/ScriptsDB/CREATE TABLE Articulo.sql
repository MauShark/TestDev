USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Articulo]    Script Date: 29/11/2023 18:54:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
	[ART_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Stock] [int] NULL,
	[Fecha_Alta] [datetime] NOT NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[ART_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


