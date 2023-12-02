USE [FacturadorDB]
GO

/****** Object:  StoredProcedure [dbo].[FC_Cliente_delete]    Script Date: 2/12/2023 18:10:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FC_Cliente_delete]


@ClientID int

as

begin

UPDATE [Factura_Cabecera] SET Cli_ID = 9999 where Cli_ID = @ClientID 

end
GO


