Use[dbAgencia]
Go

create PROCEDURE [dbo].p_RecuperaVeiculoPorId
	@idveiculo int = 0
AS
		
BEGIN

	Begin Try

		Select
			v.idveiculo, --0
			ma.descricao as marca, --1
			mo.descricao as modelo, --2
			v.ano, --3
			ma.idmarca, --4
			mo.idmodelo --5

		From Veiculo v
		inner join modelo mo on mo.idmodelo = v.idmodelo
		inner join marca ma on ma.idmarca = v.idmarca
		Where v.idveiculo = @idveiculo

		order by v.ano

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END