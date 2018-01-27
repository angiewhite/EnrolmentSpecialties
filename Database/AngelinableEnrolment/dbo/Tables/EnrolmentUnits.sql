CREATE TABLE [dbo].[EnrolmentUnits] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [FullName]            NVARCHAR (300) NOT NULL,
    [ShortName]           NVARCHAR (20)  NOT NULL,
    [EnrolmentUnitTypeId] TINYINT        NOT NULL,
    [ParentId]            INT            NULL,
    CONSTRAINT [primaryEnrolmentUnitsKey] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [foreignEnrolmentUnitsToEnrolmentUnitsKey] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[EnrolmentUnits] ([Id]),
    CONSTRAINT [foreignEnrolmentUnitsToEnrolmentUnitsTypesKey] FOREIGN KEY ([EnrolmentUnitTypeId]) REFERENCES [dbo].[EnrolmentUnitTypes] ([Id])
);


