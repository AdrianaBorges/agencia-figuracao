Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaDadoBancario]
    @idpessoa int
AS
BEGIN

	Begin Try

		select 
				REPLICATE('0', 5 - LEN(db.id)) + RTrim(db.id) as id,
				case db.status when 1 then '01- ATIVO' when 0 then '00- INATIVO' end as status, 
				bc.numero + '-' + bc.nmebanco as nmebanco, 
				case db.tipo when 'C' then 'CORRENTE' when 'P' then 'POUPANÇA' end as tipo,
				db.agencia, 
				db.numconta, 
				db.titular, db.idpessoa 
		from dadobancario db 
		inner join banco bc on bc.idbanco=db.idbanco 
		where db.idpessoa = @idpessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END