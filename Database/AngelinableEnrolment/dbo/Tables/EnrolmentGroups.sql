CREATE TABLE [dbo].[EnrolmentGroups] (
    [Id]                   SMALLINT       IDENTITY (1, 1) NOT NULL,
    [FullName]             NVARCHAR (100) NOT NULL,
    [ShortName]            NVARCHAR (20)  NULL,
    [AvailableSpecialties] INT            NULL,
    CONSTRAINT [primaryEnrolmentGroupsKey] PRIMARY KEY CLUSTERED ([Id] ASC)
);


