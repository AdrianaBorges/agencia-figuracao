Use [luzecorcasting]
Go

alter PROCEDURE [dbo].[p_listaPedidoPorFatura]
	
	@idcartafatura int
	
AS
	declare @widprograma int
BEGIN
	
	Begin Try

		Select @widprograma = idprograma 
		From cartafatura 
		Where idcartafatura = @idcartafatura 

		create table #tab (idpedido char(8),
						   numpedido varchar(10),
						   dtpedido datetime,
						   idprograma int,
						   descricao varchar(100),
						   totpedido decimal(18,2),
						   totrealizado decimal(18,2))

		INSERT INTO #tab
		
		select 
			 REPLICATE('0', 5 - LEN(p.idpedido)) + RTrim(p.idpedido) as idpedido,
			 REPLICATE('0', 8 - LEN(p.numpedido)) + RTrim(p.numpedido) as numpedido,
			 p.dtpedido,
			 prog.idprograma,
			 replicate('0', 4 - len(prog.idprograma)) + rtrim(prog.idprograma) +
			 ' - ' + prog.descricao as descricao,
			 coalesce(sum(pf.vlrbruto), 0) as totpedido,
			 (select coalesce(CAST(sum(pfe.vlrbruto) * 93.9 / 100 AS
								   DECIMAL(18, 2)) + sum(pfe.vlrbruto),
							  0)
				from PedidoFigurante pfe
			   where pfe.idpedido = p.idpedido
				 and pfe.idtipo in (1, 2)) +
			 (select coalesce(CAST(sum(pfe.vlrbruto) * 70 / 100 AS
								   DECIMAL(18, 2)) + sum(pfe.vlrbruto),
							  0)
				from PedidoFigurante pfe
			   where pfe.idpedido = p.idpedido
				 and pfe.idtipo in (3,4)) as totrealizado
		from pedido p
	   inner join programa prog
		  on prog.idprograma = p.idprograma
		left join PedidoFigurante pf
		  on pf.idpedido = p.idpedido
	   where p.idcartafatura = @idcartafatura
			and p.idprograma = @widprograma

	   group by p.idpedido,
				p.numpedido,
				p.dtpedido,
				prog.idprograma,
				prog.descricao
	   order by p.numpedido

		select idpedido, numpedido, rtrim(CONVERT(char, dtpedido, 105)) as dtpedido, descricao, totpedido, totrealizado from #tab
		
		drop table #tab 

	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
		drop table #tab 

	End Catch

END