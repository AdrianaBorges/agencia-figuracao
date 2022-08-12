USE [luzecorcasting]
GO
/****** Object:  StoredProcedure [dbo].[p_RecuperaAlvara]    Script Date: 07/10/2015 19:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[p_RecuperaAlvara]
	@idalvara int
	 
AS
BEGIN
	Begin Try
				
		Select
			al.idalvara,
			convert(varchar(10), al.data,105) as data, 
			al.numprocesso,
			al.idprograma

		From Alvara al
		where al.idalvara = @idalvara
		
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END