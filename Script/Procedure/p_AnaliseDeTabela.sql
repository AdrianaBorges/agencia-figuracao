
USE [dbAgencia]
GO

alter PROCEDURE [dbo].[p_AnaliseDeTabela]
AS
	declare 
	@tabela varchar(20),
	@texto varchar(100) 

BEGIN
	Begin Try
		
		-- Valida tabela Bairro

		set @tabela = 'teste'
		if Exists(Select name from sysobjects where name = @tabela)
		Begin 
			print 'Tabela ' + @tabela + ' validada'
		End
		else
		Begin 
			print 'Tabela ' + @tabela + ' Não Existe!'
			
			CREATE TABLE Tabela 
			( 
				idtabela INT IDENTITY (1,1) PRIMARY KEY 
				, nome VARCHAR(50) NOT NULL 
			) 

			CREATE TABLE Campos 
			( 
				idcampo INT IDENTITY (1,1) PRIMARY KEY 
				, idtabela int, nme_schema varchar(50), nme_coluna varchar(50), tipo varchar(20), tamanho int 
			) 

			SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS C 
			  WHERE 
				TABLE_NAME = 'teste' 
				AND TABLE_SCHEMA = 'dbAgencia' 
				AND COLUMN_NAME = 'Telefone' 
				AND DATA_TYPE = 'VARCHAR' 
				AND CHARACTER_MAXIMUM_LENGTH = 15 

IF NOT EXISTS 
( 
  SELECT * FROM INFORMATION_SCHEMA.COLUMNS C 
  WHERE 
    TABLE_NAME = 'BAIRRO' 
	AND TABLE_CATALOG =  'dbAgencia'
    AND TABLE_SCHEMA = 'dbo' 
    AND COLUMN_NAME = 'IDBAIRRO' 
    AND DATA_TYPE = 'INT' 
    AND CHARACTER_MAXIMUM_LENGTH = NULL 
) 
BEGIN 

   -- Adicionando a coluna Telefone VARCHAR(15) 
   -- à tabela Funcionarios 
   ALTER TABLE teste 
      ADD Telefone VARCHAR(15) 

   PRINT 'Coluna Telefone adicionada à tabela Funcionarios' 

END 
ELSE 
   BEGIN 
     PRINT 'Coluna Telefone já existe na tabela Funcionarios' 
   END





		End
	
	-- Valida tabela Baixa

		set @tabela = 'Baixa'
		if Exists(Select name from sysobjects where name = @tabela)
		Begin 
			print 'Tabela ' + @tabela + ' validada'
		End
		else
		Begin 
			print 'Tabela ' + @tabela + ' Não Existe!'
		End
		print 'Analise completa...'

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END


select * from campos
