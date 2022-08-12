Use[dbAgencia]
Go

alter PROCEDURE [dbo].[p_RegistraColaborador]
	@operacao nvarchar(20),
	@idfirma int = 0,
	@idpessoa int = 0,
	@idtipopessoa int,
	@nmepessoa nvarchar(100),
	@sexo nvarchar(1),
	@dtnascimento datetime = null,
	@dtcadastro datetime = null,
	@status nvarchar(1),
	@idbairro int = 0,
	@logradouro nvarchar(100) = null,
	@complemento nvarchar(50) = null,
	@cep nvarchar(20) = null,
	@cpf nvarchar(20) = null,
	@rg nvarchar(20) = null,
	@cnpj nvarchar (20) = null,
	@expedicao nvarchar (20) = null,
	@pis nvarchar (20) = null,
	@ctps nvarchar (20) = null,
	@serie nvarchar (20) = null,
	@cartreservista nvarchar (20) = null,
	@fixo nvarchar (10) = null,
	@celular nvarchar (10) = null,
	@contato nvarchar (10) = null,
	@email nvarchar (100) = null,
	@idCargo int,
	@dtdesligamento datetime = null,
	@clt int = 0,
	@comissao int = 0,
	@widcolaborador int

AS
	declare
	@wdescricao nvarchar(100),
	@wobservacao nvarchar(100),
	@widpessoa int

BEGIN

	if @idcargo = 7
	begin
		set @idtipopessoa = 3
	end
	
	IF @operacao = 'INSERT'
		BEGIN
		begin try
			begin transaction 

				select @widpessoa = max(idpessoa) + 1 from pessoa

				--Insert na tabela Pessoa
				insert into Pessoa (idfirma, idpessoa, idtipopessoa, nmepessoa, sexo, dtnascimento, dtcadastro, status, idbairro, logradouro, complemento, cep, 
				                    cpf, rg, cnpj, expedicao, pis, ctps, serie, cartreservista, fixo, celular, contato)
					        values (@idfirma, @widpessoa, 1, @nmepessoa, @sexo, @dtnascimento, @dtcadastro, @status, @idbairro, @logradouro, @complemento, @cep,
							        @cpf, @rg, @cnpj, @expedicao, @pis, @ctps, @serie, @cartreservista, @fixo, @celular, @contato);

				--Insert na tabela Colaborador
				insert into Colaborador (idpessoa, idcargo, dtdesligamento,clt,comissao)
						   	values      (@widpessoa, @idcargo, @dtdesligamento,@clt,@comissao)

				set @wdescricao =  'Colaborador ' + @nmepessoa + ' registrado.'
				exec p_RegistraLog @idformulario = 2, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

				commit
				
		end try

		begin catch
			rollback
			Select ERROR_MESSAGE() as ErrorMessage
			
		end catch
	END
	
	IF @operacao = 'UPDATE'
		BEGIN
		Begin try
			Begin transaction 
				update Pessoa set 
					nmepessoa		= @nmepessoa, 
					sexo			= @sexo, 
					dtnascimento	= @dtnascimento, 
					status			= @status, 
					idbairro		= @idbairro, 
					logradouro		= @logradouro, 
					complemento		= @complemento, 
					cep				= @cep, 
					cpf				= @cpf,
					rg				= @rg, 
					cnpj			= @cnpj, 
					expedicao		= @expedicao, 
					pis				= @pis, 
					serie			= @serie, 
					cartreservista	= @cartreservista, 
					fixo			= @fixo,
					celular			= @celular, 
					contato			= @contato,
					email			= @email 
				where idpessoa		= @idpessoa ;

				update colaborador set 
					idcargo		   = @idcargo, 
					dtdesligamento = @dtdesligamento,
					clt			   = @clt,
					comissao	   = @comissao
				where idpessoa	   = @idpessoa;

			set @wdescricao =  'Colaborador ' + @nmepessoa + ' alterado.'
			exec p_RegistraLog @idformulario = 2, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

			commit
			
		End Try

		Begin Catch
			Rollback
				Select ERROR_MESSAGE() as ErrorMessage

		End Catch
	
	END 

END 

