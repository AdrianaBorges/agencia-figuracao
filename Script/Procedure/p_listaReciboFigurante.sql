ALTER PROCEDURE p_listaReciboFigurante
	@idnota int = 0,
	@idpessoa int = 0,
	@nome nvarchar(50)
	
AS
		
BEGIN
	Begin Try

	if @idnota > 0
		begin
			select distinct 
				replicate('0',6 - Len(pe.idpessoa)) + Rtrim(pe.idpessoa) as idpessoa,	
				CONVERT(VARCHAR(10),pf.dtpagamento,105) as dtpagamento,
				pf.nrrb, sum(pf.vlrliquido) as vlrliquido, 
				pe.nmepessoa, 
				pe.email,
				
				--case LEN(re.nrrb)
				--	when 0 then ''
				--	else 'Enviado em ' + CONVERT(VARCHAR(10), re.dtenvio, 105) + ' para ' +  re.email
				--end as status
				(select top 1 'Enviado em ' + CONVERT(VARCHAR(10), re.dtenvio, 105) + ' para ' +  re.email 
				 from reciboenviado re where re.idpessoa = pe.idpessoa and re.nrrb = pf.nrrb order by re.dtenvio desc) as status

			from PedidoFigurante pf
			inner join pessoa pe on pe.idpessoa = pf.idpessoa
			inner join pedido pd on pd.idpedido = pf.idpedido
			inner join CartaFatura cf on cf.idcartafatura = pd.idcartafatura
		
			left join reciboenviado re on re.idpessoa = pe.idpessoa and re.nrrb = pf.nrrb

			where pf.status = 1
				and cf.idnota = @idnota
					And (pe.nmepessoa like '%' + @nome + '%' or @nome = '')
						And (pe.idpessoa = @idpessoa or @idpessoa = 0)

			group by pe.idpessoa, pf.dtpagamento, pf.nrrb, pe.nmepessoa, pe.email, re.nrrb,re.email, re.dtenvio
			order by pe.nmepessoa
		end
	else
		begin
			select distinct 
					replicate('0',6 - Len(pe.idpessoa)) + Rtrim(pe.idpessoa) as idpessoa,	
					CONVERT(VARCHAR(10),pf.dtpagamento,105) as dtpagamento,
					pf.nrrb, sum(pf.vlrliquido) as vlrliquido, 
					pe.nmepessoa, 
					pe.email,

				   (select top 1 'Enviado em ' + CONVERT(VARCHAR(10), re.dtenvio, 105) + ' para ' +  re.email 
				    from reciboenviado re 
					where re.idpessoa = pe.idpessoa and re.nrrb = pf.nrrb 
					order by re.dtenvio desc) as status


				from PedidoFigurante pf
				inner join pessoa pe on pe.idpessoa = pf.idpessoa
				inner join pedido pd on pd.idpedido = pf.idpedido
				inner join CartaFatura cf on cf.idcartafatura = pd.idcartafatura
		
				left join reciboenviado re on re.idpessoa = pe.idpessoa and re.nrrb = pf.nrrb

				where pf.status = 1
						And (pe.nmepessoa like '%' + @nome + '%' or @nome = '')
							And (pe.idpessoa = @idpessoa or @idpessoa = 0)

				group by pe.idpessoa, pf.dtpagamento, pf.nrrb, pe.nmepessoa, pe.email, re.nrrb,re.email, re.dtenvio
				order by pe.nmepessoa
			end

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END