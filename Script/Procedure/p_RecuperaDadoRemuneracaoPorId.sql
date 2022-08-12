Use[dbAgencia]
Go

create PROCEDURE [dbo].p_RecuperaDadoRemuneracaoPorId
	@id int = 0
AS
		
BEGIN

	Begin Try

		Select
			d.id,
			d.idremuneracao,
			r.descricao,
			d.valor
			
		From DadoRemuneracao d
		Inner Join Remuneracao r on r.idremuneracao = d.idremuneracao 
		Where d.id = @id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END