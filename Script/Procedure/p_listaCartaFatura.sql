USE [luzecorcasting]
GO

alter PROCEDURE [dbo].[p_listaCartaFatura]
	@numcarta varchar(100) = '',
	@idfirma int
AS

BEGIN

	Begin Try

		SELECT
			REPLICATE('0', 5 - LEN(cf.idcartafatura)) + RTRIM(cf.idcartafatura) AS idcartafatura, 
			REPLICATE('0', 6 - LEN(cf.numcarta)) + RTRIM(cf.numcarta) AS numcarta, 
			replicate('0',4 - len(prg.idprograma)) + rtrim(prg.idprograma) + ' - ' + prg.descricao as descricao, 
			rtrim(CONVERT(char, cf.dtemissao, 105)) as dtemissao,

			COALESCE((SELECT SUM(pf.vlrbruto) AS vlrbruto 
			FROM pedido p
			inner join PedidoFigurante pf on pf.idpedido = p.idpedido
			WHERE p.idcartafatura = cf.idcartafatura), 0) AS vlrcache, 


			(select coalesce(CAST(sum(pfe.vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(pfe.vlrbruto),0) 
				from pedido p inner join PedidoFigurante pfe on pfe.idpedido=p.idpedido and pfe.idtipo in (1,2) 
				WHERE p.idcartafatura = cf.idcartafatura) + 
				
			(select coalesce(CAST(sum(pfe.vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(pfe.vlrbruto),0) 
				from pedido p inner join PedidoFigurante pfe on pfe.idpedido=p.idpedido and pfe.idtipo in (3,4) 
				WHERE p.idcartafatura = cf.idcartafatura) as totrealizado,

			CASE WHEN cf.idnota > 0 THEN 
				CASE WHEN nf.status = 1 THEN 'Nº ' + ltrim(rtrim(CONVERT(char,nf.numnota))) + ', paga em ' + CONVERT(char, CONVERT(VARCHAR(10), nf.dtpagamento, 120)) 
					ELSE replicate('0',8 - len(nf.numnota)) + rtrim(nf.numnota) 
				END 
				ELSE replicate('0',8 - len(nf.numnota)) + rtrim(nf.numnota) 
			END AS notafiscal,
			cf.observacao,
			cf.idnota 

		FROM
			CartaFatura AS cf 
			INNER JOIN Programa AS prg ON prg.idprograma = cf.idprograma 
			LEFT OUTER JOIN NotaFiscal AS nf ON nf.idnota = cf.idnota
			    
		where (cf.numcarta like '%' + @numcarta + '%' or @numcarta = 0)
			and cf.idfirma = @idfirma

			--and (cf.idprograma = @idprograma or @idprograma not in (0))

		ORDER BY cf.dtemissao DESC

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch

	

END