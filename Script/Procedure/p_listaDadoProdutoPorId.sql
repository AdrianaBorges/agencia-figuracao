
Use[dbAgencia]
Go

create PROCEDURE [dbo].p_listaDadoProdutoPorId
	@idpessoa int = 0
AS
		
BEGIN

	Begin Try
	
		Select
			replicate('0', 5 - Len(dp.id)) + rtrim(dp.id) as id,
			replicate('0', 5 - Len(pg.idprograma)) + rtrim(pg.idprograma) + ' - ' + pg.descricao as descricao,
			pg.idprograma

		From DadoPrograma dp
		Inner Join Programa pg on pg.idprograma = dp.idprograma
		Where dp.idpessoa = @idpessoa
		Order by pg.descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END