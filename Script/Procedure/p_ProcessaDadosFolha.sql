
USE [luzecorcasting]
GO

create PROCEDURE [dbo].[p_ProcessaDadosFolha]
	@idfolha int,
	@widcolaborador int

AS
	
BEGIN

	Begin Try

	declare 
		@widpessoa int,
		@wremuneracao decimal(18,2),
		@wremuneracaoextra decimal(18,2),
		@wtotremum decimal(18,2),

		@widremuneracao int = 0,
		@wclt int = 0,
		@tipo int, --1 entrada, 2 saida
		@tipopessoa int = 1,--colaborador
		@status int = 1, --Ativo
		@wpercentual decimal(18,2),
		@wdesconto decimal(18,2)

	declare
		@wdescricao nvarchar(100),
		@wobservacao nvarchar(100) = '',
		@wnmecolaborador nvarchar (100),
		@wdescremuneracao nvarchar(100),
		@wvlrremum decimal (18,2)

	--Varre a tabela pessoa em busca dos colaboradores ativos
	declare cursor_colaborador cursor for
					
		select distinct c.idpessoa, c.clt
		from pessoa p
		inner join colaborador c on c.idpessoa = p.idpessoa
		inner join dadoremuneracao dr on dr.idpessoa = p.idpessoa
			where p.idtipopessoa = 1
				and p.status = 1
					and p.idpessoa not in (select df.idpessoa 
					from dadofolha df 
						where df.idpessoa = p.idpessoa
							and df.idfolha = @idfolha)

	open cursor_colaborador
	fetch next from cursor_colaborador into @widpessoa,@wclt

	while @@fetch_status = 0
		begin
			begin try
				begin transaction
					--Varre a tabela DadoRemuneracao em busca dos recebimentos
					declare cursor_remuneracao cursor for
					
					select re.descricao, dr.valor, re.idremuneracao 
					from dadoremuneracao dr, remuneracao re
						where re.idremuneracao = dr.idremuneracao
							and dr.idpessoa = @widpessoa

					union

					select re.descricao, sum(dr.valor) as valor, re.idremuneracao 
					from dadoextrafolha dr, remuneracao re
						where re.idremuneracao = dr.idremuneracao
							and dr.idpessoa = @widpessoa
								and dr.idfolha = @idfolha
					group by re.descricao, re.idremuneracao

					open cursor_remuneracao
					fetch next from cursor_remuneracao into @wdescremuneracao, @wvlrremum, @widremuneracao
					while @@fetch_status = 0
					begin
					select @widremuneracao as tiporemuneracao
						if (@widremuneracao = 3 or @widremuneracao = 4 or @widremuneracao = 7)
						begin
							set @wvlrremum = 0
						end
						print 'insere dadofolha'
						insert into dadofolha(idfolha, tipo, idpessoa, valor, idremuneracao, descricao,idlancamento,status) values (@idfolha, 1, @widpessoa, @wvlrremum, @widremuneracao, @wdescremuneracao,0,0) 
						
						select @wnmecolaborador = nmepessoa from pessoa where idpessoa = @widpessoa

						set @wdescricao =  @wdescremuneracao --+ ' ref. ' + @frase + ' registrado para colaborador(a) ' + @wnmecolaborador
						exec p_RegistraLog @idformulario = 7, @descricao = @wdescricao, @observacao = @wobservacao, @idcolaborador = @widcolaborador
						
						select @wremuneracao = sum(valor) from dadoremuneracao where idpessoa=@widpessoa and idremuneracao = 6

					
					fetch next from cursor_remuneracao into @wdescremuneracao, @wvlrremum, @widremuneracao
					end
					
					close cursor_remuneracao
					deallocate cursor_remuneracao

				commit
				--return 0
			end try

			begin catch

				rollback
			end catch

			-- Gera INSS
			if (@wclt = 1) -- e igual a remuneração mensal 
			begin
					
				if (@widremuneracao = 1 or @widremuneracao = 6 or @widremuneracao = 8)
				begin
					select @wtotremum = sum(valor) from dadofolha where idremuneracao in (1,6,8) and idpessoa = @widpessoa and idfolha = @idfolha
					
					select @wpercentual = percentual from inss where (@wtotremum between de and ate)

					set @wdesconto = @wtotremum * @wpercentual / 100 -- desconto sobre o percentual de acordo com a faixa de salário

					insert into dadofolha(idfolha, tipo, idpessoa, valor, idremuneracao, descricao) values (@idfolha, 2, @widpessoa, @wdesconto, 0, 'INSS') 
				end

				if (@widremuneracao = 9) -- Ferias
				begin
					select @wtotremum = sum(valor) from dadofolha where idremuneracao = 9 and idpessoa = @widpessoa and idfolha = @idfolha
					
					select @wpercentual = percentual from inss where (@wtotremum between de and ate)

					set @wdesconto = @wremuneracaoextra * @wpercentual / 100 -- desconto sobre o percentual de acordo com a faixa de salário

					insert into dadofolha(idfolha, tipo, idpessoa, valor, idremuneracao, descricao) values (@idfolha, 2, @widpessoa, @wdesconto, 0, 'INSS REF.FÉRIAS') 
				end
			end

			fetch next from cursor_colaborador into @widpessoa, @wclt
		end

		close cursor_colaborador
		deallocate cursor_colaborador

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END