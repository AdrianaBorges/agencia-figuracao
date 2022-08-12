Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaCidadesPorEstado]
	@idestado int
AS
		
BEGIN
	Begin Try

		Select
			c.idcidade,
			c.descricao
		From Cidade c
		Where c.idestado = @idestado
		Order by c.descricao

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

