USE [luzecorcasting]
GO

alter PROCEDURE p_listaFiguracaoPedido
	@idpedido int = 0
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			replicate('0',5 - Len(fp.id)) + Rtrim(fp.id) as id,
			p.nmepessoa,
			case fp.idtipo
			when 1 then '01- FIGURAÇÃO COMUM'
			when 2 then '02- FIGURAÇÃO ESPECIAL'
			when 3 then '03- VEÍCULO CENA'
			when 4 then '04- MENOR TIPO 1 (0 A 15) ANOS'
			
		end as tipo,
		fp.vlrbruto,
		fp.vlrinss,
		fp.vlrliquido

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		
		Where fp.idpedido = @idpedido
		Order by fp.id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

