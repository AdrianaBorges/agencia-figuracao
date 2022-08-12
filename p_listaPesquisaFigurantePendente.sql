Use [luzecorcasting]
Go
ALTER PROCEDURE p_listaPesquisaFigurantePendente
	@idfirma int = 0,
	@nome nvarchar(50),
	@idpessoa nvarchar(15)
	
AS
		
BEGIN
	
	raiserror 30005 'ERRO AO CARREGAR OS REGISTROS.'
	--Begin Try
		
	--	begin
	--		if @idpessoa = ''
	--			Select distinct
	--				replicate('0',6 - Len(p.idpessoa)) + Rtrim(p.idpessoa) as id,
	--				p.nmepessoa,
	--				dbo.FormataDoc(p.cpf) as cpf,
	--				dbo.FormataDoc(p.pis) as pis,
	--				p.rg,
	--				Convert(char, (select max(dtpagamento) from pedidofigurante where idpessoa = fp.idpessoa and status = 1), 105) as ultimopgto

	--			From PedidoFigurante fp
	--			Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		
	--			Where (p.nmepessoa like '%' + @nome + '%' or @nome = '')
	--				and fp.status = 0
	--			Order by p.nmepessoa
	--		else
	--			Select distinct
	--				replicate('0',6 - Len(p.idpessoa)) + Rtrim(p.idpessoa) as id,
	--				p.nmepessoa,
	--				dbo.FormataDoc(p.cpf) as cpf,
	--				dbo.FormataDoc(p.pis) as pis,
	--				p.rg,
	--				Convert(char, (select max(dtpagamento) from pedidofigurante where idpessoa = fp.idpessoa and status = 1), 105) as ultimopgto

	--			From PedidoFigurante fp
	--			Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		
	--			Where p.idpessoa = @idpessoa
	--				and fp.status = 0
	--			Order by p.nmepessoa
	--	end


	--End Try

	--Begin Catch
	--	Select ERROR_MESSAGE() as ErrorMessage

	--End Catch
	
END