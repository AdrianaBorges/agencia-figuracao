USE [luzecorcasting]
GO

alter PROCEDURE [dbo].[p_listaFolhaPgto]

AS
	
BEGIN

	Begin Try

		Select 
			dbo.FormataCodigo(f.idfolha, 'M') as idfolha, 
			dbo.FormataData(f.dtgeracao) as dtgeracao,
			dbo.RetornaMes(f.mesref) as mes,
			dbo.FormataData(f.de) + ' até ' + dbo.FormataData(f.ate) as periodo,
			
			f.descricao,
			coalesce(f.observacao,'') as observacao,
			dbo.FormataData(f.de) as de,
			dbo.FormataData(f.ate) as ate,
			case f.status
				when 1 then 'PAGA EM: ' + dbo.FormataData(f.dtliberacao)
				else case f.dtliberacao 
					when null then '' 
					else 'LIBERADA PARA PAGTO. EM: ' + dbo.FormataData(f.dtliberacao)
					end
			end  as status
		from
			folha f
			left join dadofolha df on df.idfolha = f.idfolha
			left join equipepgpedido ep on ep.idfolha = f.idfolha

		Group by f.idfolha, f.dtgeracao, f.mesref, f.de, f.ate, f.descricao, f.observacao, f.status,f.dtliberacao 
		Order by f.ate
		
	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
End