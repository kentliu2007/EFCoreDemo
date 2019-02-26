CREATE TABLE [dbo].[Clients] (
    [ClientID] INT            IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (450) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY NONCLUSTERED ([ClientID] ASC)
);


GO
CREATE UNIQUE CLUSTERED INDEX [idx_Clients_Code]
    ON [dbo].[Clients]([Code] ASC);

