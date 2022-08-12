ALTER PROCEDURE [dbo].[p_geraRptConsolidado]
	@idfirma int = 0,
	@de datetime,
	@ate datetime,
	@idstatus int = 0

AS
BEGIN


declare @w_texto varchar(100) = ''

	if @idstatus = 0 
		begin
			set @w_texto = 'Relatorio Consolidado de Pendência ref. ao período de ' + cast(convert(varchar(10),@de,105) as varchar) + ' até ' + cast(convert(varchar(10),@ate,105) as varchar)
		end 
	else
		begin
			set @w_texto = 'Relatorio Consolidado de Pagamento ref. ao período de ' + cast(convert(varchar(10),@de,105) as varchar) + ' até ' + cast(convert(varchar(10),@ate,105) as varchar)
		end

	Begin Try

		select 
			@w_texto as cabecario,
			case 
				when datepart(month,ped.dtpedido) = 1 then 'Janeiro' 
				when datepart(month,ped.dtpedido) = 2 then 'Fevereiro'
				when datepart(month,ped.dtpedido) = 3 then 'Março'
				when datepart(month,ped.dtpedido) = 4 then 'Abril'
				when datepart(month,ped.dtpedido) = 5 then 'Maio'
				when datepart(month,ped.dtpedido) = 6 then 'Junho'
				when datepart(month,ped.dtpedido) = 7 then 'Julho'
				when datepart(month,ped.dtpedido) = 8 then 'Agosto'
				when datepart(month,ped.dtpedido) = 9 then 'Setembro'
				when datepart(month,ped.dtpedido) = 10 then 'Outubro'
				when datepart(month,ped.dtpedido) = 11 then 'Novembro'
				when datepart(month,ped.dtpedido) = 12 then 'Dezembro'
				end as mes,		
			
			sum(convert(decimal(18,2),pf.vlrbruto)) as bruto,
			sum(CONVERT(decimal(18,2),pf.vlrinss)) as desconto,
			sum(CONVERT (decimal(18,2),pf.vlrliquido)) as liquido,
			f.descricao as firma,
			f.cnpj
		
		from 
			Pessoa p (nolock)
			inner join PedidoFigurante pf (nolock) on pf.idpessoa = p.idpessoa 
			inner join Pedido ped (nolock) on ped.idpedido = pf.idpedido 
			
			inner join cartafatura cf (nolock) on cf.idcartafatura = ped.idcartafatura
			inner join notafiscal nf (nolock) on nf.idnota = cf.idnota
			inner join Firma f on f.idfirma = ped.idfirma
			

		where pf.status = @idstatus
			and p.idfirma = @idfirma
						and ped.dtpedido between @de and @ate
		group by datepart(month,ped.dtpedido), f.descricao, f.cnpj

		order by 
			datepart(month,ped.dtpedido)

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END