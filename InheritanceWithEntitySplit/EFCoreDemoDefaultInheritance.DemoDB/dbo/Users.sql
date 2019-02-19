CREATE TABLE [dbo].[Users] (
    [UserID]        INT            IDENTITY (1, 1) NOT NULL,
    [LoginName]     NVARCHAR (MAX) NULL,
    [FirstName]     NVARCHAR (MAX) NULL,
    [LastName]      NVARCHAR (MAX) NULL,
    [Password]      NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (MAX) NOT NULL,
    [StudentCode]   NVARCHAR (MAX) NULL,
    [GradeLevel]    INT            NULL,
    [StaffCode]     NVARCHAR (MAX) NULL,
    [SalaryGrade]   INT            NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

