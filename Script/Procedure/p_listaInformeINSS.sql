alter PROCEDURE p_listaInformeINSS
	@idpessoa int = 0,
	@nome nvarchar(50),
	@de datetime = null,
	@ate datetime = null
AS
		
BEGIN
	Begin Try
	
		select distinct 
			replicate('0',6 - Len(pe.idpessoa)) + Rtrim(pe.idpessoa) as idpessoa,
			--pe.nmepessoa, 
			--pe.cpf,
			--pe.pis,	
			CONVERT(VARCHAR(10),pf.dtpagamento,105) as dtpagamento,
			pf.nrrb, 
			--sum(pf.vlrbruto) as vlrbruto,
			--sum(pf.vlrinss) as vlrinss,
			--sum(pf.vlrliquido) as vlrliquido			


			sum(pf.vlrbruto) as vlrliquido, 
			CAST(sum(pf.vlrbruto) * 11/100 AS DECIMAL(18, 2)) as vlronze,
			CAST(sum(pf.vlrbruto) * 20/100 AS DECIMAL(18, 2)) as vlrvinte,
			CAST(sum(pf.vlrbruto) * 11/100 AS DECIMAL(18, 2)) + CAST(sum(pf.vlrbruto) * 20/100 AS DECIMAL(18, 2)) as vlrrecolher 



		from PedidoFigurante pf
		INNER JOIN TipoFiguracao TP ON TP.idtipo = PF.idtipo AND TP.descinss = 1
		inner join pessoa pe on pe.idpessoa = pf.idpessoa
	
		where pf.status = 1
				And (pe.nmepessoa like '%' + @nome + '%' or @nome = '')
					And (pe.idpessoa = @idpessoa or @idpessoa = 0)
						and pf.dtpagamento between @de and @ate

		group by pe.idpessoa, pf.dtpagamento, pf.nrrb 
		--, pe.nmepessoa, pe.cpf, pe.pis 
		--order by pf.dtpagamento
		
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END