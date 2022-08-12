USE [luzecorcasting]
GO

ALTER PROCEDURE [dbo].[p_listaReciboProvisorio]
	@idpessoa int
AS
BEGIN

	Begin Try

		Select
			'',
			rtrim(convert(char,rec.data,105)) as data,
			rec.recibo,
			sum(pf.vlrliquido) as liquido,
			REPLICATE('0', 7 - LEN(p.idpessoa)) + RTrim(p.idpessoa) + ' - ' + p.nmepessoa as nmepessoa

		From tmpRecibo rec
		inner join pessoa p on p.idpessoa = rec.idpessoa
		inner join tmppgto pg on pg.idpessoa = rec.idpessoa and pg.recibo = rec.recibo
		inner join PedidoFigurante pf on pf.idpessoa = rec.idpessoa and pf.id = pg.idregistro
		Where (rec.idpessoa = @idpessoa or @idpessoa = 0)
		and pf.status = 0

		group by rec.data, rec.recibo, p.nmepessoa, p.idpessoa
		Order by p.nmepessoa
	
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END