USE [luzecorcasting]
GO

alter PROCEDURE [dbo].[p_geraRptBeneficioPessoa]
AS
BEGIN
	Begin Try
		
		Select 
			replicate('0', 5 - len(p.idpessoa)) + rtrim(p.idpessoa) + ' - ' + p.nmepessoa as nmepessoa,
			replicate('0', 3 - len(dr.idremuneracao)) + rtrim(dr.idremuneracao) + ' - ' + r.descricao as descricao,
			dr.valor 
		
		From Pessoa p
		Inner Join Colaborador c on c.idpessoa = p.idpessoa
		Left Join DadoRemuneracao dr on dr.idpessoa = p.idpessoa
		Left Join Remuneracao r on r.idremuneracao = dr.idremuneracao
		Where p.idtipopessoa = 1 
			And p.status = 1
				And p.idpessoa not in (10254)

		Union All

		Select 
			replicate('0', 5 - len(p.idpessoa)) + rtrim(p.idpessoa) + ' - ' + p.nmepessoa as nmepessoa,
			replicate('0', 5 - len(dp.idprograma)) + rtrim(dp.idprograma) + ' - ' + pr.descricao as descricao,
			0 as valor
		
		From Pessoa p
		Inner Join Colaborador c on c.idpessoa = p.idpessoa
		Left Join DadoPrograma dp on dp.idpessoa = p.idpessoa
		Left Join Programa pr on pr.idprograma = dp.idprograma
		Where p.idtipopessoa = 1 
			And p.status = 1
				And p.idpessoa not in (10254)

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END