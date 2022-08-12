alter PROCEDURE [dbo].[p_geraRptPendenteTotal]
	@idfirma int

AS
BEGIN
	Begin Try

		select 
			REPLICATE('0', 7 - LEN(nf.numnota)) + RTrim(nf.numnota) as numnota,
			nf.codverificacao, 
			CONVERT(VARCHAR(10),nf.dtemissao,105) as dtemissao,
			convert(decimal(18,2),sum(pf.vlrbruto)) as bruto,
			CONVERT(decimal(18,2),sum(pf.vlrinss)) as desconto,
			CONVERT (decimal(18,2),sum(pf.vlrliquido)) as liquido,
			f.descricao as firma,
			f.cnpj,
			CONVERT(VARCHAR(10),min(ped.dtpedido) ,105) + ' até ' + CONVERT(VARCHAR(10),max(ped.dtpedido) ,105) as periododtpedido

		from
		    PedidoFigurante pf (nolock) 
			inner join Pedido ped (nolock) on ped.idpedido = pf.idpedido 
			inner join programa prog (nolock) on prog.idprograma = ped.idprograma
			inner join cartafatura cf (nolock) on cf.idcartafatura = ped.idcartafatura
			inner join notafiscal nf (nolock) on nf.idnota = cf.idnota
			inner join Firma f on f.idfirma = ped.idfirma

		where pf.status = 0
				and nf.idfirma = @idfirma
		group by nf.numnota, nf.dtemissao, nf.codverificacao, f.descricao, f.cnpj

		order by 
			nf.numnota

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END

