ALTER PROCEDURE [dbo].[p_RecuperaItemPedidoPorId]
	@iditem int = 0
AS
		
BEGIN
	
	Begin Try

		select 
			replicate('0',5 - Len(ip.id)) + Rtrim(ip.id) as iditem,
			tp.descricao as tipo,
		
			replicate('0',3 - len(ip.qtd)) + rtrim(ip.qtd) as qtd,
			cast(ip.valor as decimal(18,2)) as vlrcache,
			ip.idpedido
			
		from pedqtdfigurante ip
		inner join TipoFiguracao tp on tp.idtipo = ip.idtipo

		where ip.id = @iditem 
		order by ip.qtd
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END

