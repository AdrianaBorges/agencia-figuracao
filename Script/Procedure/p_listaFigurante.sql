ALTER PROCEDURE p_listaFigurante
	@dado varchar(100) = '',
	@status int = 0,
	@idpessoa int = 0

AS
	declare 
		@dtgravacao nvarchar(20)
BEGIN
	
	Begin Try
		
		Create table #tab(idpessoa int, dtcadastro nvarchar(20), nmepessoa nvarchar(100), ultgravacao nvarchar(20), telefone nvarchar(100), email nvarchar(100))
	
		--insert into #tab

		--Select 
		--	dbo.FormataCodigo(p.idpessoa,'M') as idpessoa,
		--	dbo.FormataData(p.dtcadastro) as dtcadastro,
		--	p.nmepessoa,
		--	'',
		--	dbo.FormataTelefone(p.celular) + '  ' + dbo.FormataTelefone(p.fixo) + '  ' + dbo.FormataTelefone(p.contato) as telefone,
		--	p.email

		--From Pessoa p
		--Inner Join Figurante f on f.idpessoa = p.idpessoa 
		--
		--Where p.nmepessoa like '%' + @dado + '%'
		--	and p.status = @status



		if @idpessoa = 0
			begin
			insert into #tab
				Select 
					dbo.FormataCodigo(p.idpessoa,'M') as idpessoa,
					dbo.FormataData(p.dtcadastro) as dtcadastro,
					p.nmepessoa,
				    '',
					dbo.FormataTelefone(p.celular) + '  ' + dbo.FormataTelefone(p.fixo) + '  ' + dbo.FormataTelefone(p.contato) as telefone,
					p.email

				From Pessoa p
				Inner Join Figurante f on f.idpessoa = p.idpessoa 

				Where p.nmepessoa like '%' + @dado + '%'
					and p.status = @status
			end 
		else
			begin
			insert into #tab
			Select 
				dbo.FormataCodigo(p.idpessoa,'M') as idpessoa,
				dbo.FormataData(p.dtcadastro) as dtcadastro,
				p.nmepessoa,
				'',
				dbo.FormataTelefone(p.celular) + '  ' + dbo.FormataTelefone(p.fixo) + '  ' + dbo.FormataTelefone(p.contato) as telefone,
				p.email

				From Pessoa p
				Inner Join Figurante f on f.idpessoa = p.idpessoa 

				Where p.idpessoa = @idpessoa
					and p.status = @status
			end

		 

		declare 
			@widpessoa int

			declare cursor_tmp cursor for
			
				select idpessoa
				from #tab

			open cursor_tmp
			fetch next from cursor_tmp into @widpessoa

			while @@fetch_status = 0
			begin

				if Exists
					(SELECT 1 
						From PedidoFigurante fp 
						Left Join Pedido p on p.idpedido = fp.idpedido 
						Where fp.idpessoa = @widpessoa) 
				Begin
					Select @dtgravacao = Max(Convert(char, p.dtpedido, 105)) 
					From PedidoFigurante fp 
					Left Join Pedido p on p.idpedido = fp.idpedido 
					Where fp.idpessoa = @widpessoa

					update #tab set ultgravacao = @dtgravacao Where idpessoa = @widpessoa
				End

			fetch next from cursor_tmp into @widpessoa
			end	

			close cursor_tmp
			deallocate cursor_tmp
			
			Select replicate('0',6 - len(idpessoa)) + rtrim(idpessoa) as idpessoa, dtcadastro, nmepessoa, rtrim(ultgravacao) as dt, telefone, email From #tab Order by nmepessoa

			Drop table #tab

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END