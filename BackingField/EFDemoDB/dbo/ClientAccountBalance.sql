CREATE TABLE [dbo].[ClientAccountBalance] (
    [ClientID]   INT NOT NULL,
    [CurrencyID] INT NOT NULL,
    [Amount]     INT CONSTRAINT [DF_ClientAccountBalance_Amount] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_ClientAccountBalance] PRIMARY KEY CLUSTERED ([ClientID] ASC),
    CONSTRAINT [FK_ClientAccountBalance_Clients] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ClientID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_ClientAccountBalance_Currencies] FOREIGN KEY ([CurrencyID]) REFERENCES [dbo].[Currencies] ([CurrencyID]) ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户核算账户资料', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientAccountBalance';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID(客户)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientAccountBalance', @level2type = N'COLUMN', @level2name = N'ClientID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID(货币品种)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientAccountBalance', @level2type = N'COLUMN', @level2name = N'CurrencyID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'客户核算账户金额', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClientAccountBalance', @level2type = N'COLUMN', @level2name = N'Amount';

