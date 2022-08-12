
--select idpessoa, certnascimento, livro, responsavel, cpf_resp from figurante 


update figurante set certnascimento = '49220', livro = '137', responsavel = 'PATRICIA CARVALHO DA CUNHA', cpf_resp = '018.491.427-26' where idpessoa = 36492


select * from pessoa where idpessoa in (19477,20116)