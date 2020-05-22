CREATE TABLE [dbo].[People] (
    [Id]            UNIQUEIDENTIFIER NOT NULL,
    [CreatorId]     NVARCHAR (450)   NULL,
    [FirstName]     NVARCHAR (10)    NOT NULL,
    [LastName]      NVARCHAR (15)    NOT NULL,
    [Name]          NVARCHAR (MAX)   NULL,
    [Email]         NVARCHAR (MAX)   NOT NULL,
    [Gender]        INT              NULL,
    [StartDate]     DATETIME2 (7)    NOT NULL,
    [PreferredTeam] NVARCHAR (MAX)   NOT NULL,
    [Biography]     NVARCHAR (MAX)   NULL,
    [Picture]       NVARCHAR (MAX)   NULL,
    [DateOfBirth]   DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_People_AspNetUsers_CreatorId] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_People_CreatorId]
    ON [dbo].[People]([CreatorId] ASC);

