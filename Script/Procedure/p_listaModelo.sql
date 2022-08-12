Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaModelo]
AS

BEGIN
	Begin Try
	
		Select
			m.idmodelo,
			m.descricao
		From Modelo m
		
		order by m.descricao

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END