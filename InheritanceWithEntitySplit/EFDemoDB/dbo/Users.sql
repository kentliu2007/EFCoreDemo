CREATE TABLE [dbo].[Users] (
    [UserID]     INT            IDENTITY (1, 1) NOT NULL,
    [LoginName]  NVARCHAR (50)  NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [Password]   NVARCHAR (MAX) NOT NULL,
    [UserTypeID] INT            NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserTypes] ([UserTypeID]),
    CONSTRAINT [idx_Users_LoginName] UNIQUE CLUSTERED ([LoginName] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'系统自动生成用户ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'登录账户，系统用户唯一标识值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'LoginName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'FirstName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'姓', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'LastName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户类别：0 教师；1 学生', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'UserTypeID';

