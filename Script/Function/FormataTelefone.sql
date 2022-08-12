USE [luzecorcasting]
GO
/****** Object:  UserDefinedFunction [dbo].[FormataTelefone]    Script Date: 05/27/2014 18:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter FUNCTION [dbo].[FormataTelefone](@numero VARCHAR(1000))
RETURNS VARCHAR(1000)

as
BEGIN
   
   declare
	@doc varchar(20)

	Select @doc = Substring(replicate('0',11 - Len(@numero)) + Rtrim(@numero),1,7) + '-' + Substring(replicate('0',11 - Len(@numero)) + Rtrim(@numero),6,4) 
   
    return @doc
END

