Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaTipoFiguracao]
	@idpedido int = 0
AS
		
BEGIN

	select
		ip.idtipo,
		case ip.idtipo
			when 1 then 'FIGURA��O COMUM'
			when 2 then 'FIGURA��O ESPECIAL'
			when 3 then 'VE�CULO CENA'
			when 4 then 'MENOR TIPO 1 (0 A 15) ANOS'
			
		end as tipo
		
	from ItensPedido ip 
	where ip.idpedido = @idpedido 
	order by ip.idtipo
	
END