CREATE TABLE [dbo].[ClientContactInfo] (
    [ClientID]    INT            NOT NULL,
    [MailAddress] NVARCHAR (200) NULL,
    [CellPhoneNo] NVARCHAR (20)  NULL,
    [TelephoneNo] NVARCHAR (20)  NULL,
    CONSTRAINT [PK_ClientContactInfo] PRIMARY KEY CLUSTERED ([ClientID] ASC),
    CONSTRAINT [FK_ClientContactInfo_Clients] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户联系方式资料', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'ClientID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户收信地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'MailAddress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户移动电话号码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'CellPhoneNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户固定电话号码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientContactInfo', @level2type = N'COLUMN', @level2name = N'TelephoneNo';

