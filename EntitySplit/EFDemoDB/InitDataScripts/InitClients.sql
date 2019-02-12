declare @clientACode nvarchar(max) = 'ClientA'

if not exists (select 1 from [dbo].[Clients] where [ClientCode] = @clientACode)
   insert into [dbo].[Clients] ([ClientCode], [ClientName]) values (@clientACode, 'Client A')

declare @clientID int = (select [ClientID] from [dbo].[Clients] where [ClientCode] = @clientACode)

if (@clientID is not null) and (@currencyID is not null)
   begin
   if not exists (select 1 from [dbo].[ClientContactInfo] where [ClientID] = @clientID)
      insert into [dbo].[ClientContactInfo] ([ClientID], [MailAddress], [CellPhoneNo], [TelephoneNo]) values (@clientID, 'mail address', '1234567890', '0987654321')
   end
