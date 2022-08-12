USE [luzecorcasting]
GO
/****** Object:  UserDefinedFunction [dbo].[FormataCodigo]    Script Date: 05/27/2014 18:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter FUNCTION [dbo].[FormataCodigo](@numero int, @tipo varchar(1))

RETURNS VARCHAR(15)

as
BEGIN
   
	if @tipo = 'M' -- Matricula
	begin
		return REPLICATE('0', 6 - LEN(@numero)) + RTrim(@numero) 

	end

	if @tipo = 'P' -- Pedido
	begin
		return REPLICATE('0', 6 - LEN(@numero)) + RTrim(@numero) 

	end

	return ''
   
END
