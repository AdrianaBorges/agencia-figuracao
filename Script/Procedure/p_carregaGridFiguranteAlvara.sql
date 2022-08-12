ALTER PROCEDURE [dbo].[p_carregaGridFiguranteAlvara]
	@idalvara int = 0,
	@iddisponivel int = 0,
	@dado varchar(100) = ''
AS
BEGIN
	
	Begin Try
			
		if @idalvara <> 0 and @iddisponivel = 0
		begin		
		
			Select
				REPLICATE('0', 6 - LEN(p.idpessoa)) + RTrim(p.idpessoa) as idpessoa,
				p.nmepessoa,
				CONVERT(VARCHAR(10),p.dtnascimento,105) as dtnascimento,
				DATEDIFF(yy,p.dtnascimento, GETDATE()) as idade,
				dbo.FormataDoc(p.cpf),
				f.certnascimento,
				REPLICATE('0', 5 - LEN(f.livro)) + RTrim(f.livro) as livro,
				f.responsavel,
				f.cpf_resp	
			From DadoAlvara da
			inner join pessoa p on p.idpessoa = da.idpessoa
			inner join figurante f on f.idpessoa = p.idpessoa
		
			where da.idalvara = @idalvara
			order by p.nmepessoa
		end

		if @iddisponivel = 1
		begin		
			Select
				REPLICATE('0', 5 - LEN(p.idpessoa)) + RTrim(p.idpessoa) as idpessoa,
				p.nmepessoa,
				CONVERT(VARCHAR(10),p.dtnascimento,105) as dtnascimento,
				DATEDIFF(yy,p.dtnascimento, GETDATE()) as idade,
				dbo.FormataDoc(p.cpf),
				f.certnascimento,
				REPLICATE('0', 5 - LEN(f.livro)) + RTrim(f.livro) as livro,
				f.responsavel,
				f.cpf_resp	

			From pessoa p 
			inner join figurante f on f.idpessoa = p.idpessoa

			where p.idpessoa not in (select idpessoa from DadoAlvara where idalvara = @idalvara)
				and p.idtipopessoa = 2
					and datediff(yy, p.dtnascimento, GETDATE()) <= 14
						and (p.nmepessoa like '%' + @dado + '%' or @dado = '') 

			order by p.nmepessoa

		end

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END