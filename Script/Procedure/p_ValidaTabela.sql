USE [dbAgencia]
GO
/****** Object:  StoredProcedure [dbo].[p_baixaCachePorRecibo]    Script Date: 02/23/2014 11:00:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[p_ValidaTabela]
	@tabela nvarchar(30)

AS
	declare
	@idtabela int

BEGIN

	Begin Try
		
		--deallocate cursor_temp

		-- 1-Verifica se a tabela existe
		if Exists(Select name from sysobjects where name = @tabela)
		Begin 
			-- Valida os campo
			Select @idtabela = idtabela From Tabela Where nome = @tabela

			declare 
				@wnome nvarchar(50), 
				@wcatalog nvarchar(50), 
				@wschema nvarchar(50), 
				@wcoluna nvarchar(50),
				@wisnull nvarchar(5),
				@wtipo nvarchar(50)

			declare cursor_temp cursor for
			
				select t.nome, c.nme_catalog, c.nme_schema, c.nme_coluna, c.is_null, c.tipo
				from Campos c
				inner join tabela t on t.idtabela = c.idtabela
					where c.idtabela = @idtabela

			open cursor_temp
			fetch next from cursor_temp into @wnome, @wcatalog, @wschema, @wcoluna, @wisnull, @wtipo

			while @@fetch_status = 0
			begin

				if not Exists
					(SELECT 1 
						FROM INFORMATION_SCHEMA.COLUMNS C 
							WHERE TABLE_NAME = @wnome
								AND TABLE_CATALOG = @wcatalog
									AND TABLE_SCHEMA = @wschema 
										AND COLUMN_NAME = @wcoluna 
											AND IS_NULLABLE = @wisnull
												AND DATA_TYPE = @wtipo) 
				Begin
					--ALTER TABLE @wnome 
					--ADD Telefone VARCHAR(15) 
					print 'Campo ' + @wcoluna + ', não encontrado na tabela'
				End

			fetch next from cursor_temp into @wnome, @wcatalog, @wschema, @wcoluna, @wisnull, @wtipo
			end	

			close cursor_temp
			deallocate cursor_temp

			print 'Tabela ' + @tabela + ' Vaidada com sucesso.'
		End
		else
		Begin 
			print 'Tabela ' + @tabela + ' Não Existe!'
		end

	End Try

	Begin Catch
		deallocate cursor_temp
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

end