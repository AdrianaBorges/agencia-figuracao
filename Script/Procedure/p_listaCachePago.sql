USE [luzecorcasting]
GO

alter PROCEDURE p_listaCachePgto
	@idpessoa int,
	@recibo decimal
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			replicate('0',6 - Len(fp.id)) + Rtrim(fp.id) as id,
			pe.numpedido,
			rtrim(CONVERT(char, pe.dtpedido, 105)) as dtpedido,
			replicate('0', 5 - len(pr.idprograma)) + rtrim(pr.idprograma) + ' - ' + pr.descricao as descricao,
			case fp.idtipo
			when 1 then '01- FIGURAÇÃO COMUM'
			when 2 then '02- FIGURAÇÃO ESPECIAL'
			when 3 then '03- VEÍCULO CENA'
			when 4 then '04- MENOR TIPO 1 (0 A 15) ANOS' end as tipo,
			fp.vlrbruto,
			fp.vlrinss,
			fp.vlrliquido

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		Inner Join Pedido pe on pe.idpedido = fp.idpedido
		Inner Join Programa pr on pr.idprograma = pe.idprograma

		Where fp.idpessoa = @idpessoa
			and fp.nrrb = @recibo
				and fp.status = 1
		Order by fp.id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END