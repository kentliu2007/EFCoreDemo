CREATE TABLE [dbo].[Teachers] (
    [TeacherID]   INT           NOT NULL,
    [StaffCode]   NVARCHAR (10) NOT NULL,
    [SalaryGrade] INT           NOT NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY NONCLUSTERED ([TeacherID] ASC),
    CONSTRAINT [FK_Teachers_Users] FOREIGN KEY ([TeacherID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [idx_Teachers_StaffCode] UNIQUE CLUSTERED ([StaffCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统自动生成用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Teachers', @level2type = N'COLUMN', @level2name = N'TeacherID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'教职工工号，教职工唯一标识值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Teachers', @level2type = N'COLUMN', @level2name = N'StaffCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'工资级别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Teachers', @level2type = N'COLUMN', @level2name = N'SalaryGrade';

