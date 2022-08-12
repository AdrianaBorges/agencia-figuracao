USE [luzecorcasting]
GO

ALTER PROCEDURE p_listaCachePendenteSemRecibo
	@idpessoa int = 0
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			replicate('0',6 - Len(fp.id)) + Rtrim(fp.id) as id,
			pe.numpedido,
			rtrim(CONVERT(char, pe.dtpedido, 105)) as dtpedido,
			pr.descricao,
			tp.descricao as tipo,
			fp.vlrbruto,
			fp.vlrinss,
			fp.vlrliquido

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		Inner Join Pedido pe on pe.idpedido = fp.idpedido
		Inner Join Programa pr on pr.idprograma = pe.idprograma
		inner join TipoFiguracao tp on tp.idtipo = fp.idtipo

		Where fp.idpessoa = @idpessoa
			and fp.status = 0
				and fp.id not in (Select tmp.idregistro From tmpPgto tmp Where tmp.idpessoa = @idpessoa)
		Order by fp.id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END