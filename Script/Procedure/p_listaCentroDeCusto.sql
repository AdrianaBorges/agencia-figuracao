USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_listaCentroDeCusto]
	@idcentraldecusto int
AS
BEGIN
	Begin Try
		
		Select * From CentroDeCusto
		Select
			idcusto,
			descricao
		From CentroDeCusto
		Where idcentraldecusto = @idcentraldecusto
		Order by descricao	

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END