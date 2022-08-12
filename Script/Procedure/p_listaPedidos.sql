USE [luzecorcasting]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[p_ListaPedidos]
	@numpedido varchar(70) = '',
	@idproduto int,
	@idfirma int

AS
BEGIN

	Begin Try
		 select top 200 REPLICATE('0', 5 - LEN(pd.idpedido)) + RTrim(pd.idpedido) as idpedido,
          REPLICATE('0', 7 - LEN(pd.numpedido)) + RTrim(pd.numpedido) as numpedido,
          rtrim(CONVERT(char, pd.dtpedido, 105)) AS dtpedido,
          pg.descricao,
          pd.extra,
          coalesce(sum(ip.qtd), 0) as qtdfigurante,
          (select coalesce(sum(qtd * valor), 0)
             from pedqtdfigurante
            where idpedido = pd.idpedido
            group by idpedido) as vlrpedido
   
		 from Pedido pd(nolock)
		inner join programa pg
		   on pg.idprograma = pd.idprograma
	   --left join ItensPedido ip
	   --   on ip.idpedido = pd.idpedido
		 left join pedqtdfigurante ip
		   on ip.idpedido = pd.idpedido
   
		where (pd.numpedido like '%' + @numpedido + '%' or @numpedido is null)
		  and (pd.idprograma = @idproduto or @idproduto = 0)
		  and pd.idfirma = @idfirma
   
		group by pd.idpedido, pd.dtpedido, pd.numpedido, pg.descricao, pd.extra
		order by pd.dtpedido desc, pd.numpedido desc
		
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage

	End Catch
	
END