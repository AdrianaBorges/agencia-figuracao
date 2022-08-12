USE [luzecorcasting]
GO

alter PROCEDURE p_RecuperaFigurantePedido
	@id int = 0
	
AS
		
BEGIN
	
	Begin Try
		
		Select
			fp.id,
			p.nmepessoa,
			case fp.idtipo
			when 1 then '01- FIGURAÇÃO COMUM'
			when 2 then '02- FIGURAÇÃO ESPECIAL'
			when 3 then '03- VEÍCULO CENA'
			when 4 then '04- MENOR TIPO 1 (0 A 15) ANOS'
			
		end as tipo,
		fp.vlrbruto,
		fp.vlrinss,
		fp.vlrliquido,
		fp.idpessoa,
		fp.idtipo

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		
		Where fp.id = @id
		Order by fp.id

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

