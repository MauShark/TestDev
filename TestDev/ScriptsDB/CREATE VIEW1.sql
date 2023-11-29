USE [FacturadorDB]
GO

/****** Object:  View [dbo].[VistaFacturas]    Script Date: 29/11/2023 18:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[VistaFacturas] AS
SELECT
    FC.FC_ID,
    FC.Estado,
    SUM(FD.Monto) AS Total
FROM
    Factura_Cabecera FC
INNER JOIN
    Factura_Detalle FD ON FC.FC_ID = FD.Fact_ID
GROUP BY
    FC.FC_ID,
    FC.Estado
GO


