
Go

ALTER PROCEDURE [dbo].p_RecuperaDadoBancarioPorId
	@id int = 0
AS
		
BEGIN

	Begin Try

	--raiserror 30005 'ERRO RECUPERAR OS DADOS BANCARIOS.'
		select 
				db.id, --0
				case db.status when 1 then 'ATIVO' when 0 then 'INATIVO' end as status, --1
				bc.idbanco,--2
				bc.numero + '-' + bc.nmebanco as nmebanco, --3
				case db.tipo when 'C' then 'CORRENTE' when 'P' then 'POUPANÇA' end as tipo,--4
				db.agencia, --5
				db.numconta, --6
				db.titular, --7
				db.idpessoa --8
		from dadobancario db 
		inner join banco bc on bc.idbanco=db.idbanco 
		where db.id = @id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END