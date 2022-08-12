USE [luzecorcasting]
GO
/****** Object:  UserDefinedFunction [dbo].[FormatPis]    Script Date: 05/27/2014 18:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter FUNCTION FormatPis(@numero VARCHAR(1000))
RETURNS VARCHAR(1000)

as
BEGIN
   
	if (Len(@numero) >= 11)
	begin
		return substring(@numero,1,3) + '.' + substring(@numero,4,3) + '.' + substring(@numero,7,3) + '-' + substring(@numero,10,2)
	end

	return @numero
   
END
