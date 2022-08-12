Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaDadoRemuneracao]
	@idpessoa int

AS
		
BEGIN
	Begin Try

		Select
			REPLICATE('0', 5 - LEN(d.id)) + RTrim(d.id) as id,
			r.descricao,
			convert(decimal(18,2), d.valor) as valor,
			d.idremuneracao
			
		From DadoRemuneracao d
		Inner Join Remuneracao r on r.idremuneracao = d.idremuneracao 
		Where d.idpessoa = @idpessoa

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END