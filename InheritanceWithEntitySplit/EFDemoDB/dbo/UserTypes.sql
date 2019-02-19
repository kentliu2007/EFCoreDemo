CREATE TABLE [dbo].[UserTypes] (
    [UserTypeID]   INT        NOT NULL,
    [UserTypeDesc] NCHAR (10) NULL,
    CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED ([UserTypeID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户类别枚举ID：0 教师；1 学生', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTypes', @level2type = N'COLUMN', @level2name = N'UserTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户类别枚举解释', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserTypes', @level2type = N'COLUMN', @level2name = N'UserTypeDesc';

