ALTER PROCEDURE [dbo].[p_geraRptAlvara]
	@idalvara int = 0
AS
BEGIN
	declare
		@firma varchar (100) = '',
		@cnpj varchar (100) = ''

	Begin Try
						
		select @firma = descricao, @cnpj = cnpj from firma where idfirma = 1
		
		Select
			@firma + ' - ' + @cnpj as firma,
		    CONVERT(VARCHAR(10),al.data,105) as dtemissao,

			'Nº Processo: ' + convert(varchar(50),al.numprocesso) +
			'  Data-Emissão: ' + CONVERT(VARCHAR(10),al.data,105) +
			'  Produto-Programa: ' + prog.descricao as descfirma,

			REPLICATE('0', 6 - LEN(p.idpessoa)) + RTrim(p.idpessoa) as idpessoa,
			p.nmepessoa,
			CONVERT(VARCHAR(10),p.dtnascimento,105) as dtnascimento,
			DATEDIFF(yy,p.dtnascimento, GETDATE()) as idade,
			dbo.FormataDoc(p.cpf) as cpf,

			case 
				when f.certnascimento is not null then replicate('0',10 - Len(f.certnascimento)) + Rtrim(f.certnascimento) + '-' + replicate('0',4 - Len(f.livro)) + Rtrim(f.livro)
				else ''
			end as certnascimento,

			f.responsavel,
			f.cpf_resp	

		From DadoAlvara da
		inner join alvara al on al.idalvara = da.idalvara
		inner join programa prog on prog.idprograma = al.idprograma
		inner join pessoa p on p.idpessoa = da.idpessoa
		inner join figurante f on f.idpessoa = p.idpessoa
		
		where da.idalvara = @idalvara
		order by p.nmepessoa
				

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END