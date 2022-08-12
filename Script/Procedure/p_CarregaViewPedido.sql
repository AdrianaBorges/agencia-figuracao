ALTER PROCEDURE [dbo].[p_CarregaViewPedido]
	@idpedido int = 0,
	@idprograma int = 0,
	@idextra int = 0
AS
	declare
		@select varchar(8000) = ''
		
BEGIN

	if @idprograma = 0
	begin
		Select 
			replicate('0',5 - Len(pe.idpedido)) + Rtrim(pe.idpedido) as idpedido,
			convert(varchar(10), pe.dtcadastro, 105) as dtcadastro, 
			replicate('0',4 - len(ep.idempresa)) + rtrim(ep.idempresa) + ' - ' + ep.descricao as empresa,
			replicate('0',7 - Len(pe.numpedido)) + Rtrim(pe.numpedido) as numpedido,
			Convert(varchar(10),pe.dtpedido, 105) as dtpedido,
			replicate('0', 4 - len(prog.idprograma)) + rtrim(prog.idprograma) + ' - ' + prog.descricao as programa,
			coalesce(pe.cena,'') as cena, 
			coalesce(pe.capitulo,'') as capitulo, 
			pe.hora, pe.horaini, pe.horafim,
			pe.observacao,
			pe.extra,
			
			coalesce(pe.qtdcomum,0) as qtdcomum,
			coalesce(pe.vlrcomum,0) as vlrcomum,
			
			coalesce(pe.qtdespecial,0) as qtdespecial,
			coalesce(pe.vlrespecial,0) as vlrespecial,

			coalesce(pe.qtdveiculo,0) as qtdveiculo,
			coalesce(pe.vlrveiculo,0) as vlrveiculo,

			coalesce(pe.qtdcomum + pe.qtdespecial + pe.qtdveiculo,0) as totfigurante,

			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido),0) as vlrpedido,
			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.status = 1 and pf.idpedido = pe.idpedido),0) as vlrpago,
			
			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido) -
			(select sum(vlrbruto) from pedidofigurante p where p.status = 1 and p.idpedido=pe.idpedido),0) as vlrpendente,
			
			--(select CAST(sum(vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido and pf.idtipo in (1,2)) + 
			--(select CAST(sum(vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido and pf.idtipo in (3)) as totprevisto

			(select coalesce(CAST(sum(pf.vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(pf.vlrbruto),0) 
			 from pedidofigurante pf 
			 where pf.idpedido=pe.idpedido and pf.idtipo in (1,2)) + 
			(select coalesce(CAST(sum(pf.vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(pf.vlrbruto),0) 
			 from pedidofigurante pf 
			 where pf.idpedido=pe.idpedido and pf.idtipo in (3)) as totprevisto

		From 
			Pedido pe
			inner join Programa prog on prog.idprograma = pe.idprograma
			inner join empresa ep on ep.idempresa = pe.idempresa
		where pe.idpedido = @idpedido --and pe.extra = @idextra

		Group by
			 pe.idpedido, pe.numpedido, pe.tipopedido, pe.dtpedido, prog.idprograma, prog.descricao, 
			 pe.observacao,pe.dtcadastro,ep.idempresa,ep.descricao,pe.cena, pe.capitulo, pe.hora, pe.horaini, pe.horafim,
			 pe.qtdfigurante,pe.tipocache,pe.vlrcache, pe.qtdcomum, pe.vlrcomum, pe.qtdespecial, pe.vlrespecial, pe.qtdveiculo, pe.vlrveiculo,pe.extra
		Order by pe.numpedido
	end
	else
	begin
		Select 
			replicate('0',5 - Len(pe.idpedido)) + Rtrim(pe.idpedido) as idpedido,
			convert(varchar(10), pe.dtcadastro, 105) as dtcadastro, 
			replicate('0',4 - len(ep.idempresa)) + rtrim(ep.idempresa) + ' - ' + ep.descricao as empresa,
			replicate('0',7 - Len(pe.numpedido)) + Rtrim(pe.numpedido) as numpedido,
			Convert(varchar(10),pe.dtpedido, 105) as dtpedido,
			replicate('0', 4 - len(prog.idprograma)) + rtrim(prog.idprograma) + ' - ' + prog.descricao as programa,
			coalesce(pe.cena,'') as cena, 
			coalesce(pe.capitulo,'') as capitulo, 
			pe.hora, pe.horaini, pe.horafim,
			pe.observacao,
			pe.extra,

			coalesce(pe.qtdcomum,0) as qtdcomum,
			coalesce(pe.vlrcomum,0) as vlrcomum,
			
			coalesce(pe.qtdespecial,0) as qtdespecial,
			coalesce(pe.vlrespecial,0) as vlrespecial,

			coalesce(pe.qtdveiculo,0) as qtdveiculo,
			coalesce(pe.vlrveiculo,0) as vlrveiculo,

			coalesce(pe.qtdcomum + pe.qtdespecial + pe.qtdveiculo,0) as totfigurante,

			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido),0) as vlrpedido,
			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.status = 1 and pf.idpedido = pe.idpedido),0) as vlrpago,
			
			coalesce((select sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido) -
			(select sum(vlrbruto) from pedidofigurante p where p.status = 1 and p.idpedido=pe.idpedido),0) as vlrpendente,
			
			--(select CAST(sum(vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido and pf.idtipo in (1,2)) + 
			--(select CAST(sum(vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(vlrbruto) from pedidofigurante pf where pf.idpedido=pe.idpedido and pf.idtipo in (3)) as totprevisto

			(select coalesce(CAST(sum(pf.vlrbruto) * 93.9 / 100 AS DECIMAL(18, 2)) + sum(pf.vlrbruto),0) 
			 from pedidofigurante pf 
			 where pf.idpedido=pe.idpedido and pf.idtipo in (1,2)) + 
			(select coalesce(CAST(sum(pf.vlrbruto) * 70 / 100 AS DECIMAL(18, 2)) + sum(pf.vlrbruto),0) 
			 from pedidofigurante pf 
			 where pf.idpedido=pe.idpedido and pf.idtipo in (3)) as totprevisto

		From 
			Pedido pe
			inner join Programa prog on prog.idprograma = pe.idprograma
			inner join empresa ep on ep.idempresa = pe.idempresa
		where pe.idprograma = @idprograma --and pe.extra = @idextra

		Group by
			 pe.idpedido, pe.numpedido, pe.tipopedido, pe.dtpedido, prog.idprograma, prog.descricao, 
			 pe.observacao,pe.dtcadastro,ep.idempresa,ep.descricao,pe.cena, pe.capitulo, pe.hora, pe.horaini, pe.horafim,
 			 pe.qtdfigurante,pe.tipocache,pe.vlrcache, pe.qtdcomum, pe.vlrcomum, pe.qtdespecial, pe.vlrespecial, pe.qtdveiculo, pe.vlrveiculo,pe.extra

		Order by pe.numpedido

	end

END