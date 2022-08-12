Use [luzecorcasting]
Go

alter PROCEDURE [dbo].[p_ReCalculoDeInss]
	
AS
	declare
		@idade int,
		@percentual decimal(18,2),
		@vlrinss decimal (18,2),
		@nmepessoa nvarchar(100)
		
BEGIN
	Begin Try

	if Exists(Select fp.id
				From PedidoFigurante fp
				Inner Join Pedido pe on pe.idpedido = fp.idpedido
				Inner Join Figurante f on f.idpessoa = fp.idpessoa and f.nacionalidade = 1
				Inner Join Pessoa ps on ps.idpessoa = f.idpessoa and ps.idtipopessoa = 2)
	Begin 

		begin transaction

		declare
			@wid int,
			@widpessoa int,
			@wnascimento datetime,
			@wgravacao datetime,
			@cache decimal (18,2)
		
		declare cursor_tmp cursor for
			
			Select
				fp.id, fp.idpessoa, ps.dtnascimento, pe.dtpedido, fp.vlrbruto
			From PedidoFigurante fp
			Inner Join Pedido pe on pe.idpedido = fp.idpedido
			Inner Join Figurante f on f.idpessoa = fp.idpessoa and f.nacionalidade = 1
			Inner Join Pessoa ps on ps.idpessoa = f.idpessoa and ps.idtipopessoa = 2

			Where fp.status = 0
				and fp.idtipo not in (3,4)
					and fp.vlrinss = 0
			Group by fp.id, fp.idpessoa, ps.dtnascimento, pe.dtpedido, fp.vlrbruto

		open cursor_tmp
		fetch next from cursor_tmp into @wid, @widpessoa, @wnascimento, @wgravacao, @cache

		while @@fetch_status = 0
		begin
				If (month(@wgravacao) < month(@wnascimento)) -- 1ª Situação: Pessoa ainda não fez aniversário
				Begin
					set @idade = datediff(yy, @wnascimento, @wgravacao) - 1
				End

				set @idade = datediff(yy, @wnascimento, @wgravacao) - 1
				
				If (month(@wgravacao) = month(@wnascimento)) -- 2ª Situação: O mês corrente, é o mês de aniversário
				Begin
					
					If (day(@wgravacao) >= day(@wnascimento)) -- O dia corrente é maior ou igual ao dia do aniversário
					Begin
						set @idade = datediff(yy, @wnascimento, @wgravacao)
					End

					Else
					Begin
						set @idade = datediff(yy, @wnascimento, @wgravacao) - 1
					End
				End
				
				If (@idade >= 15) --Verifica se a pessoa será descontada
				begin
					Set @vlrinss = @cache * 11 / 100
					
					update FiguracaoPedido
						set vlrinss = @vlrinss, vlrliquido = @cache - @vlrinss
					Where id = @wid 

					select @nmepessoa = nmepessoa from pessoa where idpessoa = @widpessoa

					print 'Figurante ' + @nmepessoa + ', teve o desconto de INSS corrigido.'

					commit
				end

		fetch next from cursor_tmp into @wid, @widpessoa, @wnascimento, @wgravacao, @cache
		end

		close cursor_tmp
		deallocate cursor_tmp
	end

	else
	begin
		return 0
	end

	End Try
	


	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END