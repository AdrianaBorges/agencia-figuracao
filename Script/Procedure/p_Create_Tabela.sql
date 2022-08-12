Use [dbAgencia]
GO

/****** Object:  Table [dbo].[Bairro]    Script Date: 02/23/2014 11:55:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

	-- Bairro
	CREATE TABLE [dbo].[Bairro](
		[idbairro] [int] NOT NULL,
		[nmebairro] [nvarchar](50) NULL,
		[idcidade] [int] NULL,
		[cidade] [nvarchar](50) NULL,
		[estado] [nvarchar](50) NULL,
		[uf] [nchar](10) NULL,
		[teste] [int] NULL
	) ON [PRIMARY]



GO

--Alterando nome da coluna via dódigo
--exec sp_rename 'Figurante', 'Figurante_Old'