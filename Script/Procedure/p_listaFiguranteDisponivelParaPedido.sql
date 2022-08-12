USE [luzecorcasting]
GO

ALTER PROCEDURE p_listaFiguranteDisponivelParaPedido
	@idpedido int = 0,
	@dado varchar(100) = '',
	@tipoconsulta int = 0
	
AS
		
BEGIN
	
	Begin Try
		
		if @tipoconsulta = 1 -- consulta por nome
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.nmepessoa like '%' + @dado + '%' or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido)

			Order by p.nmepessoa
		end

		if @tipoconsulta = 2 -- consulta por cpf
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.cpf like '%' + @dado + '%' or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido )

			Order by p.nmepessoa
		end

		if @tipoconsulta = 3 -- consulta por rg
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.rg like '%' + @dado + '%' or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido)

			Order by p.nmepessoa
		end

		if @tipoconsulta = 4 -- consulta por data de nascimento
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.dtnascimento = @dado or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido)

			Order by p.nmepessoa
		end

		if @tipoconsulta = 5 -- consulta por data de cadastro
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.dtnascimento = @dado or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido)

			Order by p.nmepessoa
		end

		if @tipoconsulta = 6 -- consulta por celular
		begin 
			Select 
			p.idpessoa,
			p.nmepessoa

			From Pessoa p
			Inner Join Figurante f on f.idpessoa = p.idpessoa 
			Where (p.celular like '%' + @dado + '%' or @dado is null)
				and p.idtipopessoa = 2
				--and p.idpessoa not in (Select fp.idpessoa From PedidoFigurante fp Where fp.idpedido = @idpedido)

			Order by p.nmepessoa
		end


	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

