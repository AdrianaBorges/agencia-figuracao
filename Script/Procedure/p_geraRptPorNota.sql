Use [dbAgencia]
Go

alter PROCEDURE [dbo].[p_geraRptPorNota]
	@tipo int, --1 Pago -- 0 Pendente
	@idnota int

AS
BEGIN
	Begin Try
	
		select 
			convert(char,pf.dtpagamento,105) as dtpagamento,
			replicate('0', 5 - len(pf.idpessoa)) + rtrim(pf.idpessoa) + ' - ' + p.nmepessoa as nmepessoa,
			coalesce(case len(p.cpf)
						when 11 then
						substring(p.cpf,1,3) + '.' + substring(p.cpf,4,3) + '.' + substring(p.cpf,7,3) + '-' + substring(p.cpf,10,2)
					 end,'') as cpf,
 			coalesce(case len(p.pis)
						when 12 then
						substring(p.pis,1,3) + '.' + substring(p.pis,4,3) + '.' + substring(p.pis,7,3) + '-' + substring(p.pis,10,2)
					 end,'') as pis,
				 
			sum(pf.vlrbruto) as bruto,
			sum(pf.vlrinss) as inss,
			sum(pf.vlrliquido) as liquido,
			f.descricao,
			f.cnpj,
			nf.numnota

		from figuracaopedido pf (nolock)
			inner join pessoa p (nolock) on p.idpessoa = pf.idpessoa 
			inner join firma f (nolock) on f.idfirma = p.idfirma
			inner join pedido pe (nolock) on pe.idpedido = pf.idpedido
			inner join cartafatura (nolock) cf on cf.idcartafatura = pe.idcartafatura
			inner join notafiscal (nolock) nf on nf.idnota = cf.idnota

		where pf.status = 1 
			and nf.idnota = @idnota

		group by pf.dtpagamento,pf.idpessoa, p.nmepessoa, p.cpf, p.pis,f.descricao, f.cnpj, nf.numnota
		order by p.nmepessoa

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END