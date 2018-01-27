CREATE TABLE [dbo].[EducationTerms]
(
	[Id] TINYINT IDENTITY(1,1) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[ShortName] NVARCHAR(10) NOT NULL,

	CONSTRAINT primaryEducationTermsKey PRIMARY KEY ([Id])
)
