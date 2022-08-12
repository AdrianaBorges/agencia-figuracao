Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaMarca]
	
AS

BEGIN
	Begin Try
	
		Select
			m.idmarca,
			m.descricao
		From Marca m
		order by m.descricao

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

