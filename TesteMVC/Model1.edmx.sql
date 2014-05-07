
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2014 14:31:56
-- Generated from EDMX file: C:\Backp D\Uniderp\TADS N50\Projeto N50\TesteMVC\ProjetoN50\TesteMVC\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db970cfc58429d46d6915da31f00df5fc5];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_cliente_idcliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [fk_cliente_idcliente];
GO
IF OBJECT_ID(N'[dbo].[fk_cliente_Status_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [fk_cliente_Status_Cliente];
GO
IF OBJECT_ID(N'[dbo].[fk_contas_a_pagar_id_fornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contas_a_Pagar] DROP CONSTRAINT [fk_contas_a_pagar_id_fornecedor];
GO
IF OBJECT_ID(N'[dbo].[fk_contas_a_receber_id_cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contas_a_Receber] DROP CONSTRAINT [fk_contas_a_receber_id_cliente];
GO
IF OBJECT_ID(N'[dbo].[fk_endereco_id_fornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fornecedor] DROP CONSTRAINT [fk_endereco_id_fornecedor];
GO
IF OBJECT_ID(N'[dbo].[fk_fornecedor_Status_Fornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fornecedor] DROP CONSTRAINT [fk_fornecedor_Status_Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[fk_usuarios_idEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [fk_usuarios_idEndereco];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Contas_a_Pagar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contas_a_Pagar];
GO
IF OBJECT_ID(N'[dbo].[Contas_a_Receber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contas_a_Receber];
GO
IF OBJECT_ID(N'[dbo].[Endereco]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Endereco];
GO
IF OBJECT_ID(N'[dbo].[Fornecedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[Status_Usuario_Fornecedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status_Usuario_Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [id_cliente] int IDENTITY(1,1) NOT NULL,
    [RG] int  NULL,
    [CPF] int  NULL,
    [data_nascimento] datetime  NULL,
    [nome_cliente] varchar(50)  NULL,
    [id_endereco] int  NULL,
    [id_status_cliente] int  NULL,
    [email] varchar(50)  NULL,
    [telefone] decimal(18,0)  NULL
);
GO

-- Creating table 'Contas_a_Receber'
CREATE TABLE [dbo].[Contas_a_Receber] (
    [id_contas_a_receber] int IDENTITY(1,1) NOT NULL,
    [id_cliente] int  NULL,
    [descrição] varchar(50)  NULL,
    [valor_a_receber] float  NULL,
    [valor_recebido] float  NULL,
    [data_a_receber] datetime  NULL,
    [data_recebimento] datetime  NULL,
    [valor_juros_recebimento] float  NULL,
    [valor_desconto_recebimento] float  NULL
);
GO

-- Creating table 'Endereco'
CREATE TABLE [dbo].[Endereco] (
    [id] int IDENTITY(1,1) NOT NULL,
    [rua] nchar(20)  NULL,
    [numero] nchar(10)  NULL,
    [complemento] nchar(20)  NULL,
    [cep] int  NULL,
    [estado] nchar(20)  NULL,
    [cidade] nchar(20)  NULL,
    [pais] nchar(20)  NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [id_fornecedor] int IDENTITY(1,1) NOT NULL,
    [id_endereco] int  NULL,
    [id_status_fornecedor] int  NULL,
    [razao_social_fornecedor] varchar(50)  NULL,
    [email] varchar(50)  NULL,
    [telefone] decimal(18,0)  NULL,
    [cnpj] decimal(18,0)  NULL
);
GO

-- Creating table 'Status_Usuario_Fornecedor'
CREATE TABLE [dbo].[Status_Usuario_Fornecedor] (
    [id_status] int IDENTITY(1,1) NOT NULL,
    [status_Ativo_Inativo] int  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [id_usuario] int IDENTITY(1,1) NOT NULL,
    [nome_usuario] varchar(100)  NULL,
    [email_usuario] varchar(100)  NULL,
    [senha] varchar(12)  NULL,
    [confirmar_senha] varchar(12)  NULL,
    [id_endereco] int  NULL
);
GO

-- Creating table 'Contas_a_Pagar'
CREATE TABLE [dbo].[Contas_a_Pagar] (
    [id_contas_a_pagar] int IDENTITY(1,1) NOT NULL,
    [id_fornecedor] int  NULL,
    [descricao] varchar(50)  NULL,
    [valor_a_pagar] float  NULL,
    [valor_pago] float  NULL,
    [data_pagamento] datetime  NULL,
    [data_valor_pago] datetime  NULL,
    [valor_juros_pago] float  NULL,
    [valor_deconto_pago] float  NULL,
    [produto_contasapagar] varchar(50)  NULL,
    [quantidade] decimal(18,0)  NULL,
    [valor_unitario] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_cliente] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([id_cliente] ASC);
GO

-- Creating primary key on [id_contas_a_receber] in table 'Contas_a_Receber'
ALTER TABLE [dbo].[Contas_a_Receber]
ADD CONSTRAINT [PK_Contas_a_Receber]
    PRIMARY KEY CLUSTERED ([id_contas_a_receber] ASC);
GO

-- Creating primary key on [id] in table 'Endereco'
ALTER TABLE [dbo].[Endereco]
ADD CONSTRAINT [PK_Endereco]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_fornecedor] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([id_fornecedor] ASC);
GO

-- Creating primary key on [id_status] in table 'Status_Usuario_Fornecedor'
ALTER TABLE [dbo].[Status_Usuario_Fornecedor]
ADD CONSTRAINT [PK_Status_Usuario_Fornecedor]
    PRIMARY KEY CLUSTERED ([id_status] ASC);
GO

-- Creating primary key on [id_usuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([id_usuario] ASC);
GO

-- Creating primary key on [id_contas_a_pagar] in table 'Contas_a_Pagar'
ALTER TABLE [dbo].[Contas_a_Pagar]
ADD CONSTRAINT [PK_Contas_a_Pagar]
    PRIMARY KEY CLUSTERED ([id_contas_a_pagar] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_endereco] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [fk_cliente_idcliente]
    FOREIGN KEY ([id_endereco])
    REFERENCES [dbo].[Endereco]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_cliente_idcliente'
CREATE INDEX [IX_fk_cliente_idcliente]
ON [dbo].[Cliente]
    ([id_endereco]);
GO

-- Creating foreign key on [id_status_cliente] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [fk_cliente_Status_Cliente]
    FOREIGN KEY ([id_status_cliente])
    REFERENCES [dbo].[Status_Usuario_Fornecedor]
        ([id_status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_cliente_Status_Cliente'
CREATE INDEX [IX_fk_cliente_Status_Cliente]
ON [dbo].[Cliente]
    ([id_status_cliente]);
GO

-- Creating foreign key on [id_cliente] in table 'Contas_a_Receber'
ALTER TABLE [dbo].[Contas_a_Receber]
ADD CONSTRAINT [fk_contas_a_receber_id_cliente]
    FOREIGN KEY ([id_cliente])
    REFERENCES [dbo].[Cliente]
        ([id_cliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_contas_a_receber_id_cliente'
CREATE INDEX [IX_fk_contas_a_receber_id_cliente]
ON [dbo].[Contas_a_Receber]
    ([id_cliente]);
GO

-- Creating foreign key on [id_endereco] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [fk_endereco_id_fornecedor]
    FOREIGN KEY ([id_endereco])
    REFERENCES [dbo].[Endereco]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_endereco_id_fornecedor'
CREATE INDEX [IX_fk_endereco_id_fornecedor]
ON [dbo].[Fornecedor]
    ([id_endereco]);
GO

-- Creating foreign key on [id_endereco] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [fk_usuarios_idEndereco]
    FOREIGN KEY ([id_endereco])
    REFERENCES [dbo].[Endereco]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_usuarios_idEndereco'
CREATE INDEX [IX_fk_usuarios_idEndereco]
ON [dbo].[Usuarios]
    ([id_endereco]);
GO

-- Creating foreign key on [id_status_fornecedor] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [fk_fornecedor_Status_Fornecedor]
    FOREIGN KEY ([id_status_fornecedor])
    REFERENCES [dbo].[Status_Usuario_Fornecedor]
        ([id_status])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_fornecedor_Status_Fornecedor'
CREATE INDEX [IX_fk_fornecedor_Status_Fornecedor]
ON [dbo].[Fornecedor]
    ([id_status_fornecedor]);
GO

-- Creating foreign key on [id_fornecedor] in table 'Contas_a_Pagar'
ALTER TABLE [dbo].[Contas_a_Pagar]
ADD CONSTRAINT [fk_contas_a_pagar_id_fornecedor]
    FOREIGN KEY ([id_fornecedor])
    REFERENCES [dbo].[Fornecedor]
        ([id_fornecedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_contas_a_pagar_id_fornecedor'
CREATE INDEX [IX_fk_contas_a_pagar_id_fornecedor]
ON [dbo].[Contas_a_Pagar]
    ([id_fornecedor]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------