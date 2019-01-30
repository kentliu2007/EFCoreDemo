if not exists(select 1 from [dbo].[Employees] where [EmployeeCode] = 'GZ001')
   insert into [dbo].[Employees] ([EmployeeCode], [FirstName], [LastName], [JoinDate]) values ('GZ001', 'Hello', 'Guangzhou', '2019.1.1');
if not exists(select 1 from [dbo].[Employees] where [EmployeeCode] = 'SH007')
   insert into [dbo].[Employees] ([EmployeeCode], [FirstName], [LastName], [JoinDate]) values ('SH007', 'Hello', 'ShangHai', '2019.1.1');
