--Procedures ajustadas:
--Envio de e-mail para figurante: p_RecuperaDadoBancarioPorId
--Impressão de recibo: p_geraRptReciboCache
--Registro de Pedido de Gravação: p_RegistraPedido


	raiserror 30005 'ERRO RECUPERAR OS DADOS BANCARIOS.'


select distinct cpf
from pessoa where idtipopessoa <> 1 and cpf not in ('05220527703','08060799754','16671993742','13290389758','78304210720','02688688758', '09081845730','25930984816','03441980735',
'22430570858','11066723729','03029377733','01090606010', '11989380727','43981399749','06867127738','03829040792','07463966780','05690004758','16170630701','66749263704','66749263704',
'07980355792','08160142722','72070315487', '03022863730','09062454780', '28939310730','72250844704','59352388704','08778111722','00028032756','01152601709','05315848795',
'12864852748','00028254309','07898848799','03804173403','67573835787','06942624713','12052138722','01369818793','00265393655','89521196734','03206911796','02620768705',
'11258966719','31579677894','01274042798','00314239731','77409493704','09993202703','02047623758','00935622764','89292230794','05407018748','17140545782','10635069725'
,'07818026797','80171079787','09641189219','11139457705','94100160704','12512336786','16673870737','05574235706','00217792790','05985460738','15251137710',
'04460141760','77133331772')
group by cpf having COUNT(cpf)>1


SELECT * FROM PESSOA WHERE IDPESSOA IN (31479,34534)
SELECT * FROM DADOBANCARIO WHERE IDPESSOA IN (31479,34534)
SELECT * FROM PedidoFigurante WHERE IDPESSOA IN (31479,34534)
 
update pessoa set CPF = '00657652733' where idpessoa = 31479

select * from pessoa where cpf = '13096267740' order by idpessoa 

select * from PedidoFigurante where idpessoa in (34044,34046) order by id desc

-- certo, errado
exec p_UnificaFigurante 34044,34046


select * from pessoa where nmepessoa like '%MARIA DAS DORES%'


update pessoa set nmepessoa = 'CLEIA MARIANA SOUZA DE OLIVEIRA' where idpessoa = 15541
update pessoa set dtnascimento = '1984-07-20' where idpessoa = 33388
update pessoa set pis = '12660017583' where idpessoa = 33137




select * from pessoa where nmepessoa like '%ERONICE%'

SELECT pf.idpessoa, pf.dtpagamento, pf.nrrb, sum(pf.vlrbruto) as bruto, sum(pf.vlrinss) as inss, sum(pf.vlrliquido) as liquido
FROM PEDIDOFIGURANTE pf
INNER JOIN TipoFiguracao TP ON TP.idtipo = PF.idtipo AND TP.descinss = 1
WHERE pf.IDPESSOA = 8661 AND pf.STATUS = 1
group by pf.idpessoa, pf.nrrb, pf.dtpagamento
order by pf.dtpagamento


select * from tmpRecGrupo
