Use [dbagencia]
Go

create PROCEDURE p_listaProduto
    @dado varchar(100) = ''
AS
BEGIN

	Begin Try
        select 
			  REPLICATE('0', 5 - LEN(idprograma)) + RTrim(idprograma) as idprograma, --0
			  rtrim(CONVERT(char, data, 105)) AS data, --4
			  descricao, --1
			  observacao, --2
			  status

	    from programa 
		where descricao like '%' + @dado + '%'
			and status = 1
		order by descricao
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END