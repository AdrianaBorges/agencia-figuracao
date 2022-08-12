ALTER PROCEDURE [dbo].[p_listaItemPedido]
	@idpedido int = 0
AS
		
BEGIN

	begin try

		select 
			replicate('0',5 - Len(ip.id)) + Rtrim(ip.id) as iditem,
			tp.descricao as tipo,
		
			replicate('0',3 - len(ip.qtd)) + rtrim(ip.qtd) as qtd,
			cast(ip.valor as decimal(18,2)) as vlrcache
			
		from pedqtdfigurante ip
		inner join TipoFiguracao tp on tp.idtipo = ip.idtipo

		where ip.idpedido = @idpedido and ip.idtipo <> 0
		order by ip.qtd
	
	end try

	
	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END