Use [dbAgencia]
Go

create PROCEDURE [dbo].[p_listaBanco]
	
AS
		
BEGIN
	Begin Try

		Select
			b.idbanco,
			REPLICATE('0', 3 - LEN(b.numero)) + RTrim(b.numero) + '-' + b.nmebanco as nmebanco

		From Banco b
		Order by b.nmebanco

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END
