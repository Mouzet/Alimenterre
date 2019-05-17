
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/17/2019 14:03:05
-- Generated from EDMX file: C:\Users\mermo\Desktop\Alimenterre3\Alimenterre3\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AlimenterreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [Société] nvarchar(max)  NULL,
    [Adresse] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [TypeProduit] nvarchar(max)  NOT NULL,
    [NomProduit] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Competence_Id] int  NOT NULL,
    [Activite_Id] int  NOT NULL,
    [Localisation_Id] int  NOT NULL,
    [CategoryUser_Id] int  NOT NULL
);
GO

-- Creating table 'UserCategories'
CREATE TABLE [dbo].[UserCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomCatUser] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RecommandationsSet'
CREATE TABLE [dbo].[RecommandationsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Commentaire] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ProduitCategories'
CREATE TABLE [dbo].[ProduitCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomCategorie] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Produits'
CREATE TABLE [dbo].[Produits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomProduit] nvarchar(max)  NOT NULL,
    [ProduitCategory_Id] int  NOT NULL
);
GO

-- Creating table 'Localisations'
CREATE TABLE [dbo].[Localisations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomLocalite] nvarchar(max)  NOT NULL,
    [NPA] int  NOT NULL,
    [Canton_Id] int  NOT NULL
);
GO

-- Creating table 'Cantons'
CREATE TABLE [dbo].[Cantons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomCanton] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Activites'
CREATE TABLE [dbo].[Activites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomActivite] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Evenements'
CREATE TABLE [dbo].[Evenements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomEvenement] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Localisation_Id] int  NOT NULL
);
GO

-- Creating table 'Competences'
CREATE TABLE [dbo].[Competences] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomCompetence] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserProduit'
CREATE TABLE [dbo].[UserProduit] (
    [User_Id] int  NOT NULL,
    [Produit_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCategories'
ALTER TABLE [dbo].[UserCategories]
ADD CONSTRAINT [PK_UserCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecommandationsSet'
ALTER TABLE [dbo].[RecommandationsSet]
ADD CONSTRAINT [PK_RecommandationsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProduitCategories'
ALTER TABLE [dbo].[ProduitCategories]
ADD CONSTRAINT [PK_ProduitCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [PK_Produits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Localisations'
ALTER TABLE [dbo].[Localisations]
ADD CONSTRAINT [PK_Localisations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cantons'
ALTER TABLE [dbo].[Cantons]
ADD CONSTRAINT [PK_Cantons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activites'
ALTER TABLE [dbo].[Activites]
ADD CONSTRAINT [PK_Activites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Evenements'
ALTER TABLE [dbo].[Evenements]
ADD CONSTRAINT [PK_Evenements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competences'
ALTER TABLE [dbo].[Competences]
ADD CONSTRAINT [PK_Competences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Produit_Id] in table 'UserProduit'
ALTER TABLE [dbo].[UserProduit]
ADD CONSTRAINT [PK_UserProduit]
    PRIMARY KEY CLUSTERED ([User_Id], [Produit_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'RecommandationsSet'
ALTER TABLE [dbo].[RecommandationsSet]
ADD CONSTRAINT [FK_UserRecommandations]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecommandations'
CREATE INDEX [IX_FK_UserRecommandations]
ON [dbo].[RecommandationsSet]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserProduit'
ALTER TABLE [dbo].[UserProduit]
ADD CONSTRAINT [FK_UserProduit_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Produit_Id] in table 'UserProduit'
ALTER TABLE [dbo].[UserProduit]
ADD CONSTRAINT [FK_UserProduit_Produit]
    FOREIGN KEY ([Produit_Id])
    REFERENCES [dbo].[Produits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProduit_Produit'
CREATE INDEX [IX_FK_UserProduit_Produit]
ON [dbo].[UserProduit]
    ([Produit_Id]);
GO

-- Creating foreign key on [ProduitCategory_Id] in table 'Produits'
ALTER TABLE [dbo].[Produits]
ADD CONSTRAINT [FK_ProduitProduitCategory]
    FOREIGN KEY ([ProduitCategory_Id])
    REFERENCES [dbo].[ProduitCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduitProduitCategory'
CREATE INDEX [IX_FK_ProduitProduitCategory]
ON [dbo].[Produits]
    ([ProduitCategory_Id]);
GO

-- Creating foreign key on [Competence_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_CompetenceUser]
    FOREIGN KEY ([Competence_Id])
    REFERENCES [dbo].[Competences]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenceUser'
CREATE INDEX [IX_FK_CompetenceUser]
ON [dbo].[Users]
    ([Competence_Id]);
GO

-- Creating foreign key on [Activite_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_ActiviteUser]
    FOREIGN KEY ([Activite_Id])
    REFERENCES [dbo].[Activites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActiviteUser'
CREATE INDEX [IX_FK_ActiviteUser]
ON [dbo].[Users]
    ([Activite_Id]);
GO

-- Creating foreign key on [Localisation_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserLocalisation]
    FOREIGN KEY ([Localisation_Id])
    REFERENCES [dbo].[Localisations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLocalisation'
CREATE INDEX [IX_FK_UserLocalisation]
ON [dbo].[Users]
    ([Localisation_Id]);
GO

-- Creating foreign key on [Canton_Id] in table 'Localisations'
ALTER TABLE [dbo].[Localisations]
ADD CONSTRAINT [FK_LocalisationCanton]
    FOREIGN KEY ([Canton_Id])
    REFERENCES [dbo].[Cantons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalisationCanton'
CREATE INDEX [IX_FK_LocalisationCanton]
ON [dbo].[Localisations]
    ([Canton_Id]);
GO

-- Creating foreign key on [Localisation_Id] in table 'Evenements'
ALTER TABLE [dbo].[Evenements]
ADD CONSTRAINT [FK_EvenementLocalisation]
    FOREIGN KEY ([Localisation_Id])
    REFERENCES [dbo].[Localisations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvenementLocalisation'
CREATE INDEX [IX_FK_EvenementLocalisation]
ON [dbo].[Evenements]
    ([Localisation_Id]);
GO

-- Creating foreign key on [CategoryUser_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_CategoryUserUser]
    FOREIGN KEY ([CategoryUser_Id])
    REFERENCES [dbo].[UserCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryUserUser'
CREATE INDEX [IX_FK_CategoryUserUser]
ON [dbo].[Users]
    ([CategoryUser_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------