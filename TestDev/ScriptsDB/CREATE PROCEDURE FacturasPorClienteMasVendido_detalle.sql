USE [FacturadorDB]
GO

/****** Object:  StoredProcedure [dbo].[FacturasPorClienteProductoMasVendido_detalle]    Script Date: 29/11/2023 18:58:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[FacturasPorClienteProductoMasVendido_detalle]
@FechaDesde datetime,
@FechaHasta datetime,
@cliente int
as 

begin 

SELECT
distinct C.Razon_social as Cliente, FC.FC_ID as factura,FC.Fecha_Alta ,FC.Estado, A.Nombre,FD.cant,FD.Precio,FD.Monto ,SUM (FD.cant)OVER (partition by a.art_ID,c.Cli_ID) as CantVendida

FROM CLIENTE C
INNER JOIN Factura_Cabecera FC WITH (NOLOCK)
ON FC.Cli_ID = C.Cli_ID
INNER JOIN Factura_Detalle FD WITH (NOLOCK) 
ON FD.Fact_ID = FC.FC_ID
INNER JOIN ARTICULO A WITH (NOLOCK)
ON A.ART_ID = FD.ART_ID

WHERE c.Cli_ID = @cliente and FC.Fecha_Alta between @FechaDesde and @FechaHasta
END
GO


