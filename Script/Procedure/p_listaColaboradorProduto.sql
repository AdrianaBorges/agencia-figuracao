Use[dbAgencia]
Go

create PROCEDURE [dbo].p_listaColaboradorProduto
	@idproduto int = 0,
	@idpedido int = 0
AS
		
BEGIN

	Begin Try
	
		Select
			p.idpessoa,
			p.nmepessoa
		From DadoPrograma pc
		Inner Join Pessoa p on p.idpessoa = pc.idpessoa
		Where pc.idprograma = @idproduto
			and p.idpessoa not in (Select ep.idpessoa From EquipePedido ep Where ep.idpedido = @idpedido)
		Group by p.idpessoa, p.nmepessoa
		Order by p.nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END