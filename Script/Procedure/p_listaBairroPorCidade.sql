Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaBairroPorCidade]
	@idcidade int
AS
		
BEGIN
	Begin Try

		Select
			b.idbairro,
			c.idcidade,
			e.idestado,
			b.nmebairro
		From Bairro b
		Inner Join Cidade c on c.idcidade = b.idcidade
		Inner Join Estado e on e.idestado = c.idestado

		Where c.idcidade = @idcidade

		Order by b.nmebairro

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

