Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaEmpresa]
	
AS
		
BEGIN
	Begin Try

		Select 
			e.idempresa,
			e.descricao

		From Empresa e

		Order by e.descricao

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END
