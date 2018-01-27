CREATE TABLE [dbo].[DirectEnrolmentUnits] (
    [Id]                    INT      IDENTITY (1, 1) NOT NULL,
    [EducationFormId]       TINYINT  NOT NULL,
    [EducationPaymentId]    TINYINT  NOT NULL,
    [EducationTermId]       TINYINT  NOT NULL,
    [EnrolmentGroupId]      SMALLINT NOT NULL,
    [ParentEnrolmentUnitId] INT      NULL,
    [TypeId]                TINYINT  NOT NULL,
    [GovernmentSpecialtyId] SMALLINT NOT NULL,
    [Year]                  SMALLINT NOT NULL,
    [EducationFee]          MONEY    NOT NULL,
    CONSTRAINT [primaryDirectEnrolmentUnitsKey] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEducationFormsKey] FOREIGN KEY ([EducationFormId]) REFERENCES [dbo].[EducationForms] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEducationPaymentsKey] FOREIGN KEY ([EducationPaymentId]) REFERENCES [dbo].[EducationPayments] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEducationTermsKey] FOREIGN KEY ([EducationTermId]) REFERENCES [dbo].[EducationTerms] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEnrolmentGroupsKey] FOREIGN KEY ([EnrolmentGroupId]) REFERENCES [dbo].[EnrolmentGroups] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEnrolmentUnitsKey] FOREIGN KEY ([ParentEnrolmentUnitId]) REFERENCES [dbo].[EnrolmentUnits] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToEnrolmentUnitsTypesKey] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[EnrolmentUnitTypes] ([Id]),
    CONSTRAINT [foreignDirectEnrolmentUnitsToGovernmentSpecialtiesKey] FOREIGN KEY ([GovernmentSpecialtyId]) REFERENCES [dbo].[GovernmentSpecialties] ([Id])
);


