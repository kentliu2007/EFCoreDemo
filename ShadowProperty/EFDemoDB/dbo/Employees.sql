CREATE TABLE [dbo].[Employees] (
    [EmployeeID]   INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeCode] NVARCHAR (20) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [JoinDate]     SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY NONCLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [idx_Employees_EmpCode] UNIQUE CLUSTERED ([EmployeeCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统内部自生成ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'EmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'HR系统自编员工号，规则：城市拼音首字母+by城市自增长数字', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'EmployeeCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'FirstName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'姓', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'LastName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'最后一次入职的日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employees', @level2type = N'COLUMN', @level2name = N'JoinDate';

