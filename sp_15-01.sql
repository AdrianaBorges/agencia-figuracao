--i8n5h5 senha 



SELECT TOP 10 * FROM Pedido



SELECT * FROM Agendamento

INSERT INTO Agendamento (dtregistro ,descricao ,dtpgto ,observacao )
VALUES
(GETDATE(),'DESCRIÇÃO DE AGENDAMENTO - TESTE',GETDATE(),'OBSERVAÇÃO DE AGENDAMENTO - TESTE')

ALTER TABLE AGENDAMENTO ADD CONTROLE VARCHAR(50)


SELECT REPLICATE('0', 6 - LEN(idagendamento)) + RTrim(idagendamento) as idagendamento, CONVERT(char, dtregistro, 105) AS dtregistro, descricao, CONVERT(char, dtpgto, 105) AS dtpgto, observacao FROM agendamento order by idagendamento desc

