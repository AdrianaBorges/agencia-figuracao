
USE [dbAgencia]
GO

create PROCEDURE [dbo].[p_RecuperaNotaFiscal]
	@idnota int

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
						   vlriss decimal(18,2),
						   observacao varchar(200), 
						   status int)

		INSERT INTO #tab 
			
			SELECT
				nf.idnota as idnota,
				REPLICATE('0', 8 - LEN(nf.numnota)) + RTRIM(nf.numnota) AS numnota, 
				nf.dtemissao, nf.dtpagamento,
				nf.codverificacao, nf.descricao,
				REPLICATE('0', 5 - LEN(c.idcontratante)) + RTRIM(c.idcontratante) + ' - ' + c.nome AS contratante,
				c.endereco, c.cnpj, c.inscmunicipal, c.inscestadual, c.telefone, c.email, 
				0 as vlrbruto, 0 as vlrcofins, 0 as vlrcsll, 0 as vlrirpj, 0 as vlrpis, 0 as vlriss, observacao, status
                      
			FROM
				NotaFiscal AS nf 
				INNER JOIN Contratante AS c ON c.idcontratante = nf.idcontratante 
				Where nf.idnota = @idnota

			ORDER BY nf.dtemissao DESC

		exec p_ValoresNotaFiscal @idnota, @bruto output, @cofins output, @csll output, @irpj output, @pis output, @iss output
			
		update #tab 
		set vlrbruto = @bruto, vlrcofins = @cofins, vlrcsll = @csll, vlrirpj = @irpj, vlrpis = @pis, vlriss = @iss
		from #tab Where idnota = @idnota

		Select 
			replicate('0',5 - Len(idnota)) + Rtrim(idnota) as idnota,
			numnota, 
			rtrim(CONVERT(char, dtemissao, 105)) AS dtemissao, dtpagamento,
			codverificacao, descricao,
			coalesce(vlrbruto,0) as vlrbruto,
			coalesce(vlrcofins,0) as vlrcofins, 
			coalesce(vlrcsll,0) as vlrcsll, 
			coalesce(vlrirpj,0) as vlrirpj,
			coalesce(vlrpis,0) as vlrpis,
			coalesce(vlriss,0) as vlriss,
			coalesce(vlrbruto - vlrcofins - vlrcsll - vlrirpj - vlrpis - vlriss,0) as vlrliquido,
			observacao, status
			
		From #tab  
		Where idnota = @idnota

		DROP TABLE #tab 

	end try
	
	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END
