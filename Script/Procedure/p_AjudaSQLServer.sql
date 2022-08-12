-- Ajuda com SQL Server


-- Alterando nome da tabela
exec sp_rename 'Produtos', 'Artigos'


-- Alterando nome da coluna
exec sp_rename 'Artigos.NomeProduto', 'Nome', 'column'

