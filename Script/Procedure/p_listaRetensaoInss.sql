ALTER PROCEDURE [dbo].[p_listaRetensaoInss]

AS
	
BEGIN
	Begin Try

		select
			 pe.idpessoa, pe.nmepessoa, 
			 sum(pf.vlrbruto) as vlrliquido, 
			 CAST(sum(pf.vlrbruto) * 11/100 AS DECIMAL(18, 2)) as vlronze,
			 CAST(sum(pf.vlrbruto) * 20/100 AS DECIMAL(18, 2)) as vlrvinte,
			 CAST(sum(pf.vlrbruto) * 11/100 AS DECIMAL(18, 2)) + CAST(sum(pf.vlrbruto) * 20/100 AS DECIMAL(18, 2)) as vlrrecolher 
			 --cast(sum(pf.vlrbruto) * 11/100 + sum(pf.vlrbruto) * 20/100  AS DECIMAL(18, 2)) as vlrrecolher 
		from PedidoFigurante pf
		inner join TipoFiguracao tf on tf.idtipo = pf.idtipo and tf.descinss = 1
		inner join Pedido p on p.idpedido = pf.idpedido
		inner join Pessoa pe on pe.idpessoa = pf.idpessoa 
		inner join CartaFatura cf on cf.idcartafatura = p.idcartafatura 
		--where pf.status = 1
			where cf.idnota = 83
		group by pe.idpessoa, pe.nmepessoa
		order by pe.nmepessoa


	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END