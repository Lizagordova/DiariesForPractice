CREATE TABLE [Student]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(100),
	[SecondName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[Phone] NVARCHAR(100)
);

CREATE TABLE [Institute]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100)
);

CREATE TABLE [Cafedra]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100),
	[InstituteId] INT REFERENCES [Institute]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Direction]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100),
	[CafedraId] INT REFERENCES [Cafedra]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Course]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100)
);

CREATE TABLE [Degree]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100)
);

CREATE TABLE [Course_Degree]
(
	[CourseId] INT REFERENCES [Course]([Id]) ON DELETE CASCADE,
	[DegreeId] INT REFERENCES [Degree]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Group]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100),
	[DirectionId] INT REFERENCES [Direction]([Id]) ON DELETE CASCADE,
	[CourseId] INT REFERENCES [Course]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Student_Group]
(
	[StudentId] INT REFERENCES [Student]([Id]) ON DELETE CASCADE,
	[GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE
);

CREATE TABLE [GoogleDetails]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE,
	[SpreadSheetId] NVARCHAR(100),
	[SheetName] NVARCHAR(100),
	[FirstCell] NVARCHAR(100),
	[LastCell] NVARCHAR(100)
);

CREATE TABLE [Diary]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Path] NVARCHAR(MAX),
	[Generated] BIT,
	[Send] BIT,
	[StudentId] INT REFERENCES [Student]([Id]) ON DELETE CASCADE,
	[Comment] NVARCHAR(MAX)
);

CREATE TABLE [Organization]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX),
	[LegalAddress] NVARCHAR(MAX)
);

CREATE TABLE [Staff]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[OrganizationId] INT REFERENCES [Organization]([Id]) ON DELETE CASCADE,
	[FullName] NVARCHAR(MAX),
	[Job] NVARCHAR(100),
	[Email] NVARCHAR(MAX),
	[Phone] NVARCHAR(100)
);

CREATE TABLE [PracticeDetails]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StudentId] INT REFERENCES [Student]([Id]) ON DELETE CASCADE,
	[OrganizationId] INT REFERENCES [Organization]([Id]) ON DELETE CASCADE,
	[ReportingForm] INT,
	[ContractNumber] NVARCHAR(100),
	[ResponsibleForStudent] INT REFERENCES [Staff]([Id]) ON DELETE CASCADE,
	[SignsTheContract] INT REFERENCES [Staff]([Id]) ON DELETE CASCADE
);

CREATE TYPE [UDT_Student] AS TABLE
(
	[Id] INT,
	[FirstName] NVARCHAR(100),
	[SecondName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[Phone] NVARCHAR(100)
);

CREATE TYPE [UDT_Institute] AS TABLE
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100)
);

CREATE TYPE [UDT_Cafedra] AS TABLE
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100),
	[InstituteId] INT
);

CREATE TYPE [UDT_Direction] AS TABLE
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100),
	[CafedraId] INT
);

CREATE TYPE [UDT_Course] AS TABLE
(
	[Id] INT,
	[Name] NVARCHAR(100),
	[DegreeId] INT
);

CREATE TYPE [UDT_Degree] AS TABLE
(
	[Id] INT,
	[Name] NVARCHAR(100)
);

CREATE TYPE [UDT_Group] AS TABLE
(
	[Id] INT,
	[Name] NVARCHAR(100),
	[DirectionId] INT,
	[CourseId] INT
);

CREATE TYPE [UDT_Student_Group] AS TABLE
(
	[StudentId] INT,
	[GroupId] INT
);

CREATE TYPE [UDT_GoogleDetails] AS TABLE
(
	[Id] INT,
	[GroupId] INT,
	[SpreadSheetId] NVARCHAR(100),
	[SheetName] NVARCHAR(100),
	[FirstCell] NVARCHAR(100),
	[LastCell] NVARCHAR(100)
);

CREATE TYPE [UDT_Diary] AS TABLE
(
	[Id] INT,
	[StudentId] INT,
	[Path] NVARCHAR(MAX),
	[Generated] BIT,
	[Send] BIT,
	[Comment] NVARCHAR(MAX)
);

CREATE TYPE [UDT_Organization] AS TABLE
(
	[Id] INT,
	[Name] NVARCHAR(MAX),
	[LegalAddress] NVARCHAR(MAX)
);

CREATE TYPE [UDT_Staff] AS TABLE
(
	[Id] INT,
	[OrganizationId] INT,
	[FullName] NVARCHAR(MAX),
	[Job] NVARCHAR(100),
	[Email] NVARCHAR(MAX),
	[Phone] NVARCHAR(100)
);

CREATE TYPE [UDT_PracticeDetails] AS TABLE
(
	[Id] INT,
	[StudentId] INT,
	[OrganizationId] INT,
	[ReportingForm] INT,
	[ContractNumber] NVARCHAR(100),
	[ResponsibleForStudent] INT,
	[SignsTheContract] INT
);

CREATE PROCEDURE [GoogleDetailsRepository_AddOrUpdateGoogleDetails]
	@googleDetails [UDT_GoogleDetails] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [GoogleDetails] AS [dest]
	USING @googleDetails AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[GroupId] = [src].[GroupId]
	WHEN NOT MATCHED THEN
		INSERT (
			[GroupId],
			[SpreadSheetId],
			[SheetName],
			[FirstCell],
			[LastCell]
		) VALUES (
			[src].[GroupId],
			[src].[SpreadSheetId],
			[src].[SheetName],
			[src].[FirstCell],
			[src].[LastCell]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[GroupId] = [src].[GroupId],
			[dest].[SpreadSheetId] = [src].[SpreadSheetId],
			[dest].[SheetName] = [src].[SheetName],
			[dest].[FirstCell] = [src].[FirstCell],
			[dest].[LastCell] = [src].[LastCell]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @googleDetailsId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @googleDetailsId;
END

CREATE PROCEDURE [GoogleDetailsRepository_GetGoogleDetails]
	@groupId INT = NULL
AS
BEGIN
	DECLARE @googleDetails [UDT_GoogleDetails];

	INSERT
	INTO @googleDetails (
		[Id],
		[GroupId],
		[SpreadSheetId],
		[SheetName],
		[FirstCell],
		[LastCell]
	)
	SELECT
		[Id],
		[GroupId],
		[SpreadSheetId],
		[SheetName],
		[FirstCell],
		[LastCell]
	FROM [GoogleDetails]
	WHERE (@groupId IS NULL OR [GroupId] = @groupId);

	SELECT * FROM @googleDetails;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateInstitute]
	@institute [UDT_Institute] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Institute] AS [dest]
	USING @institute AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name]
		) VALUES (
			[src].[Name]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @instituteId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @instituteId;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateCafedra]
	@cafedra [UDT_Cafedra] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Cafedra] AS [dest]
	USING @cafedra AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name],
			[InstituteId]
		) VALUES (
			[src].[Name],
			[src].[InstituteId]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name],
			[dest].[InstituteId] = [src].[InstituteId]

	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @cafedraId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @cafedraId;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateDirection]
	@direction [UDT_Direction] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Direction] AS [dest]
	USING @direction AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name],
			[CafedraId]
		) VALUES (
			[src].[Name],
			[src].[CafedraId]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name],
			[dest].[CafedraId] = [src].[CafedraId]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @directionId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @directionId;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateGroup]
	@group [UDT_Group] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Group] AS [dest]
	USING @group AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name],
			[DirectionId],
			[CourseId]
		) VALUES (
			[src].[Name],
			[src].[DirectionId],
			[src].[CourseId]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name],
			[dest].[DirectionId] = [src].[DirectionId],
			[dest].[CourseId] = [src].[CourseId]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @groupId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @groupId;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateCourse]
	@course [UDT_Course] READONLY,
	@degreeId INT
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Course] AS [dest]
	USING @course AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name]
		) VALUES (
			[src].[Name]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @courseId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	MERGE
	INTO [Course_Degree] AS [dest]
	USING @course AS [src]
	ON [dest].[CourseId] = [src].[Id]
		AND [dest].[DegreeId] = @degreeId
	WHEN NOT MATCHED THEN
		INSERT (
			[CourseId],
			[DegreeId]
		) VALUES (
			[src].[Id],
			@degreeId
		);

	SELECT @courseId;
END

CREATE PROCEDURE [InstituteDetailsRepository_AddOrUpdateDegree]
	@degree [UDT_Degree] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Degree] AS [dest]
	USING @degree AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name]
		) VALUES (
			[src].[Name]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @degreeId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @degreeId;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetInstitutes]
AS
BEGIN
	DECLARE @institutes [UDT_Institute];
	
	INSERT
	INTO @institutes (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Institute];

	SELECT * FROM @institutes;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetCafedras]
	@instituteId INT = NULL
AS
BEGIN
	DECLARE @cafedras [UDT_Cafedra];
	
	INSERT
	INTO @cafedras (
		[Id],
		[Name],
		[InstituteId]
	)
	SELECT
		[Id],
		[Name],
		[InstituteId]
	FROM [Cafedra]
	WHERE (@instituteId IS NULL OR [InstituteId] = @instituteId);

	SELECT * FROM @cafedras;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetDirections]
	@cafedraId INT = NULL
AS
BEGIN
	DECLARE @directions [UDT_Direction];
	
	INSERT
	INTO @directions (
		[Id],
		[Name],
		[CafedraId]
	)
	SELECT
		[Id],
		[Name],
		[CafedraId]
	FROM [Direction]
	WHERE (@cafedraId IS NULL OR [CafedraId] = @cafedraId);

	SELECT * FROM @directions;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetGroups]
	@directionId INT = NULL,
	@courseId INT = NULL
AS
BEGIN
	DECLARE @groups [UDT_Group];
	
	INSERT
	INTO @groups (
		[Id],
		[Name],
		[DirectionId],
		[CourseId]
	)
	SELECT
		[Id],
		[Name],
		[DirectionId],
		[CourseId]
	FROM [Group]
	WHERE (@directionId IS NULL OR [DirectionId] = @directionId)
		OR (@courseId IS NULL OR [CourseId] = @courseId);

	SELECT * FROM @groups;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetDegrees]
AS
BEGIN
	DECLARE @degrees [UDT_Degree];
	DECLARE @courses [UDT_Course];
	
	INSERT
	INTO @degrees (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Degree];

	INSERT
	INTO @courses (
		[Id],
		[Name],
		[DegreeId]
	)
	SELECT
		[c].[Id],
		[c].[Name],
		[cd].[DegreeId]
	FROM [Course] AS [c]
	JOIN [Course_Degree] AS [cd]
		ON [cd].[CourseId] = [c].[Id]
	WHERE [cd].[DegreeId] IN (SELECT [Id] FROM @degrees);
		
	SELECT * FROM @degrees;
	SELECT * FROM @courses;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetCourses]
	@degreeId INT = NULL
AS
BEGIN
	DECLARE @courses [UDT_Course];
	
	INSERT
	INTO @courses (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Course] AS [c]
	JOIN [Course_Degree] AS [cd]
		ON [cd].[CourseId] = [c].[Id]
	WHERE (@degreeId IS NULL OR [cd].[DegreeId] = @degreeId);

	SELECT * FROM @courses;
END

CREATE PROCEDURE [PracticeRepository_AddOrUpdatePracticeDetails]
	@practiceDetails [UDT_PracticeDetails] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [PracticeDetails] AS [dest]
	USING @practiceDetails AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[StudentId] = [src].[StudentId]
	WHEN NOT MATCHED THEN
		INSERT (
			[OrganizationId],
			[ReportingForm],
			[ContractNumber],
			[ResponsibleForStudent],
			[SignsTheContract],
			[StudentId]
		) VALUES (
			[src].[OrganizationId],
			[src].[ReportingForm],
			[src].[ContractNumber],
			[src].[ResponsibleForStudent],
			[src].[SignsTheContract],
			[src].[StudentId]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[OrganizationId] = [src].[OrganizationId],
			[dest].[ReportingForm] = [src].[ReportingForm],
			[dest].[ContractNumber] = [src].[ContractNumber],
			[dest].[ResponsibleForStudent] = [src].[ResponsibleForStudent],
			[dest].[SignsTheContract] = [src].[SignsTheContract],
			[dest].[StudentId] = [src].[StudentId]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @practiceDetailsId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @practiceDetailsId;
END

CREATE PROCEDURE [PracticeRepository_GetPracticeDetails]
	@groupId INT = NULL,
	@studentId INT = NULL
AS
BEGIN
	DECLARE @practiceDetails [UDT_PracticeDetails];

	IF @groupId IS NOT NULL
		BEGIN

			DECLARE @studentIds TABLE([Id] INT);
		
			INSERT
			INTO @studentIds (
				[Id]
			)
			SELECT
				[StudentId]
			FROM [Student_Group]
			WHERE [GroupId] = @groupId;

			INSERT
			INTO @practiceDetails (
				[Id],
				[StudentId],
				[OrganizationId],
				[ReportingForm],
				[ContractNumber],
				[ResponsibleForStudent],
				[SignsTheContract]
			)
			SELECT
				[Id],
				[StudentId],
				[OrganizationId],
				[ReportingForm],
				[ContractNumber],
				[ResponsibleForStudent],
				[SignsTheContract]
			FROM [PracticeDetails]
			WHERE [StudentId] IN (SELECT [Id] FROM @studentIds);

		END

	ELSE
		BEGIN

			INSERT
			INTO @practiceDetails (
				[Id],
				[StudentId],
				[OrganizationId],
				[ReportingForm],
				[ContractNumber],
				[ResponsibleForStudent],
				[SignsTheContract]
			)
			SELECT
				[Id],
				[StudentId],
				[OrganizationId],
				[ReportingForm],
				[ContractNumber],
				[ResponsibleForStudent],
				[SignsTheContract]
			FROM [PracticeDetails]
			WHERE (@studentId IS NULL OR [StudentId] = @studentId);
		END


	SELECT * FROM @practiceDetails;
END

CREATE PROCEDURE [StudentRepository_AddOrUpdateStudent]
	@student [UDT_Student] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Student] AS [dest]
	USING @student AS [src]
	ON [dest].[Id] = [src].[Id]
		OR ([dest].[FirstName] = [src].[FirstName]
			AND [dest].[SecondName] = [src].[SecondName]
			)
	WHEN NOT MATCHED THEN
		INSERT (
			[FirstName],
			[SecondName],
			[LastName],
			[Email],
			[Phone]		
		) VALUES (
			[src].[FirstName],
			[src].[SecondName],
			[src].[LastName],
			[src].[Email],
			[src].[Phone]	
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[FirstName] = [src].[FirstName],
			[dest].[SecondName] = [src].[SecondName],
			[dest].[LastName] = [src].[LastName],
			[dest].[Email] = [src].[Email],
			[dest].[Phone] = [src].[Phone]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @studentId INT = (SELECT TOP 1 [Id] FROM @mergedIds;

	SELECT @studentId;
END

CREATE PROCEDURE [StudentRepository_GetStudents]
AS
BEGIN
	DECLARE @students [UDT_Student];

	INSERT
	INTO @students (
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone]		
	) 
	SELECT
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone]	
	FROM [Student];

	SELECT * FROM @students;
END

CREATE PROCEDURE [DiariesRepository_AddOrUpdateDiary]
	@diary [UDT_Diary] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Diary] AS [dest]
	USING @diary AS [src]
	ON [dest].[Id] = [src].[Id] 
		OR [dest].[StudentId] = [src].[StudentId]
	WHEN NOT MATCHED THEN
		INSERT (
			[Path],
			[Generated],
			[Send],
			[StudentId],
			[Comment]
		) VALUES (
			[src].[Path],
			[src].[Generated],
			[src].[Send],
			[src].[StudentId],
			[src].[Comment]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Path] = [src].[Path],
			[dest].[Generated] = [src].[Generated],
			[dest].[Send] = [src].[Send],
			[dest].[StudentId] = [src].[StudentId],
			[dest].[Comment] = [src].[Comment]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @diaryId INT = (SELECT TOP 1 [Id] FROM [Diary]);

	SELECT @diaryId;
END

CREATE PROCEDURE [DiariesRepository_GetDiaries]
AS
BEGIN
	DECLARE @diaries [UDT_Diary];

	INSERT
	INTO @diaries (
		[Id],
		[Path],
		[Generated],
		[Send],
		[StudentId],
		[Comment]
	)
	SELECT
		[Id],
		[Path],
		[Generated],
		[Send],
		[StudentId],
		[Comment]
	FROM [Diary];

	SELECT * FROM @diaries;
END

CREATE PROCEDURE [StudentRepository_AttachStudentToGroup]
	@studentId INT,
	@groupId INT
AS
BEGIN
	IF((SELECT * FROM [Student_Group] WHERE [StudentId] = @studentId
		AND [GroupId] = @groupId) IS NULL)
		INSERT
		INTO [Student_Group] (
			[StudentId],
			[GroupId]
		) VALUES (
			@studentId,
			@groupId
		);
END

CREATE PROCEDURE [OrganizationRepository_AddOrUpdateOrganization]
	@organization [UDT_Organization] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Organization] AS [dest]
	USING @organization AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Name] = [src].[Name]
	WHEN NOT MATCHED THEN
		INSERT (
			[Name],
			[LegalAddress]
		) VALUES (
			[src].[Name],
			[src].[LegalAddress]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Name] = [src].[Name],
			[dest].[LegalAddress] = [src].[LegalAddress]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @organizationId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @organizationId;
END

CREATE PROCEDURE [OrganizationRepository_AddOrUpdateStaff]
	@staff [UDT_Staff] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Staff] AS [dest]
	USING @staff AS [src]
	ON [dest].[Id] = [src].[Id]
		OR (
			[dest].[OrganizationId] = [src].[Name]
			AND [dest].[FullName] = [src].[FullName]
		)
	WHEN NOT MATCHED THEN
		INSERT (
			[OrganizationId],
			[FullName],
			[Job],
			[Email],
			[Phone]
		) VALUES (
			[src].[OrganizationId],
			[src].[FullName],
			[src].[Job],
			[src].[Email],
			[src].[Phone]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[OrganizationId] = [src].[OrganizationId],
			[dest].[FullName] = [src].[FullName],
			[dest].[Job] = [src].[Job],
			[dest].[Email] = [src].[Email],
			[dest].[Phone] = [src].[Phone]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @staffId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @staffId;
END

CREATE PROCEDURE [OrganizationRepository_GetOrganizations]
AS
BEGIN
	DECLARE @organizations [UDT_Organization];

	INSERT
	INTO @organizations (
		[Id],
		[Name],
		[LegalAddress]
	)
	SELECT
		[Id],
		[Name],
		[LegalAddress]
	FROM [Organization];

	SELECT * FROM @organizations;
END