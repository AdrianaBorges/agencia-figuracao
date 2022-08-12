Use[luzecorcasting]
Go

alter PROCEDURE p_listaUsuario
	@status int = 0
AS
		
BEGIN

	Begin Try

		select 
			idpessoa,
			nmepessoa
		from pessoa 
		where idtipopessoa = 1 and status = 1
		order by nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch
END