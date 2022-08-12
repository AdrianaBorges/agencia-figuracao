USE [luzecorcasting]
GO
ALTER PROCEDURE [dbo].[p_RegistraPessoaFigurante]

	@operacao nvarchar(20),
	@idfirma int = 0,
	@idpessoa int = 0,
	@idtipopessoa int,
	@nmepessoa nvarchar(100),
	@sexo nvarchar(1),
	@dtnascimento datetime,
	@dtcadastro datetime,
	@status nvarchar(1),
	@idbairro int = 0,
	@logradouro nvarchar(100) = null,
	@complemento nvarchar(50) = null,
	@cep nvarchar(20) = null,
	@cpf nvarchar(20) = null,
	@rg nvarchar(20) = null,
	@expedicao nvarchar (20) = null,
	@pis nvarchar (20) = null,
	@fixo nvarchar (10) = null,
	@celular nvarchar (10) = null,
	@contato nvarchar (10) = null,
	@email nvarchar (100) = null,
	@nmeartistico varchar (100) = null,
	@nacionalidade char (1) = 0,
	@acesso varchar (20) = null,
	@pasta varchar (20) = null,
	@mae varchar (100) = null,
	@pai varchar (100) = null,
	@estadocivil char (1) = 0,
	@profissao varchar (100) = null,
	@registroator varchar (20) = null,
	@figurante char (1) =  0,
	@ator char (1) = 0,
	@modelo char (1) = 0,
	@altura varchar (5) = null,
	@idadeap varchar (5) = null,
	@peso varchar (5) = null,
	@tipoetnico varchar (30) = null,
	@manequim varchar (5) = null,
	@calcado varchar (5) = null,
	@busto varchar (5) = null,
	@quadril varchar (5) = null,
	@cintura varchar (5) = null,
	@celebridade varchar (100) = null,
	@corolhos varchar (30) = null,
	@cabelo varchar (30) = null,
	@corcabelo varchar (30) = null,
	@tipocabelo varchar (30) = null,
	@corpele varchar (30) = null,
	@apdental int = 0,
	@ctps varchar(20) = null,
	@widcolaborador int,
	@responsavel varchar(60) = null,
	@cpfresp  varchar(30) = null,
	@certnascimento  varchar(30) = null,
	@livro  varchar(30) = null
      

AS
	declare
	@wdescricao nvarchar(100),
	@wobservacao nvarchar(100),
	@widpessoa int

BEGIN
	
	IF @operacao = 'INSERT'
		begin
		begin try
			begin transaction

				select @widpessoa = max(idpessoa) + 1 from pessoa

				--Insert na tabela Pessoa
				insert into Pessoa (idfirma, idPessoa, idtipopessoa, nmepessoa, sexo, dtnascimento, dtcadastro, status, idbairro, logradouro, complemento, cep,
									cpf, rg, expedicao, pis, ctps, fixo, celular, contato, email)
							values (@idfirma, @widpessoa, 2, @nmepessoa, @sexo, @dtnascimento, @dtcadastro, @status, @idbairro, @logradouro, @complemento, @cep,
									@cpf, @rg, @expedicao, @pis, @ctps, @fixo, @celular, @contato, @email);
													
				--Insert na tabela Figurante
				insert into Figurante (idpessoa, nmeartistico, nacionalidade, acesso, pasta, mae, pai, estadocivil, profissao, 
									   registroator, figurante, ator, modelo, altura, idadeap, peso, tipoetnico, manequim, calcado, busto, quadril,
									   cintura, celebridade, corolhos, cabelo, corcabelo, tipocabelo, corpele, apdental, responsavel, cpf_resp, certnascimento, livro)
							   Values (@widpessoa, @nmeartistico, @nacionalidade, @acesso, @pasta, @mae, @pai, @estadocivil,  
									   @profissao, @registroator, @figurante, @ator, @modelo, @altura, @idadeap, @peso, @tipoetnico, @manequim, @calcado,
									   @busto, @quadril, @cintura, @celebridade, @corolhos, @cabelo, @corcabelo, @tipocabelo, @corpele, @apdental, @responsavel, @cpfresp, @certnascimento, @livro)

				set @wdescricao =  'Figurante ' + @nmepessoa + ' registrado.'
				exec p_RegistraLog @idformulario = 4, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

				commit

		end try

		begin catch
			rollback
			Select ERROR_MESSAGE() as ErrorMessage
		end catch
	end

	IF @operacao = 'UPDATE'
		begin
		begin try
			begin transaction
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
					expedicao		= @expedicao, 
					pis				= @pis, 
					fixo			= @fixo,
					celular			= @celular, 
					contato			= @contato,
					email			= @email,
					ctps			= @ctps
					
				where idpessoa		= @idpessoa;
						
				update Figurante set 
					nmeartistico	= @nmeartistico, 
					nacionalidade	= @nacionalidade, 
					acesso			= @acesso, 
					pasta			= @pasta,
					mae				= @mae, 
					pai				= @pai, 
					estadocivil		= @estadocivil, 
					profissao		= @profissao, 
					registroator	= @registroator, 
					figurante		= @figurante, 
					ator			= @ator, 
					modelo			= @modelo, 
					altura			= @altura, 
					idadeap			= @idadeap,
					peso			= @peso, 
					tipoetnico		= @tipoetnico, 
					manequim		= @manequim, 
					calcado			= @calcado, 
					busto			= @busto, 
					quadril			= @quadril,
					cintura			= @cintura, 
					celebridade		= @celebridade, 
					corolhos		= @corolhos, 
					cabelo			= @cabelo, 
					corcabelo		= @corcabelo,
					tipocabelo		= @tipocabelo, 
					corpele			= @corpele, 
					apdental		= @apdental,
					responsavel		= @responsavel,
					cpf_resp		= @cpfresp,
					certnascimento	= @certnascimento,
					livro			= @livro 

				where idpessoa		= @idpessoa;

			set @wdescricao =  'Colaborador ' + @nmepessoa + ' alterado.'
			exec p_RegistraLog @idformulario = 4, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

			commit
		end try

		begin catch
			rollback
				Select ERROR_MESSAGE() as ErrorMessage
		end catch

	end

END