USE [luzecorcasting]
GO
/****** Object:  StoredProcedure [dbo].[p_listaAlvara]    Script Date: 07/10/2015 19:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[p_carregaGridAlvara]
AS
BEGIN
	Begin Try
				
		Select
			REPLICATE('0', 5 - LEN(al.idalvara)) + RTRIM(al.idalvara) as idalvara,
			convert(varchar(10), al.data,105) as data, 
			al.numprocesso,
			REPLICATE('0', 5 - LEN(pr.idprograma)) + RTRIM(pr.idprograma) + ' - ' + pr.descricao as programa

		From Alvara al
		inner join programa pr on pr.idprograma = al.idprograma
		Order by al.data	
		
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END