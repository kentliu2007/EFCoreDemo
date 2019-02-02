if not exists (select 1 from [dbo].[Users] where [LoginName] = 'User1')
   insert into [dbo].[Users] ([LoginName], [Password]) values ('User1', '')
