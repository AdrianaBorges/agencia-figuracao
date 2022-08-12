USE [luzecorcasting]
GO

ALTER PROCEDURE [dbo].[p_geraRptReciboCache]
	@idpessoa int,
	@nrrb decimal,
	@status int

AS
BEGIN

	Begin Try

	--raiserror 30005 'ERRO RECUPERAR OS DADOS BANCARIOS.'
		select 
			replicate('0',5 - len(p.idpessoa)) + rtrim(p.idpessoa) as matricula,
			replicate('0',8 - len(fi.acesso)) + rtrim(fi.acesso) as acesso,
			p.nmepessoa as nmepessoa,
			convert(char,p.dtnascimento,105) as dtnascimento,
			dbo.FormataDoc(p.pis) as pis,
			dbo.FormataDoc(p.cpf) as cpf,
			dbo.FormataTelefone(p.celular) as celular,
			dbo.FormataTelefone(p.fixo) as fixo,
			dbo.FormataTelefone(p.contato) as contato,
		
			case 
				when db.idbanco is not null then db.titular  
				else ''
			end as titular,

			case 
				when db.idbanco is not null then replicate('0',3 - len(b.numero)) + rtrim(b.numero) + ' - ' + b.nmebanco  
				else ''
			end as banco,

			case 
				when db.idbanco is not null then db.agencia  
				else ''
			end as agencia,

			case 
				when db.idbanco is not null then 
												case db.tipo
													when 'P' then 'POUPANÇA'
													when 'C' then 'CORRENTE'
												end 
				else ''
			end as tipoconta,

			case 
				when db.idbanco is not null then db.numconta  
				else ''
			end as numconta,

			ped.vlrbruto as bruto, ped.vlrinss as inss, ped.vlrliquido as liquido,
	
			pd.numpedido + ' - ' + 
			CONVERT(char(10),pd.dtpedido,105) + ' - ' +
			REPLICATE('0',4 - LEN(pd.idprograma)) + rtrim(pd.idprograma) + ' - ' + 
			prog.descricao as pedido,
			ped.vlrbruto  as vlrcache,
			convert(char,ped.dtpagamento,105) as dtpagamento,
			ped.nrrb,
			f.descricao,
			tp.descricao as tipo,
			
			'Recebi de ' + f.descricao + ', a importância abaixo descrita referente aos serviços prestados como Figurante Autônomo, a quantia a qual, em caráter irrevogável, dou plena, raza e geral quitação, nada tendo a reclamar posteriormente. Retenção de 11% conforme a inscrição normativa número 87. Lei 10.666 de 08/05/2003.' as texto,
		p.email

		from pessoa p
		inner join Figurante fi on fi.idpessoa = p.idpessoa
		inner join PedidoFigurante ped on ped.idpessoa = p.idpessoa --and ped.idpedido = pf.idpedido
		inner join TipoFiguracao tp on tp.idtipo = ped.idtipo
		inner join Pedido pd on pd.idpedido = ped.idpedido 
		inner join Programa prog on prog.idprograma = pd.idprograma 
		inner join Firma f on f.idfirma = p.idfirma
		left join DadoBancario db on db.idpessoa = p.idpessoa 
		left join Banco b on b.idbanco = db.idbanco
		
		left join tmpPgto rp on rp.idregistro = ped.id and rp.idpessoa = p.idpessoa and rp.idpedido = pd.idpedido

		where p.idpessoa = @idpessoa 
			and ped.nrrb = @nrrb or rp.recibo = @nrrb
				and ped.status = @status

	End Try

	Begin Catch
	Select ERROR_MESSAGE() as ErrorMessage

	End Catch

END