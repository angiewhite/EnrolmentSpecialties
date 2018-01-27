CREATE TABLE [dbo].[GovernmentSpecialties] (
    [Id]            SMALLINT       IDENTITY (1, 1) NOT NULL,
    [FullName]      NVARCHAR (200) NOT NULL,
    [ShortName]     NVARCHAR (20)  NULL,
    [Qualification] NVARCHAR (100) NOT NULL,
    CONSTRAINT [primaryGovernmentSpecialtiesKey] PRIMARY KEY CLUSTERED ([Id] ASC)
);


