USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_listaCargo]
AS
BEGIN
	Begin Try
		select
			idcargo,
			descricao,
			idpermissao

		from cargo
		order by descricao
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END