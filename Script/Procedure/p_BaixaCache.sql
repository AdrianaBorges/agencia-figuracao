Use luzecorcasting
Go

alter PROCEDURE [dbo].[p_baixaCache]
	@idpessoa int,
	@idpedidofig int,
	@databaixa datetime,
	@recibo decimal

AS

BEGIN

	Begin Try
		--exec p_geraRecibo @databaixa, @wwrecibo output 

		begin transaction
			update PedidoFigurante set status = 1, dtpagamento = @databaixa, nrrb = @recibo
			where idpessoa = @idpessoa 
				and id = @idpedidofig
		commit

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END

