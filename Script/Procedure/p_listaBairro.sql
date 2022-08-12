Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaBairro]
	
AS
		
BEGIN
	Begin Try

		Select
			b.idbairro,
			b.nmebairro,
			c.idcidade,
			e.idestado

		From Bairro b
		Inner Join Cidade c on c.idcidade = b.idcidade
		Inner Join Estado e on e.idestado = c.idestado

		Order by b.nmebairro

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END



