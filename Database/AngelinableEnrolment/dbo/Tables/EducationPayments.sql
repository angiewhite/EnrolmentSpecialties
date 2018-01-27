CREATE TABLE [dbo].[EducationPayments] (
    [Id]              TINYINT       IDENTITY (1, 1) NOT NULL,
    [FullName]        NVARCHAR (50) NOT NULL,
    [ShortName]       NVARCHAR (10) NOT NULL,
    [GovernmentShare] TINYINT       NOT NULL,
    CONSTRAINT [primaryEducationPaymentsKey] PRIMARY KEY CLUSTERED ([Id] ASC)
);


