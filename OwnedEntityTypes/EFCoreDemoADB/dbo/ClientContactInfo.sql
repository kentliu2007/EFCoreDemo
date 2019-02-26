CREATE TABLE [dbo].[ClientContactInfo] (
    [ClientID]    INT            NOT NULL,
    [CellPhoneNo] NVARCHAR (MAX) NULL,
    [TelePhoneNo] NVARCHAR (MAX) NULL,
    [email]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ClientContactInfo] PRIMARY KEY CLUSTERED ([ClientID] ASC),
    CONSTRAINT [FK_ClientContactInfo_Clients_ClientID] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]) ON DELETE CASCADE
);

