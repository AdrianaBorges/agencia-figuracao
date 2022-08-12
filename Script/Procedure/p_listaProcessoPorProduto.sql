
alter PROCEDURE [dbo].[p_listaProcessoPorProduto]
	@idprograma int = 0
AS
BEGIN
	Begin Try
				
		Select
			al.idalvara,
			al.numprocesso

		From Alvara al
		where al.idprograma = @idprograma
		Order by al.data
		
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END


