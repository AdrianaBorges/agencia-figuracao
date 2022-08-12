Use [luzecorcasting]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[p_RecuperaPedidoPorId]
	@idpedido int

AS
BEGIN

	Begin Try

			 select 
			  pd.idpedido, --0
			  REPLICATE('0', 7 - LEN(pd.numpedido)) + RTrim(pd.numpedido) as numpedido, --1
			  CONVERT(char, pd.dtpedido, 105) AS dtpedido, --2
			  pg.descricao, --3
			  pd.extra, --4
			  pd.idempresa, --5
			  CONVERT(char, pd.dtcadastro, 105) AS dtcadastro, --6
			  pd.idprograma, --7
			  pd.cena, --8
			  pd.capitulo, --9
			  pd.hora, --10
			  pd.horaini, --11
			  pd.horafim, --12
			  pd.observacao, --13
          
			  coalesce((select sum(vlrbruto)
						 from PedidoFigurante pf
						where pf.idpedido = pd.idpedido),
					   0) as vlrpedido,
			  coalesce((select sum(vlrbruto)
						 from PedidoFigurante pf
						where pf.status = 1
						  and pf.idpedido = pd.idpedido),
					   0) as vlrpago, --14
          
			  coalesce((select sum(vlrbruto)
						  from PedidoFigurante pf
						 where pf.idpedido = pd.idpedido) -
					   (select sum(vlrbruto)
						  from PedidoFigurante p
						 where p.status = 1
						   and p.idpedido = pd.idpedido),
					   0) as vlrpendente, --15
          
			  (select coalesce(CAST(sum(pf.vlrbruto) * 93.9 / 100 AS
									DECIMAL(18, 2)) + sum(pf.vlrbruto),
							   0)
				 from PedidoFigurante pf
				where pf.idpedido = pd.idpedido
				  and pf.idtipo in (1, 2)) +
			  (select coalesce(CAST(sum(pf.vlrbruto) * 70 / 100 AS
									DECIMAL(18, 2)) + sum(pf.vlrbruto),
							   0)
				 from PedidoFigurante pf
				where pf.idpedido = pd.idpedido
				  and pf.idtipo in (3)) as totprevisto --16
   
		 from Pedido pd(nolock)
		inner join programa pg
		   on pg.idprograma = pd.idprograma
   
		where pd.idpedido = @idpedido


	end try
	
	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END