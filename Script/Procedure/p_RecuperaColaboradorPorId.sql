Use[dbAgencia]
Go

create PROCEDURE [dbo].p_RecuperaColaboradorPorId
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
			p.complemento, -- 7
			p.cep, -- 8
			coalesce(p.idbairro,0) as idbairro,  -- 9
			p.fixo, -- 10
			p.celular, -- 11
			p.contato, -- 12
			p.email, --13
			p.cpf,  -- 14
			p.rg, -- 15
			p.expedicao, -- 16 
			p.pis, -- 17
			p.ctps, -- 18
			p.serie,  -- 19
			p.cartreservista, -- 20
			c.idcargo, -- 21
			convert(char,c.dtdesligamento,105) as dtdesligamento, -- 22
			c.clt, -- 23
			c.comissao, --24
			coalesce(b.idcidade, 0) as idcidade, -- 25
			coalesce(ci.idestado, 0) as idestado, -- 26
			p.idfirma -- 27

		from pessoa p
			inner join colaborador c on c.idpessoa = p.idpessoa
			left join bairro b on b.idbairro = p.idbairro
			left join cidade ci on ci.idcidade = b.idcidade

			where p.idpessoa = @idpessoa
				and p.idtipopessoa = 1
	End Try

	Begin Catch
		Select ERROR_MESSAGE() as ErrorMessage
	End Catch

END