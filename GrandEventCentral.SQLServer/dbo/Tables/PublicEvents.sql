CREATE TABLE [dbo].[PublicEvents] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [CreatorId]   NVARCHAR (450)   NULL,
    [Title]       NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [HostName]    NVARCHAR (MAX)   NULL,
    [EventUrlFb]  NVARCHAR (MAX)   NULL,
    [Date]        DATETIME2 (7)    NULL,
    [CreatedAt]   DATETIME2 (7)    NULL,
    [FullAddress] NVARCHAR (MAX)   NULL,
    [Latitude]    REAL             NULL,
    [Longitude]   REAL             NULL,
    CONSTRAINT [PK_PublicEvents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PublicEvents_AspNetUsers_CreatorId] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PublicEvents_CreatorId]
    ON [dbo].[PublicEvents]([CreatorId] ASC);

