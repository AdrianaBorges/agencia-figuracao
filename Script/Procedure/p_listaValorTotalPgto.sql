USE [luzecorcasting]
GO

alter PROCEDURE p_listaValorTotalPgto
	@idpessoa int,
	@recibo decimal
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			'',
			'',
			'',
			'',
			'Totais.:',
			sum(fp.vlrbruto) as bruto,
			sum(fp.vlrinss) as inss,
			sum(fp.vlrliquido) as liquido

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		Inner Join Pedido pe on pe.idpedido = fp.idpedido
		Inner Join Programa pr on pr.idprograma = pe.idprograma

		Where fp.idpessoa = @idpessoa
			and fp.nrrb = @recibo
				and fp.status = 1

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END