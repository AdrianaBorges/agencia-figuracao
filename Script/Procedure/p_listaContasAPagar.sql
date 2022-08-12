USE [luzecorcasting]

GO
alter PROCEDURE [dbo].[p_listaContasAPagar]
	@idfirma int,
	@de datetime,
	@ate datetime,
	@idcusto int

AS
BEGIN

	Begin Try

		create table #tab (idtipo int,
						   idcontaapagar char(8),
						   data datetime,
 						   descricao varchar(100),
						   nmepessoa varchar(100),
						   valor decimal(18,2),
						   observacao varchar(100))

		INSERT INTO #tab

		Select 
			1 as tipo,
			REPLICATE('0', 5 - LEN(cap.idcontaapagar)) + RTrim(cap.idcontaapagar) as idcontaapagar,
			cap.vencimento,
			cdc.descricao as desccentrodecusto,
			p.nmepessoa,
			cap.valor,
			cap.observacao

		From ContasAPagar cap
		Inner Join CentroDeCusto cdc on cdc.idcusto = cap.idcusto
		Inner Join Pessoa p on p.idpessoa = cap.idpessoa

		Where cap.status = 0
			And (cap.idcusto = @idcusto or @idcusto = 0)

		UNION all

		select
			2 as tipo,
			REPLICATE('0', 5 - LEN(fp.id)) + RTrim(fp.id) as idcontaapagar,
			p.dtpedido, fp.idcusto,
			cdc.descricao as desccentrodecusto,
			pe.nmepessoa,
			fp.vlrliquido as valor,
			'Pedido Nº: ' + p.numpedido + ' Produto: ' + prog.descricao as  observacao
		from PedidoFigurante fp
		inner join pedido p on p.idpedido = fp.idpedido
		inner join CentroDeCusto cdc on cdc.idcusto = fp.idcusto
		inner join Pessoa pe on pe.idpessoa = fp.idpessoa
		inner join Programa prog on prog.idprograma = p.idprograma
		Where fp.status = 0
			And (cdc.idcusto = @idcusto or @idcusto = 0)

		Select idtipo, idcontaapagar,rtrim(CONVERT(char, data, 105)) as data, descricao, nmepessoa, valor, observacao
		From #tab order by data

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
		
END