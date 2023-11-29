USE [FacturadorDB]
GO

/****** Object:  View [dbo].[VistaFacturasClientes]    Script Date: 29/11/2023 18:54:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VistaFacturasClientes] AS
SELECT
    FC.FC_ID,
    FC.Fecha_Alta,
    C.Razon_Social,
    C.CUIT
FROM
    Factura_Cabecera FC
INNER JOIN
	Cliente C ON FC.Cli_Id = C.Cli_Id;
GO


