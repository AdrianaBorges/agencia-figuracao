Use [dbagencia]
Go

create PROCEDURE p_listaProdutoDisponivel
    @idpessoa int = 0
AS
BEGIN

	Begin Try
        Select 
			p.idprograma, p.descricao 
		From Programa p
		Where p.idprograma 
						not in (Select dp.idprograma From DadoPrograma dp Where dp.idpessoa = @idpessoa)
		order by descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END