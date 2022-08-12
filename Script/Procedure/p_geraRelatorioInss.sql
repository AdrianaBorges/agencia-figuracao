USE [luzecorcasting]
GO
/****** Object:  StoredProcedure [dbo].[p_geraRelatorioInss]    Script Date: 05/29/2014 12:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[p_geraRelatorioInss]
	@idfirma int = 0,
	@de datetime,
	@ate datetime

AS
		
BEGIN
	Begin Try
		
		Select 
			p.idpessoa, p.nmepessoa, 
			min(pf.dtpagamento) as de, 
			max(pf.dtpagamento) as ate, 
			sum(pf.vlrbruto) as vlrbruto, 
			sum(pf.vlrinss) as vlrinss,
			CAST(sum(pf.vlrbruto) * 20/100 as DECIMAL(18,2)) as vlrvinte,
			sum(pf.vlrbruto) - sum(pf.vlrinss) as vlrpago,
			p.pis, p.cpf,
			f.descricao, f.cnpj,
			dbo.FormataData(@de) as periodode,
			dbo.FormataData(@ate) as periodoate

		From Pessoa p
		Inner join pedidofigurante pf on pf.idpessoa = p.idpessoa and pf.status = 1
		Inner join Pedido pd on pd.idpedido = pf.idpedido
		inner join Firma f on f.idfirma = p.idfirma
		Where p.idtipopessoa = 2
			and p.status = 1
				--and p.pis is not null 
					and p.idfirma = @idfirma
						and pf.dtpagamento between @de and @ate
		group by p.idpessoa, p.nmepessoa, p.pis, p.cpf,f.descricao, f.cnpj
		order by p.nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END