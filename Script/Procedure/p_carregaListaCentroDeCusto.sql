USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_carregaListaCentroDeCusto]
	
AS
BEGIN
	Begin Try
		
		Select
			c.idcusto, 
			c.descricao,
			b.descricao,
			cd.descricao,
			c.observacao
		From CentroDeCusto c
		Inner Join CentralDeCusto cd on cd.idcentraldecusto = c.idcentraldecusto
		Inner Join Base b on b.idbase = cd.idbase
		Order by c.descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END 