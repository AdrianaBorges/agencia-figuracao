USE [luzecorcasting]
Go

ALTER PROCEDURE [dbo].[p_RegistraPedido]
	
	@operacao nvarchar(20),
	@idfirma int= 0,
	@idpedido int = 0,
	@extra int = 0,
	@dtcadastro datetime,
	@numpedido nvarchar(15),
	@idempresa int,
	@idprograma int,
	@dtpedido datetime,
	@hora nvarchar(5) = null,
	@horaini nvarchar(5) = null,
	@horafim nvarchar(5) = null,
	@cena nvarchar(30) = null,
	@capitulo nvarchar (30) = null,
	@observacao nvarchar (300) = null,
	@widcolaborador int
	
AS
	declare
	@wdescricao nvarchar(100),
	@wobservacao nvarchar(100),
	@widpedido int

BEGIN

	--raiserror 30005 'ERRO AO GRAVAR OS DADOS DO PEDIDO.'
	IF @operacao = 'INSERT'
	begin
		begin try
			begin transaction
			
				select @widpedido = max(idpedido) + 1 from Pedido

				--Insert na tabela Pedido
				insert into Pedido (idfirma, idpedido, extra, idcartafatura, dtcadastro, numpedido, idempresa, idprograma, dtpedido, hora, horaini,
									horafim, cena, capitulo, status, observacao) 
							values (@idfirma, @widpedido, @extra, 0, @dtcadastro, @numpedido, @idempresa, @idprograma, @dtpedido, @hora, @horaini,
									@horafim, @cena, @capitulo, 1, @observacao)


				set @wdescricao =  'Pedido de Gravação nº ' + @numpedido + ' registrado com sucesso.'
				exec p_RegistraLog @idformulario = 9, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

			commit
		
		end try

		begin catch
			rollback
			Select ERROR_MESSAGE() as ErrorMessage
		end catch
	END

		IF @operacao = 'UPDATE'
		begin
			begin try
				begin transaction

					--Atualiza os dados na tabela pedido
					update pedido set extra        = @extra,
										dtcadastro   = @dtcadastro, 
								   		numpedido    = @numpedido,
								 		idempresa    = @idempresa,
										idprograma   = @idprograma,
										dtpedido	 = @dtpedido,
										hora		 = @hora, 
										horaini	     = @horaini,
										horafim	     = @horafim,
										cena         = @cena,
										capitulo     = @capitulo,
										observacao   = @observacao
							where idpedido = @idpedido;

					set @wdescricao =  'Pedido de Gravação ' + @numpedido + ' alterado com sucesso.'
					exec p_RegistraLog @idformulario = 9, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador

				commit
				
			end try

			begin catch
				rollback
			Select ERROR_MESSAGE() as ErrorMessage
			end catch
		END

	END