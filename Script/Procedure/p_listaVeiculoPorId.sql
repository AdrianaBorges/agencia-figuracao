USE [luzecorcasting]
Go

alter PROCEDURE [dbo].[p_listaVeiculoPorId]
	@idpessoa int
	
AS

BEGIN
	Begin Try
	
		Select
			REPLICATE('0', 5 - LEN(v.idveiculo)) + RTrim(v.idveiculo) as idveiculo, --0
			ma.descricao as marca, --1
			mo.descricao as modelo, --2
			v.ano --3
		From Veiculo v
		inner join modelo mo on mo.idmodelo = v.idmodelo
		inner join marca ma on ma.idmarca = v.idmarca
		Where v.idpessoa = @idpessoa

		order by v.ano

	End Try

		Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END

