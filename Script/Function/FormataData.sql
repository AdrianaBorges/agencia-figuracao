USE [luzecorcasting]
GO
/****** Object:  UserDefinedFunction [dbo].[FormataData]    Script Date: 05/27/2014 18:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[FormataData](@data datetime)
RETURNS VARCHAR(20)

as
BEGIN
   
	if (Len(@data) > 5)
	begin
		return CONVERT(VARCHAR(10), @data, 105) 
	end

	return @data
   
END
