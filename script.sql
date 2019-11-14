USE [master]
GO
/****** Object:  Database [CrudDB]    Script Date: 13/11/2019 22:43:01 ******/
CREATE DATABASE [CrudDB]
USE [CrudDB]
CREATE TABLE [dbo].[cargo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
 CONSTRAINT [PK_cargo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 13/11/2019 22:43:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[nome] [varchar](50) NOT NULL,
	[cargoId] [int] NOT NULL,
	[data] [date] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[celular] [varchar](50) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pessoa]  WITH CHECK ADD  CONSTRAINT [FK_Pessoa_cargo] FOREIGN KEY([cargoId])
REFERENCES [dbo].[cargo] ([id])
GO
ALTER TABLE [dbo].[Pessoa] CHECK CONSTRAINT [FK_Pessoa_cargo]

use CrudDB 
insert into cargo(nome)
values ('Administrador'), ('Funcionario')

