USE [luzecorcasting]
GO

alter PROCEDURE p_listaColaborador
	@idfirma int = 0,
	@dado varchar(100) = '',
	@status int = 0
AS
		
BEGIN
	
	Begin Try
		
		Select 
			REPLICATE('0', 5 - LEN(p.idpessoa)) + RTrim(p.idpessoa) as idpessoa,
			RTrim(Convert(char, p.dtcadastro, 105)) as dtcadastro,
			p.nmepessoa,
			cg.descricao,
			dbo.FormataTelefone(p.celular) + dbo.FormataTelefone(p.fixo) as telefone

		From Pessoa p
		Inner Join Colaborador c on c.idpessoa = p.idpessoa 
		Inner Join Cargo cg on cg.idcargo = c.idcargo
		Where p.nmepessoa like '%' + @dado + '%'
			and p.status = 1

		Order by p.nmepessoa

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

