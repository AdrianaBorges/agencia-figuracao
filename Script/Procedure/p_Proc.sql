Use [dbAgencia]
Go

alter PROCEDURE [dbo].[p_Proc]
	@idpessoa int
AS
		
BEGIN
	Begin Try

		Select * from pessoa where idpessoa = @idpessoa


	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END
