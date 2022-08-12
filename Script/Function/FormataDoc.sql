USE [luzecorcasting]
GO
/****** Object:  UserDefinedFunction [dbo].[FormataDoc]    Script Date: 05/27/2014 18:21:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter FUNCTION [dbo].[FormataDoc](@numero VARCHAR(1000))
RETURNS VARCHAR(1000)

as
	
BEGIN
   declare
	@doc varchar(20)
   
    Select @doc = replicate('0', 11 - len(replace(replace(@numero,'.',''),'-',''))) + rtrim(replace(replace(@numero,'.',''),'-',''))

	if (Len(@numero) = 11)
	begin
		return substring(@doc,1,3) + '.' + substring(@doc,4,3) + '.' + substring(@doc,7,3) + '-' + substring(@doc,10,2)
	end

	return @numero
   
END
