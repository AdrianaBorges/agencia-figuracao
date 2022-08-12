USE [luzecorcasting]
GO
ALTER PROCEDURE p_listaCachePendPgto
	@idpessoa int = 0
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			replicate('0',5 - Len(fp.id)) + Rtrim(fp.id) as id,
			pe.numpedido,
			rtrim(CONVERT(char, pe.dtpedido, 105)) as dtpedido,
			replicate('0', 5 - len(pr.idprograma)) + rtrim(pr.idprograma) + ' - ' + pr.descricao as descricao,
			case fp.idtipo
			when 1 then '01- FIGURA��O COMUM'
			when 2 then '02- FIGURA��O ESPECIAL'
			when 3 then '03- VE�CULO CENA'
			when 4 then '04- MENOR TIPO 1 (0 A 15) ANOS' end as tipo,
			fp.vlrbruto,
			fp.vlrinss,
			fp.vlrliquido,
			tmp.recibo as status

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		Inner Join Pedido pe on pe.idpedido = fp.idpedido
		Inner Join Programa pr on pr.idprograma = pe.idprograma

		left join tmpPgto tmp on tmp.idpessoa = fp.idpessoa and tmp.idpedido = fp.idpedido

		Where fp.idpessoa = @idpessoa
			and fp.status = 0
		Order by fp.id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END