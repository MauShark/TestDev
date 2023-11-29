USE [FacturadorDB]
GO

/****** Object:  Table [dbo].[Factura_Detalle]    Script Date: 29/11/2023 18:54:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Factura_Detalle](
	[Fact_ID] [int] NOT NULL,
	[FC_DTL_ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Alta] [datetime] NOT NULL,
	[ART_ID] [int] NOT NULL,
	[Cant] [decimal](18, 0) NULL,
	[Precio] [decimal](18, 0) NULL,
	[Monto] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Factura_Detalle] PRIMARY KEY CLUSTERED 
(
	[FC_DTL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Factura_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Detalle_Articulo] FOREIGN KEY([ART_ID])
REFERENCES [dbo].[Articulo] ([ART_ID])
GO

ALTER TABLE [dbo].[Factura_Detalle] CHECK CONSTRAINT [FK_Factura_Detalle_Articulo]
GO

ALTER TABLE [dbo].[Factura_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Detalle_Factura_Cabecera] FOREIGN KEY([Fact_ID])
REFERENCES [dbo].[Factura_Cabecera] ([FC_ID])
GO

ALTER TABLE [dbo].[Factura_Detalle] CHECK CONSTRAINT [FK_Factura_Detalle_Factura_Cabecera]
GO


