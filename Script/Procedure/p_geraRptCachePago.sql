USE [luzecorcasting]
Go

ALTER PROCEDURE [dbo].[p_geraRptCachePago]
	@idfirma int,
	@de datetime,
	@ate datetime

AS
BEGIN

	Begin Try
	
		select 
			dbo.FormataData(pf.dtpagamento) as dtpagamento,
			p.nmepessoa,
			dbo.FormataDoc(p.cpf) as cpf,
 			dbo.FormataDoc(p.pis) as pis,
			sum(pf.vlrbruto) as bruto,
			sum(pf.vlrinss) as inss,
			sum(pf.vlrliquido) as liquido,
			f.descricao,
			f.cnpj,
			dbo.FormataData(@de) as de,
			dbo.FormataData(@ate) as ate

		from PedidoFigurante pf (nolock)
			inner join pessoa p (nolock) on p.idpessoa = pf.idpessoa and p.idfirma = @idfirma
			inner join firma f on f.idfirma = p.idfirma
		where pf.status = 1 
			and pf.dtpagamento between @de - 1 and @ate
		group by pf.dtpagamento,pf.idpessoa, p.nmepessoa, p.cpf, p.pis,f.descricao, f.cnpj
		order by p.nmepessoa

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END