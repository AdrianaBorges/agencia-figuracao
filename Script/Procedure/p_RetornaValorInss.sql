ALTER PROCEDURE [dbo].[p_RetornaValorInss]
	@idpessoa int = 0,
	@gravacao datetime,
	@idtipo int = 0,
	@vlrcache decimal (18,2)

AS
	declare
		@estrangeiro int,
		@dtniver datetime,
		@idade int,
		@percentual decimal(18,2),
		@vlrinss decimal (18,2),
		@desconto decimal (18,2)
		
BEGIN
	Begin Try

		set @percentual = 11

		If (@idtipo not in (3,4,7,8,11,12))

		
		Begin

			Select @estrangeiro = nacionalidade
			From Figurante
			Where idpessoa = @idpessoa
			--Se estrangueiro retorna 0
			-- 1 - Brasileiro
			-- 2 - Estrangeiro

			If @estrangeiro = 1
			Begin
				--print 'é brasileiro' 

				--Desconta quando menor ou igual a 15 anos
				--Recupera data de aniversário do figurante
				Select @dtniver = dtnascimento 
				From pessoa 
				Where idtipopessoa = 2 
					And idpessoa = @idpessoa

				-- 1ª Situação: Pessoa ainda não fez aniversário
				If (month(@gravacao) < month(@dtniver))
				Begin
					set @idade = datediff(yy, @dtniver, @gravacao) - 1
				End

				set @idade = datediff(yy, @dtniver, @gravacao) - 1

				-- 2ª Situação: O mês corrente, é o mês de aniversário
				If (month(@gravacao) = month(@dtniver))
				Begin
					-- O dia corrente é maior ou igual ao dia do aniversário
					If (day(@gravacao) >= day(@dtniver))
					Begin
						--print '2ª Situação: O dia corrente é maior ou igual ao dia do aniversário'
						set @idade = datediff(yy, @dtniver, @gravacao)
					End
					-- O dia corrente é menor que o dia do aniversário
					Else
					Begin
						--print '2ª Situação: O dia corrente é menor que o dia do aniversário'
						set @idade = datediff(yy, @dtniver, @gravacao) - 1
					End
				End
				
				--Verifica se a pessoa será descontada
				If (@idade <= 15) or (@idade >= 65)
				begin
					select 0
					
				end
				Else
				begin
					Set @vlrinss = @vlrcache * @percentual / 100
					--set @desconto = @vlrcache - @vlrinss
					print @vlrcache 
					print 'desconta'
					Select @vlrinss
				end
			End

			Else
			Begin
				--print 'é estrangeiro' 
				select 0
			End
		End
		Else
		Begin
			select 0
		End

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END