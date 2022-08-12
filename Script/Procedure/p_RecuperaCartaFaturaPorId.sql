USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_RecuperaCartaFaturaPorId]
	
	@idcartafatura int
AS

BEGIN

	Begin Try

		SELECT
			cf.idcartafatura,
			cf.idnota,
			cf.numcarta,
			CONVERT(VARCHAR(10), cf.dtemissao, 105) as dtemissao,
			cf.idprograma,
			cf.observacao,
			cf.idfirma
	
		FROM
			CartaFatura AS cf 
			INNER JOIN Programa AS prg ON prg.idprograma = cf.idprograma 
			    
		where cf.idcartafatura = @idcartafatura

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END