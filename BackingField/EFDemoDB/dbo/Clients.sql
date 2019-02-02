CREATE TABLE [dbo].[Clients] (
    [ClientID]   INT           IDENTITY (1, 1) NOT NULL,
    [ClientCode] NVARCHAR (10) NOT NULL,
    [ClientName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY NONCLUSTERED ([ClientID] ASC),
    CONSTRAINT [idx_Clients_ClientCode] UNIQUE CLUSTERED ([ClientCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户资料', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Clients';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Clients', @level2type = N'COLUMN', @level2name = N'ClientID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户代码，唯一标识值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Clients', @level2type = N'COLUMN', @level2name = N'ClientCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Clients', @level2type = N'COLUMN', @level2name = N'ClientName';

