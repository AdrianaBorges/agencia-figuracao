USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_listaBase]
AS
BEGIN
	Begin Try
		select
			idbase,
			descricao

		from Base
		order by descricao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END