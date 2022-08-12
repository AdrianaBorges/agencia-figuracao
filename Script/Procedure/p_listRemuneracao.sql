Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaRemuneracao]
	
AS
		
BEGIN
	Begin Try

		Select
			r.idremuneracao,
			r.descricao,
			r.idextra
		From Remuneracao r
		order by r.descricao

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

