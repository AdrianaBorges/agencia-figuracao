Use [luzecorcasting]
Go

create PROCEDURE [dbo].[p_listaFuncionalidade]
	@idmodulo int
AS
	
BEGIN

	Begin Try
		
		Select 
			m.descricao as modulo, 
			sm.descricao as submodulo, 
			f.descricao as funcionalidade,
			case f.status
				when 0 then 'PENDENTE'
				when 1 then 'FINALIZADO'
				end as status,
			f.observacao

		From Funcionalidade f
		Inner Join SubModulo sm on sm.idsubmodulo = f.idsubmodulo
		Inner Join Modulo m on m.idmodulo = sm.idmodulo
	
		Where m.idmodulo = @idmodulo

	End Try

	Begin Catch
		rollback
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
END

