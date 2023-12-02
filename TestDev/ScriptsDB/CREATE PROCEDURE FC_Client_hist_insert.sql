USE [FacturadorDB]
GO

/****** Object:  StoredProcedure [dbo].[Fc_Client_Hist_insert]    Script Date: 2/12/2023 18:11:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Fc_Client_Hist_insert]

@FcCabecera int,
@ClientId int
as

begin

declare @hoy datetime= getdate()
INSERT INTO Facturas_ClienteHIST VALUES(@FcCabecera,@ClientId,@hoy);


end
GO


