USE [luzecorcasting]
Go

alter PROCEDURE [dbo].[p_geraRecibo]
	@data date,
	@recibo char(14) output
AS
	declare 
		@hora char(10)
BEGIN

	Begin Try
		-- Modelo do recibo: 2013 + 06 + 21 + 19 + 05
		-- ano + 2 zeros + mes + dia + hora + minuto
		-- 20130006211905
	
		set @hora = substring(CONVERT(VARCHAR(10),GETDATE(),108),1,2) + 
					substring(CONVERT(VARCHAR(10),GETDATE(),108),4,2) +
					substring(CONVERT(VARCHAR(10),GETDATE(),108),7,2) --20:35:57
		set @recibo = CONVERT(VARCHAR(10),@data,112) + @hora
		--select @recibo
		--return @recibo
	
	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END
