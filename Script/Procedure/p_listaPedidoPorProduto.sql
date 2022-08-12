Use [luzecorcasting]
Go

alter PROCEDURE p_listaPedidoPorProduto
    @idprograma int

AS
BEGIN
	Begin Try
		create table #tab (numpedido varchar(10), 
						data varchar(10), 
						qtdcomum int, vlrcomum decimal(18,2), 
						qtdespecial int, vlrespecial decimal(18,2),
						qtdveiculo int, vlrveiculo decimal(18,2),
						qtdmenor int, vlrmenor decimal(18,2))
		INSERT INTO #tab

		select 
			distinct p.numpedido,
			convert(char,p.dtpedido,105) as data,
			COALESCE(comum.qtd,0) as qtdComum,
			COALESCE(comum.qtd * comum.valor,0) as vlrcomum,
			COALESCE(especial.qtd,0) as qtdEspecial,
			COALESCE(especial.qtd * especial.valor,0) as vlrespecial,
			COALESCE(veiculo.qtd,0) as qtdVeiculo,
			COALESCE(veiculo.qtd * veiculo.valor,0) as vlrveiculo,
			COALESCE(menor.qtd,0) as qtdMenor,
			COALESCE(menor.qtd * menor.valor,0) as vlrmenor
	
		from pedido p
		left join PedQtdFigurante pqf on pqf.idpedido = p.idpedido 
		left join PedQtdFigurante comum on comum.idpedido = p.idpedido and comum.idtipo = 1
		left join PedQtdFigurante especial on especial.idpedido = p.idpedido and especial.idtipo = 2
		left join PedQtdFigurante veiculo on veiculo.idpedido = p.idpedido and veiculo.idtipo = 3
		left join PedQtdFigurante menor on menor.idpedido = p.idpedido and menor.idtipo = 4

		where p.idprograma = @idprograma

		select 
			numpedido, data, qtdcomum, vlrcomum, qtdespecial, vlrespecial, qtdveiculo, vlrveiculo, qtdmenor, vlrmenor,
			qtdcomum + qtdespecial + qtdveiculo + qtdmenor as total,
			vlrcomum + vlrespecial + vlrveiculo + vlrmenor as vlrtotal
		from #tab
		order by data desc

		DROP TABLE #tab 
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END