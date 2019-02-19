/* init [UserTypes] demo data */
if not exists(select 1 from [dbo].[UserTypes] where [UserTypeID] = 0)
   insert into [dbo].[UserTypes] ([UserTypeID], [UserTypeDesc]) values (0, 'Teacher')
if not exists(select 1 from [dbo].[UserTypes] where [UserTypeID] = 1)
   insert into [dbo].[UserTypes] ([UserTypeID], [UserTypeDesc]) values (1, 'Student')

/* init [Users] demo data */
declare @userid INT

/* teacherA */
if not exists(select 1 from [dbo].[Users] where [LoginName] = 'teacherA')
   insert into [dbo].[Users] ([LoginName], [FirstName], [LastName], [Password], [UserTypeID]) values ('teacherA', 'teacher', 'A', 'abc', 0)
set @userid = (select [UserID] from [dbo].[Users] where [LoginName] = 'teacherA')
if not exists(select 1 from [dbo].[Teachers] where [TeacherID] = @userid)
   insert into [dbo].[Teachers] ([TeacherID], [SalaryGrade], [StaffCode]) values (@userid, 1, 'TEA001')

/* teacherB */
if not exists(select 1 from [dbo].[Users] where [LoginName] = 'teacherB')
   insert into [dbo].[Users] ([LoginName], [FirstName], [LastName], [Password], [UserTypeID]) values ('teacherB', 'teacher', 'B', '123', 0)
set @userid = (select [UserID] from [dbo].[Users] where [LoginName] = 'teacherB')
if not exists(select 1 from [dbo].[Teachers] where [TeacherID] = @userid)
   insert into [dbo].[Teachers] ([TeacherID], [SalaryGrade], [StaffCode]) values (@userid, 1, 'TEA002')


/* studentA */
if not exists(select 1 from [dbo].[Users] where [LoginName] = 'studentA')
   insert into [dbo].[Users] ([LoginName], [FirstName], [LastName], [Password], [UserTypeID]) values ('studentA', 'student', 'A', 'abc', 1)
set @userid = (select [UserID] from [dbo].[Users] where [LoginName] = 'studentA')
if not exists(select 1 from [dbo].[Students] where [StudentID] = @userid)
   insert into [dbo].[Students] ([StudentID], [StudentCode], [GradeLevel]) values (@userid, 'STU001', 1)

/* studentB */
if not exists(select 1 from [dbo].[Users] where [LoginName] = 'studentB')
   insert into [dbo].[Users] ([LoginName], [FirstName], [LastName], [Password], [UserTypeID]) values ('studentB', 'student', 'B', '123', 1)
set @userid = (select [UserID] from [dbo].[Users] where [LoginName] = 'studentB')
if not exists(select 1 from [dbo].[Students] where [StudentID] = @userid)
   insert into [dbo].[Students] ([StudentID], [StudentCode], [GradeLevel]) values (@userid, 'STU002', 1)
