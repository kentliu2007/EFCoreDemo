CREATE TABLE [dbo].[ClientContactInfo] (
    [ClientID]    INT            NOT NULL,
    [CellPhoneNo] NVARCHAR (100) NULL,
    [TelePhoneNo] NVARCHAR (100) NULL,
    [email]       NVARCHAR (100) NULL,
    CONSTRAINT [PK_ClientContactInfo] PRIMARY KEY CLUSTERED ([ClientID] ASC),
    CONSTRAINT [FK_ClientContactInfo_Clients] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Clients.ClientID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'ClientID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'手机号码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'CellPhoneNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'固话号码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'TelePhoneNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'电子邮件地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'email';

