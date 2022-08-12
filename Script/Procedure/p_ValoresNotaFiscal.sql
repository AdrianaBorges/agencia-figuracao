USE [luzecorcasting]
Go

alter PROCEDURE p_ValoresNotaFiscal
	@widnota int,
	@wbruto decimal(18,2) output,
	@wcofins decimal(18,2) output,
	@wcsll decimal(18,2) output,
	@wirpj decimal(18,2) output,
	@wpis decimal(18,2) output,
	@wiss decimal(18,2) output
	
AS
	declare @vlrbruto decimal(18,2)

BEGIN

	Begin Try
		create table #tabela (bruto decimal(18,2),
						   cofins decimal(18,2),
						   csll decimal(18,2),
						   irpj decimal(18,2),
						   pis decimal(18,2),
						   iss decimal(18,2))
		
						   
		if Exists(Select idnota From CartaFatura where idnota = @widnota)
		Begin 
			create table #tmp (vlr decimal(18,2))

			declare @widtipo int, @wvlr decimal(18,2)
			declare cursor_t cursor for
					
				Select 
					fp.idtipo, (sum(fp.vlrbruto)) as vlr
				From PedidoFigurante fp
				Inner join Pedido p on p.idpedido = fp.idpedido
				Inner join CartaFatura cf on cf.idcartafatura = p.idcartafatura
				Inner join NotaFiscal nf on nf.idnota = cf.idnota
				Where nf.idnota = @widnota
				Group by fp.idtipo

			open cursor_t
			fetch next from cursor_t into @widtipo,  @wvlr

			while @@fetch_status = 0
			begin

				if (@widtipo = 1 or @widtipo = 2)
				begin
					insert into #tmp (vlr) values (@wvlr + @wvlr * 93.9 / 100)
				end

				if (@widtipo = 3 or @widtipo = 4)
				begin
					insert into #tmp (vlr) values ( @wvlr + @wvlr * 70 / 100)
				end

			fetch next from cursor_t into  @widtipo,  @wvlr 
			end	

			close cursor_t
			deallocate cursor_t

			select @vlrbruto = sum(vlr) from #tmp

			insert into #tabela (bruto, cofins, csll, irpj, pis, iss) values (@vlrbruto, 0,0,0,0,0)

			update #tabela 
				set  
					cofins = @vlrbruto * 3 / 100,
					csll = @vlrbruto * 1 / 100,
					irpj = @vlrbruto * 1 / 100,
					pis = @vlrbruto * 0.65 / 100,
					iss = @vlrbruto * 5 / 100
		    
			from #tabela 
			
		End

		Select @wbruto = bruto, @wcofins = cofins, @wcsll = csll, @wirpj = irpj, @wpis = pis, @wiss = iss from #tabela

		DROP TABLE #tabela 

	End Try

	Begin Catch
		DROP TABLE #tabela 
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END