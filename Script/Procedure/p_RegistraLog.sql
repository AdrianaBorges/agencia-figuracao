
Use[dbAgencia]
Go

create PROCEDURE [dbo].[p_RegistraLog]
	@idformulario int,
	@descricao nvarchar(100),
	@observacao nvarchar(100) = '',
	@idcolaborador int
AS
	declare @widentificador nvarchar(25) = ''
	--set @widentificador = CAST(GETDATE() AS DATETIME)
	select @widentificador = CAST(GETDATE() AS DATETIME)
	begin try
		begin transaction
				insert into registrolog(identificador, idformulario, descricao, observacao, idcolaborador) values (@widentificador, @idformulario, @descricao, @observacao,@idcolaborador) 

		commit

	end try

	begin catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	end catch

RETURN
