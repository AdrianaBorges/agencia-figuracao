USE [luzecorcasting]
GO

alter PROCEDURE [dbo].[p_RecuperaFolhaPorId]
	@idfolha int 

AS
	
BEGIN

	Begin Try

		Select 
			f.idfolha, 
			f.dtgeracao,
			f.status,
			dbo.RetornaMesExtenso(f.mesref) as mesref,
			f.de,
			f.ate,
			f.descricao,
			coalesce(f.observacao,'') as observacao,
			f.dtliberacao
			
		From folha f
		left join dadofolha df on df.idfolha = f.idfolha
		left join equipepgpedido ep on ep.idfolha = f.idfolha
		
		Where f.idfolha = @idfolha
		Group by f.idfolha, f.dtgeracao, f.mesref, f.de, f.ate, f.descricao, f.observacao, f.status,f.dtliberacao 

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

End