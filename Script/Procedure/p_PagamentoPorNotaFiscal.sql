


select * from notafiscal where numnota = 19
select * from cartafatura where idnota = 53

select sum(pf.vlrbruto) as bruto, sum(pf.vlrinss) as inss, sum(pf.vlrliquido) as liquido
from pedidofigurante pf
inner join pedido p on p.idpedido = pf.idpedido
inner join cartafatura cf on cf.idcartafatura = p.idcartafatura
inner join notafiscal nf on nf.idnota = cf.idnota
where nf.idnota = 53
and pf.status = 0


