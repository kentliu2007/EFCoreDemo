CREATE TABLE [dbo].[Users] (
    [UserID]        INT            IDENTITY (1, 1) NOT NULL,
    [LoginName]     NVARCHAR (50)  NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [Password]      NVARCHAR (MAX) NOT NULL,
    [Discriminator] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED ([UserID] ASC),
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
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'EFCore支持类继承需要字段', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Discriminator';

