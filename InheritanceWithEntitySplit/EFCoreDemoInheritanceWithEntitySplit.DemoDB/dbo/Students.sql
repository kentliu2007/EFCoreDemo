CREATE TABLE [dbo].[Students] (
    [StudentID]   INT           NOT NULL,
    [StudentCode] NVARCHAR (10) NOT NULL,
    [GradeLevel]  INT           NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY NONCLUSTERED ([StudentID] ASC),
    CONSTRAINT [FK_Students_Users] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [idx_Students_StudentCode] UNIQUE CLUSTERED ([StudentCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统自动生成用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Students', @level2type = N'COLUMN', @level2name = N'StudentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'学生学号，学生唯一标识值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Students', @level2type = N'COLUMN', @level2name = N'StudentCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'年级', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Students', @level2type = N'COLUMN', @level2name = N'GradeLevel';

