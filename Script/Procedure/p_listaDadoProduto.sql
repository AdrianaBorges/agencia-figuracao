
Use [dbAgencia]
Go

create PROCEDURE [dbo].p_listaDadoProduto
	@idpessoa int = 0
AS
		
BEGIN

	Begin Try
	
		Select
			pc.id,
			pc.idprograma,
			replicate('0', 5 - Len(pg.idprograma)) + rtrim(pg.idprograma) + ' - ' + pg.descricao as descricao
		From DadoPrograma pc
		Inner Join Programa pg on pg.idprograma = pc.idprograma
		Where pc.idpessoa = @idpessoa
		Order by pg.descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END