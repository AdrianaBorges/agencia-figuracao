Use[dbAgencia]
Go

alter PROCEDURE [dbo].[p_AjustaDuplicidade]

	@iderrado int,
	@idcerto int
AS
	Declare
		@nmepessoa nvarchar(100)
		
	begin try
	
		begin transaction
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

	
	Select @nmepessoa = nmepessoa 
	From Pessoa 
		Where idpessoa = @idcerto
	
	print 'Registro do(a) Figurante: ' + @nmepessoa + ', ajustado'
	
	end try

	begin catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	end catch

RETURN
