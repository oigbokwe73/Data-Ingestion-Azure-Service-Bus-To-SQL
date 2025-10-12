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

GO

ALTER TABLE [dbo].[College]
ADD CONSTRAINT PK_College PRIMARY KEY (id);



-- Step 1: Create a full-text catalog (optional but recommended)
CREATE FULLTEXT CATALOG MyFullTextCollegeCatalog
    AS DEFAULT;
GO

CREATE FULLTEXT INDEX ON [dbo].[College]
(
    Title LANGUAGE 1033  -- 1033 = English
)
KEY INDEX PK_College -- Replace with your actual PRIMARY KEY index name
ON MyFullTextCollegeCatalog;
GO

