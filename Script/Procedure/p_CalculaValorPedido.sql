Use [dbAgencia]
Go

create PROCEDURE p_CalculaValorPedido
    @idpedido int

AS
BEGIN
	Begin Try
		create table #tab (vlrrealizado decimal(18,2), qtd int, valor decimal(18,2), )

		INSERT INTO #tab
		select 
			case idtipo
				when 1 then qtd * valor + qtd * valor * 93.9/100
				when 2 then qtd * valor + qtd * valor * 93.9/100
				when 3 then qtd * valor + qtd * valor * 70/100
				when 4 then qtd * valor + qtd * valor * 70/100
			end as vlrrealizado,
			qtd, 
			qtd * valor as totvalor

		from itenspedido
		where idpedido = @idpedido

		Select 
			sum(qtd) as qtd,
			Cast(sum(vlrrealizado) as decimal(18,2)) as realizado,
			sum(valor) as total
		From #tab

		DROP TABLE #tab 
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END
          