USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_listaContasAReceber]
	@idfirma int,
	@status int,
	@de datetime,
	@ate datetime,
	@numnota int

AS
	declare 
		@bruto decimal(18,2),
		@cofins decimal(18,2),
		@csll decimal(18,2),
		@irpj decimal(18,2),
		@pis decimal(18,2),
		@iss decimal(18,2)

BEGIN

	Begin Try

		create table #tab (idnota int,
						   numnota varchar(10),
						   dtemissao datetime,
						   dtpagamento datetime,
						   codverificacao varchar(20),
						   descricao varchar(100),
						   contratante varchar(100),
						   endereco varchar(199),
						   cnpj varchar(20),
						   inscmunicipal varchar(20),
						   inscestadual varchar(20),
						   telefone varchar(10),
						   email varchar(100),
						   vlrbruto decimal(18,2),
						   vlrcofins decimal(18,2),
						   vlrcsll decimal(18,2),
						   vlrirpj decimal(18,2),
						   vlrpis decimal(18,2),
						   vlriss decimal(18,2))

		if Exists(Select idnota From notafiscal where idfirma = @idfirma)
		Begin 
		
			INSERT INTO #tab 
			
			SELECT
				nf.idnota as idnota,
				REPLICATE('0', 8 - LEN(nf.numnota)) + RTRIM(nf.numnota) AS numnota, 
				nf.dtemissao,  
				nf.dtpagamento,
				nf.codverificacao, nf.descricao,
				REPLICATE('0', 5 - LEN(c.idcontratante)) + RTRIM(c.idcontratante) + ' - ' + c.nome AS contratante,
				c.endereco, c.cnpj, c.inscmunicipal, c.inscestadual, c.telefone, c.email, 
				0 as vlrbruto, 0 as vlrcofins, 0 as vlrcsll, 0 as vlrirpj, 0 as vlrpis, 0 as vlriss
                      
			FROM
				NotaFiscal AS nf 
				INNER JOIN Contratante AS c ON c.idcontratante = nf.idcontratante 
			Where nf.status = @status
			ORDER BY nf.dtemissao DESC
			
		End

		declare @widnota int, @wbruto decimal(18,2), @wcofins decimal(18,2), @wcsll decimal(18,2), @wirpj decimal(18,2), @wpis decimal(18,2), @wiss decimal(18,2)
		declare cursor_tmp cursor for
			select idnota 
			from #tab

		open cursor_tmp
		fetch next from cursor_tmp into @widnota 

		while @@fetch_status = 0
		begin
			exec p_ValoresNotaFiscal @widnota, @wbruto output, @wcofins output, @wcsll output, @wirpj output, @wpis output, @wiss output
			
			update #tab 
			set vlrbruto = @wbruto, vlrcofins = @wcofins, vlrcsll = @wcsll, vlrirpj = @wirpj, vlrpis = @wpis, vlriss = @wiss
			from #tab Where idnota = @widnota

		fetch next from cursor_tmp into @widnota 
		end	

		close cursor_tmp
		deallocate cursor_tmp

		Select 
			replicate('0',5 - Len(idnota)) + Rtrim(idnota) as idnota,
			numnota, 
			rtrim(CONVERT(char, dtemissao, 105)) AS dtemissao, 
			rtrim(CONVERT(char, dtpagamento, 105)) AS dtpagamento,
			codverificacao, 
			descricao,
			coalesce(vlrbruto,0) as vlrbruto, coalesce(vlrcofins,0) as vlrcofins, coalesce(vlrcsll,0) as vlrcsll,
			coalesce(vlrirpj,0) as vlrirpj, coalesce(vlrpis,0) as vlrpis, coalesce(vlriss,0) vlriss,
			coalesce(vlrbruto - vlrcofins - vlrcsll - vlrirpj - vlrpis - vlriss,0) as vlrliquido
		
		From #tab  
		Where (numnota = @numnota or @numnota = 0)

		DROP TABLE #tab 

	end try
	
	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END
