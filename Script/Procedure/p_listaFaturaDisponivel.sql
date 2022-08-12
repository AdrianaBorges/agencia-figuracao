Use [luzecorcasting]
Go

alter PROCEDURE [dbo].[p_listaCartaFaturaParaNotaFiscal]
	@idfirma int,
	@idnota int

AS
BEGIN
	Begin Try
		
		SELECT
			REPLICATE('0', 5 - LEN(cf.idcartafatura)) + RTRIM(cf.idcartafatura) AS idcartafatura, 
			REPLICATE('0', 6 - LEN(cf.numcarta)) + RTRIM(cf.numcarta) AS numcarta, 
			rtrim(CONVERT(VARCHAR(10), cf.dtemissao, 105)) as dtemissao,
			cf.observacao,
				COALESCE((SELECT SUM(pf.vlrbruto) AS vlrbruto 
						  FROM pedido p
						  inner join PedidoFigurante pf on pf.idpedido = p.idpedido
						  WHERE p.idcartafatura = cf.idcartafatura), 0) AS vlrcache, 

				(select coalesce(CAST(sum(pfe.vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(pfe.vlrbruto),0) 
				 from pedido p inner join PedidoFigurante pfe on pfe.idpedido=p.idpedido  and pfe.idtipo in (1,2)
				 WHERE p.idcartafatura = cf.idcartafatura) + 
				
				(select coalesce(CAST(sum(pfe.vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(pfe.vlrbruto),0) 
				 from pedido p inner join PedidoFigurante pfe on pfe.idpedido=p.idpedido and pfe.idtipo in (3,4)
				 WHERE p.idcartafatura = cf.idcartafatura) as totrealizado
			FROM
				CartaFatura AS cf 
				INNER JOIN Programa AS prg ON prg.idprograma = cf.idprograma 
				LEFT OUTER JOIN NotaFiscal AS nf ON nf.idnota = cf.idnota
			Where cf.idfirma = @idfirma
				and cf.idnota = @idnota
					
			ORDER BY cf.dtemissao

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END