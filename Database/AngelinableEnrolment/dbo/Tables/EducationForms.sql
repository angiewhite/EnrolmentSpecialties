CREATE TABLE [dbo].[EducationForms]
(
	[Id] TINYINT IDENTITY(1,1) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[ShortName] NVARCHAR(10) NOT NULL,

	CONSTRAINT primaryEducationFormsKey PRIMARY KEY ([Id])
)
