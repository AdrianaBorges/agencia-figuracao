USE [luzecorcasting]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[RetornaMes](@mes int)
RETURNS VARCHAR(20)

as
BEGIN
   
    if @mes = 1
	begin
		return 'JANEIRO'
	end

	if @mes = 2
	begin
		return 'FEVEREIRO'
	end

	if @mes = 3
	begin
		return 'MARÇO'
	end

	if @mes = 4
	begin
		return 'ABRIL'
	end

	if @mes = 5
	begin
		return 'MAIO'
	end

	if @mes = 6
	begin
		return 'JUNHO'
	end

	if @mes = 7
	begin
		return 'JULHO'
	end

	if @mes = 8
	begin
		return 'AGOSTO'
	end

	if @mes = 9
	begin
		return 'SETEMBRO'
	end

	if @mes = 10
	begin
		return 'OUTUBRO'
	end

	if @mes = 11
	begin
		return 'NOVEMBRO'
	end

	if @mes = 12
	begin
		return 'DEZEMBRO'
	end
	
	RETURN ''
   
END
