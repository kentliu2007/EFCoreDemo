declare @clientACode nvarchar(max) = 'ClientA'
declare @currentyACode nvarchar(max) = 'CurrA'

if not exists (select 1 from [dbo].[Currencies] where [CurrencyCode] = @currentyACode)
   insert into [dbo].[Currencies] ([CurrencyCode], [CurrencyName], [DecimalPlaces]) values (@currentyACode, 'Currency A', 5)

if not exists (select 1 from [dbo].[Clients] where [ClientCode] = @clientACode)
   insert into [dbo].[Clients] ([ClientCode], [ClientName]) values (@clientACode, 'Client A')

declare @clientID int = (select [ClientID] from [dbo].[Clients] where [ClientCode] = @clientACode)
declare @currencyID int = (select [CurrencyID] from [dbo].[Currencies] where [CurrencyCode] = @currentyACode)

if (@clientID is not null) and (@currencyID is not null)
   begin
   if not exists (select 1 from [dbo].[ClientAccountBalance] where [ClientID] = @clientID)
      insert into [dbo].[ClientAccountBalance] ([ClientID], [CurrencyID], [Amount]) values (@clientID, @currencyID, '123456789')
   end
