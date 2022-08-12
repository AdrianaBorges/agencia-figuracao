USE [luzecorcasting]
GO

alter PROCEDURE p_listaConsultaFigurante
	@idfirma int = 0,
	@nome nvarchar(50)
	
AS
		
BEGIN
	
	Begin Try
		
		Select distinct
			replicate('0',5 - Len(p.idpessoa)) + Rtrim(p.idpessoa) as id,
			p.nmepessoa,
			dbo.FormataDoc(p.cpf) as cpf,
			dbo.FormataDoc(p.pis) as pis,
			p.rg

		From PedidoFigurante fp
		Inner Join Pessoa p on p.idpessoa = fp.idpessoa
		
		Where p.idfirma = @idfirma
			And fp.status = 0
				And (p.nmepessoa like '%' + @nome + '%' or @nome = '')
		Order by p.nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END
