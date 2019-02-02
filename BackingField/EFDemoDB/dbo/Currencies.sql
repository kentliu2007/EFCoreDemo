CREATE TABLE [dbo].[Currencies] (
    [CurrencyID]    INT            IDENTITY (1, 1) NOT NULL,
    [CurrencyCode]  NVARCHAR (6)   NOT NULL,
    [CurrencyName]  NVARCHAR (100) NOT NULL,
    [DecimalPlaces] INT            CONSTRAINT [DF_Currencies_DecimalPlaces] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Currencies] PRIMARY KEY NONCLUSTERED ([CurrencyID] ASC),
    CONSTRAINT [idx_Currencies_CurrencyCode] UNIQUE CLUSTERED ([CurrencyCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'货币种类', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currencies';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currencies', @level2type = N'COLUMN', @level2name = N'CurrencyID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'货币品种代码；唯一标示值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currencies', @level2type = N'COLUMN', @level2name = N'CurrencyCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'货币名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currencies', @level2type = N'COLUMN', @level2name = N'CurrencyName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'小数点后位数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currencies', @level2type = N'COLUMN', @level2name = N'DecimalPlaces';

