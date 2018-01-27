CREATE TABLE [dbo].[EnrolmentUnitTypes] (
    [Id]       TINYINT       IDENTITY (1, 1) NOT NULL,
    [FullName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [primaryEnrolmentUnitsTypesKey] PRIMARY KEY CLUSTERED ([Id] ASC)
);

