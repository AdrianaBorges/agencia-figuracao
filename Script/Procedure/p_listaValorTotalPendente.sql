USE [luzecorcasting]
GO

ALTER PROCEDURE p_listaValorTotalPendente
	@idpessoa int = 0
	
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
			--sum(fp.vlrliquido) as liquido
			--format(sum(fp.vlrliquido), 'C', 'pt-br') as liquido
			--select format(1.489, 'C', 'pt-br') = R$ 1,49

			round(sum(fp.vlrliquido),2)  as liquido

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		Inner Join Pedido pe on pe.idpedido = fp.idpedido
		Inner Join Programa pr on pr.idprograma = pe.idprograma

		Where fp.idpessoa = @idpessoa
			and fp.status = 0

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END