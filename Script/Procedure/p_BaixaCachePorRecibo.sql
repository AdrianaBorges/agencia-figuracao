USE [luzecorcasting]
GO
/****** Object:  StoredProcedure [dbo].[p_baixaCachePorRecibo]    Script Date: 02/23/2014 11:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[p_baixaCachePorRecibo]
	@idpessoa int,
	@nrrb decimal (14,0),
	@databaixa date

AS
	declare
	@wwrecibo char(14)

BEGIN

	Begin Try
		Begin tran
		exec p_geraRecibo @databaixa, @wwrecibo output 

		declare @widregisgtro int
		declare cursor_temp cursor for
			select idregistro
			from tmppgto
				where idpessoa = @idpessoa
					and recibo = @nrrb

		open cursor_temp
		fetch next from cursor_temp into @widregisgtro

		while @@fetch_status = 0
		begin
			update pedidofigurante set status = 1, dtpagamento = @databaixa, nrrb = @wwrecibo
			where idpessoa = @idpessoa and id = @widregisgtro

		fetch next from cursor_temp into @widregisgtro
		end	

		close cursor_temp
		deallocate cursor_temp

		delete from tmprecibo where idpessoa = @idpessoa and recibo = @nrrb
		delete from tmppgto where idpessoa = @idpessoa and recibo = @nrrb

		commit

	End Try

	Begin Catch
		
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

end