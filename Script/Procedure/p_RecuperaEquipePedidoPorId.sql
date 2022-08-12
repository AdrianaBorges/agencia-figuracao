Use[dbAgencia]
Go

create PROCEDURE [dbo].p_RecuperaEquipePedidoPorId
	@idequipe int = 0
AS
		
BEGIN

	Begin Try
	
		Select
			ep.idequipe,
			p.nmepessoa,

			case cob.idcargo
				When 2 then '02- PRODUTOR(A)'
				When 4 then '04- FISCAL'
			end as cargo

		From EquipePedido ep
		Inner Join Pessoa p on p.idpessoa = ep.idpessoa
		Inner Join Colaborador cob on cob.idpessoa = p.idpessoa 
		Inner Join Cargo c on c.idcargo = cob.idcargo
		Where ep.idequipe = @idequipe
		Order by p.nmepessoa 

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END