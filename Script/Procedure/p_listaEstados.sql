Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaEstados]
	
AS
		
BEGIN
	Begin Try

		Select
			e.idestado,
			e.nmeestado
		From Estado e

		Order by e.nmeestado

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END



