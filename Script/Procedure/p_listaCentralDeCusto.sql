USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_listaCentralDeCusto]
	@idbase int
AS
BEGIN
	Begin Try
		
		Select 
			idcentraldecusto,
			descricao	
		From CentralDeCusto
		Where idbase = @idbase
		Order by descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END