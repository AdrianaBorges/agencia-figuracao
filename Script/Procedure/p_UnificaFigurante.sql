USE [luzecorcasting]
GO

create PROCEDURE [dbo].[p_UnificaFigurante]
	@idcerto int,
	@iderrado int

AS

Begin

	Begin try
	
		Begin transaction
			delete from pessoa where idpessoa = @iderrado
			delete from figurante where idpessoa = @iderrado 

			update pedidofigurante 
				set idpessoa = @idcerto 
					where idpessoa = @iderrado
			
			update provisaofigurante 
				set idpessoa = @idcerto 
					where idpessoa = @iderrado
			
			update LANCAMENTO 
				set IDPESSOA = @idcerto 
					where idpessoa = @iderrado
			
			update baixa
				set idpessoa = @idcerto
					where idpessoa = @iderrado
		commit
	
	end try

	begin catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	end catch

End
