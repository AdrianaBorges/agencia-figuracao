Use[dbAgencia]
Go

create PROCEDURE [dbo].p_RecuperaFigurantePorId
	@idpessoa int = 0
AS
		
BEGIN
	
	Begin Try
		
		select 
			p.idpessoa, -- 0
			p.nmepessoa, -- 1
			p.dtnascimento, -- 2
			p.sexo, -- 3
			p.dtcadastro, -- 4
			p.status, -- 5
			p.logradouro, -- 6
			p.complemento, --7
			p.cep, -- 8
			coalesce(p.idbairro,0) as idbairro, -- 9
			p.fixo, -- 10
			p.celular, -- 11
			p.contato, -- 12
			p.email, -- 13
			p.cpf, --14
			p.rg, -- 15
			p.expedicao, -- 16
			p.pis, -- 17
			coalesce(b.idcidade, 0) as idcidade, -- 18
			coalesce(ci.idestado, 0) as idestado, -- 19
			f.acesso, -- 20
			f.pasta, -- 21
			case f.Nacionalidade 
				when 1 then 'BRASILEIRO(A)' 
				when 2 then 'ESTRANGEIRO(A)' 
			end as nacionalidade, -- 22
			case f.estadocivil
				when 1 then 'SOLTEIRO(A)'
				when 2 then 'CASADO(A)'
				when 3 then 'SEPARADO(A)'
				when 4 then 'DIVORCIADO(A)'
				when 5 then 'VIUVO(A)'
			end as estadocivil, -- 23
			f.nmeartistico, -- 24
			f.mae, -- 25
			f.pai, -- 26
			f.profissao, -- 27
			f.registroator, -- 28
			f.figurante, -- 29
			f.ator, -- 30
			f.modelo, -- 31
			f.altura, -- 32
			f.idadeap, -- 33
			f.peso, -- 34
			f.tipoetnico, -- 35
			f.manequim, -- 36
			f.calcado, -- 37
			f.busto, -- 38
			f.quadril, -- 39
			f.cintura, -- 40
			f.celebridade, -- 41
			f.corolhos, -- 42
			f.cabelo, -- 43
			f.corcabelo, -- 44
			f.tipocabelo, -- 45
			f.corpele, -- 46
			f.apdental, -- 47
			p.idfirma -- 48

		from pessoa p
			inner join Figurante f on f.idpessoa = p.idpessoa
			left join bairro b on b.idbairro = p.idbairro
			left join cidade ci on ci.idcidade = b.idcidade

			where p.idpessoa = @idpessoa
				and p.idtipopessoa = 2
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END