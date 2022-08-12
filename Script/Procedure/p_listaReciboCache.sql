USE [luzecorcasting]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[p_listaReciboCache]
	@idpessoa int

AS
BEGIN

	Begin Try

		select 
			0,
			--fp.nrrb + ' - ' + CONVERT(char, fp.dtpagamento, 105) as recibo
			Cast(fp.nrrb as varchar)  + ' - ' + Convert(char, fp.dtpagamento, 105) as nrrb
		from 
			PedidoFigurante fp (nolock)
			inner join pedido pd (nolock) on pd.idpedido = fp.idpedido

		where fp.idpessoa = @idpessoa  
			and fp.status  = 1 
				and fp.nrrb != 0	
		group by fp.nrrb, fp.dtpagamento
		order by fp.dtpagamento desc

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
		
END