USE [luzecorcasting]
GO

alter PROCEDURE p_listaFiguranteParaUnificar
	@dado varchar(100) = '',
	@idpessoa int = 0
AS

BEGIN
	
	Begin Try
		
		Select 
			dbo.FormataCodigo(p.idpessoa,'M') as idpessoa,
			p.nmepessoa,
			rtrim(CONVERT(char, p.dtnascimento, 105)) as dtnascimento,
			dbo.FormataDoc(p.cpf) as cpf,
			dbo.FormataDoc(p.pis) as pis,
			dbo.FormataTelefone(p.celular) + '  ' + dbo.FormataTelefone(p.fixo) + '  ' + dbo.FormataTelefone(p.contato) as telefone

		From Pessoa p
		Inner Join Figurante f on f.idpessoa = p.idpessoa 

		Where p.nmepessoa like '%' + @dado + '%'
			and p.idpessoa <> @idpessoa
		Order by p.nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

