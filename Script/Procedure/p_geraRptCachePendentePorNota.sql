
USE [luzecorcasting]
Go
ALTER PROCEDURE [dbo].[p_geraRptCachePendentePorNota]
	@idnota int

AS
BEGIN
	Begin Try

		select 
			p.idpessoa as idpessoa,
			p.nmepessoa as nmepessoa,
			dbo.FormataDoc(p.cpf) as cpf,
		
			case 
				when db.idbanco IS NULL then 'PAGAMENTO NA AGÊNCIA'
				else coalesce(replicate('0', 3 - len(b.numero)) + rtrim(b.numero) + ' - ' + b.nmebanco,'') 
			end as nmebanco,
		
			case
				when db.idbanco is null then ''
				else coalesce(db.tipo,'') 
			end as tipo,
		
			case
				when db.idbanco is null then ''
				else coalesce(db.agencia,'')
			end as agencia,

			case
				when db.idbanco is null then ''
				else coalesce(db.numconta,'') 
			end as numconta,

			REPLICATE('0', 8 - LEN(ped.numpedido)) + RTrim(ped.numpedido) as numpedido,
			CONVERT(VARCHAR(10),ped.dtpedido,105) as dtpedido,
			REPLICATE('0', 5 - LEN(prog.idprograma)) + RTrim(prog.idprograma) + ' - ' + prog.descricao as descricao,
			convert(decimal(18,2),pf.vlrbruto) as bruto,
			CONVERT(decimal(18,2),pf.vlrinss) as desconto,
			CONVERT (decimal(18,2),pf.vlrliquido) as liquido,
			f.descricao as firma,
			f.cnpj,
			REPLICATE('0', 7 - LEN(nf.numnota)) + RTrim(nf.numnota) as numnota
		
		from 
			Pessoa p (nolock)
			inner join PedidoFigurante pf (nolock) on pf.idpessoa = p.idpessoa 
			inner join Pedido ped (nolock) on ped.idpedido = pf.idpedido 
			inner join programa prog (nolock) on prog.idprograma = ped.idprograma
			inner join cartafatura cf (nolock) on cf.idcartafatura = ped.idcartafatura
			inner join notafiscal nf (nolock) on nf.idnota = cf.idnota
			inner join Firma f on f.idfirma = ped.idfirma
			left join dadobancario db (nolock) on db.idpessoa = p.idpessoa
			left join banco b (nolock) on b.idbanco = db.idbanco

		where pf.status = 0
				and nf.idnota = @idnota
	
		order by 
			p.nmepessoa

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END