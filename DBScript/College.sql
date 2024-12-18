CREATE TABLE [dbo].[College] (
    [Company]   NVARCHAR (MAX) NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [City]       NVARCHAR (MAX) NULL,
    [State]    NVARCHAR (MAX) NULL,
    [Zip]       NVARCHAR (MAX) NULL,
    [County]      NVARCHAR (MAX) NULL,
    [Phone]        NVARCHAR (MAX) NULL,
    [Website]       NVARCHAR (MAX) NULL,
    [Contact]  NVARCHAR (MAX) NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [DirectPhone]     NVARCHAR (MAX) NULL,
    [Email] NVARCHAR (MAX) NULL,
    [Sales]     NVARCHAR (MAX) NULL,
    [Employees] NVARCHAR (MAX) NULL,
    [SICCode]    NVARCHAR (MAX) NULL,
    [Industry]   NVARCHAR (MAX) NULL,
    [CreatedDate] datetime default CURRENT_TIMESTAMP,
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
);

