Use [luzecorcasting]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[p_RecuperaContaAPagar]
	@idtipo int, 
	@idcontaapagar int

AS
BEGIN

	Begin Try

		if @idtipo = 1
		begin
			Select 
				cap.idcontaapagar,
				rtrim(CONVERT(char, cap.vencimento, 105)) as vencimento,
				cap.idcusto,
				p.idpessoa,
				cap.descricao,
				cap.valor,
				cap.observacao,
				cap.dtpagamento

			From ContasAPagar cap
			Inner Join CentroDeCusto cdc on cdc.idcusto = cap.idcusto
			Inner Join Pessoa p on p.idpessoa = cap.idpessoa

			Where cap.idcontaapagar = @idcontaapagar
		end

		if @idtipo = 2
		begin

			select
				fp.id,
				p.dtpedido,
				fp.idcusto,
				fp.idpessoa,
				cdc.descricao,
				fp.vlrliquido as valor,
				'Pedido Nº: ' + p.numpedido + ' Produto: ' + prog.descricao as  observacao,
				fp.dtpagamento
			
			from PedidoFigurante fp
			inner join pedido p on p.idpedido = fp.idpedido
			inner join CentroDeCusto cdc on cdc.idcusto = fp.idcusto
			inner join Pessoa pe on pe.idpessoa = fp.idpessoa
			inner join Programa prog on prog.idprograma = p.idprograma
			Where fp.id = @idcontaapagar

		end


	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
		
END