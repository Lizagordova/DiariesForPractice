CREATE TABLE [User]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(100),
	[SecondName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[Phone] NVARCHAR(100),
	[EmailConfirmed] BIT
);

CREATE TABLE [User_Role]
(
	[UserId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[Role] INTEGER
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
	[InstituteId] INT REFERENCES [Institute]([Id]) ON DELETE CASCADE,
	[CafedraId] INT REFERENCES [Cafedra]([Id]) ON DELETE CASCADE,
	[DirectionId] INT REFERENCES [Direction]([Id]) ON DELETE CASCADE,
	[CourseId] INT REFERENCES [Course]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Diary]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[Path] NVARCHAR(MAX),
	[Generated] BIT,
	[Send] BIT,
	[Approved] BIT,
	[Perceived] BIT,
	[GeneratedDate] DATETIME2,
	[SendDate] DATETIME2,
	[PerceivedDate] DATETIME2,
	[Completion] INT,
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
	[StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[OrganizationId] INT REFERENCES [Organization]([Id]) ON DELETE CASCADE,
	[ReportingForm] INT,
	[ContractNumber] NVARCHAR(100),
	[ResponsibleForStudent] INT REFERENCES [Staff]([Id]) ON DELETE CASCADE,
	[SignsTheContract] INT REFERENCES [Staff]([Id]) ON DELETE CASCADE,
	[PracticeType] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[StructuralDivision] NVARCHAR(MAX),
	[OrderOfPassingPractice] NVARCHAR(MAX)/*МБ ЗДЕСЬ INT*/
);


CREATE TABLE [CalendarWeekPlan]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[NameOfTheWork] NVARCHAR(MAX),
	[StructuralDivision] NVARCHAR(MAX)
);

CREATE TABLE [CalendarPlan]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CalendarWeekPlanId] INT REFERENCES [CalendarWeekPlan]([Id]) ON DELETE CASCADE,
	[Order] INT
);

CREATE TABLE [CalendarPlan_PracticeDetails]
(
	[CalendarPlanId] INT REFERENCES [CalendarPlan]([Id]) ON DELETE CASCADE,
	[PracticeDetailsId]INT REFERENCES [PracticeDetails]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Student_Group]
(
	[StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE
);

CREATE TABLE [StudentCharacteristics]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[DescriptionByHead] NVARCHAR(MAX),
	[MissedDaysWithReason] INT,
	[MissedDaysWithoutReason] INT,
	[DescriptionByCafedraHead] NVARCHAR(MAX)
);

CREATE TABLE [StudentTask]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StudentId] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[Task] NVARCHAR(MAX)
);

CREATE TABLE [GroupDetails]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GroupId] INT REFERENCES [Group]([Id]) ON DELETE CASCADE,
	[NumberStudentsShouldBe] INT,
	[NumberRegisteredStudents] INT
);

CREATE TABLE [Notification]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(MAX),
	[Date] DATETIME2
);

CREATE TABLE [User_Notification]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[NotificationId] INT REFERENCES [Notification]([Id]) ON DELETE CASCADE,
	[UserFor] INT REFERENCES [User]([Id]) ON DELETE CASCADE,
	[Watched] BIT
);

CREATE TABLE [Log]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(MAX),
	[CustomMessage] NVARCHAR(MAX),
	[Date] DATETIME2,
	[LogType] INT
);

CREATE TYPE [UDT_User] AS TABLE
(
	[Id] INT,
	[FirstName] NVARCHAR(100),
	[SecondName] NVARCHAR(100),
	[LastName] NVARCHAR(100),
	[Email] NVARCHAR(100),
	[Phone] NVARCHAR(100),
	[EmailConfirmed] BIT
);

CREATE TYPE [UDT_User_Role] AS TABLE
(
	[UserId] INT,
	[Role] INT
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
	[InstituteId] INT,
	[CafedraId] INT,
	[DirectionId] INT,
	[CourseId] INT,
	[Name] NVARCHAR(100)
);

CREATE TYPE [UDT_Student_Group] AS TABLE
(
	[StudentId] INT,
	[GroupId] INT
);

CREATE TYPE [UDT_Diary] AS TABLE
(
	[Id] INT,
	[StudentId] INT,
	[Path] NVARCHAR(MAX),
	[Generated] BIT,
	[Send] BIT,
	[Approved] BIT,
	[Perceived] BIT,
	[GeneratedDate] DATETIME2,
	[SendDate] DATETIME2,
	[PerceivedDate] DATETIME2,
	[Completion] INT,
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
	[SignsTheContract] INT,
	[PracticeType] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[StructuralDivision] NVARCHAR(MAX),
	[OrderOfPassingPractice] NVARCHAR(MAX),
	[CalendarPlanId] INT
);

CREATE TYPE [UDT_Integer] AS TABLE
(
	[Id] INT
);

CREATE TYPE [UDT_CalendarWeekPlan] AS TABLE
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[NameOfTheWork] NVARCHAR(MAX),
	[StructuralDivision] NVARCHAR(MAX)
);

CREATE TYPE [UDT_CalendarPlan] AS TABLE
(
	[Id] INT,
	[CalendarWeekPlanId] INT,
	[Order] INT
);

CREATE TYPE [UDT_Notification] AS TABLE
(
	[Id] INT,
	[Message] NVARCHAR(MAX),
	[Date] DATETIME2
);

CREATE TYPE [UDT_StudentCharacteristic] AS TABLE
(
	[Id] INT,
	[StudentId] INT,
	[DescriptionByHead] NVARCHAR(MAX),
	[MissedDaysWithReason] INT,
	[MissedDaysWithoutReason] INT,
	[DescriptionByCafedraHead] NVARCHAR(MAX)
);

CREATE TYPE [UDT_Log] AS TABLE
(
	[Id] INT,
	[Message] NVARCHAR(MAX),
	[CustomMessage] NVARCHAR(MAX),
	[Date] DATETIME2,
	[LogType] INT
);

CREATE TYPE [UDT_User_Notification] AS TABLE
(
	[Id] INT,
	[NotificationId] INT,
	[UserFor] INT,
	[Watched] BIT
);

CREATE TYPE [UDT_GroupDetails] AS TABLE
(
	[Id] INT,
	[GroupId] INT,
	[NumberStudentsShouldBe] INT,
	[NumberRegisteredStudents] INT
);


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
	DECLARE @groupDetails [UDT_GroupDetails];
	DECLARE @studentGroups [UDT_Student_Group];
	DECLARE @students [UDT_User];

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

	INSERT
	INTO @groupDetails (
		[Id],
		[GroupId],
		[NumberStudentsShouldBe],
		[NumberRegisteredStudents]
	)
	SELECT
		[Id],
		[GroupId],
		[NumberStudentsShouldBe],
		[NumberRegisteredStudents]
	FROM [GroupDetails]
	WHERE [GroupId] IN (
		SELECT [Id] FROM @groups
	);

	INSERT
	INTO @studentGroups (
		[StudentId],
		[GroupId]
	)
	SELECT
		[StudentId]
		[GroupId]
	FROM [Student_Group]
	WHERE [GroupId] IN (
		SELECT [Id] FROM @groups
	);

	INSERT
	INTO @students (
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	)
	SELECT
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	FROM [User]
	WHERE [Id] IN (
		SELECT [StudentId] FROM @studentGroups
	);

	SELECT * FROM @groups;
	SELECT * FROM @groupDetails;
	SELECT * FROM @studentGroups;
	SELECT * FROM @students;
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

CREATE PROCEDURE [InstituteDetailsRepository_GetInstitute]
	@instituteId INT
AS
BEGIN
	DECLARE @institute [UDT_Institute];

	INSERT
	INTO @institute (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Institute]
	WHERE [Id] = @instituteId;

	SELECT * FROM @institute;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetCafedra]
	@cafedraId INT
AS
BEGIN
	DECLARE @cafedra [UDT_Cafedra];

	INSERT
	INTO @cafedra (
		[Id],
		[InstituteId],
		[Name]
	)
	SELECT
		[Id],
		[InstituteId],
		[Name]
	FROM [Cafedra]
	WHERE [Id] = @cafedraId;

	SELECT * FROM @cafedra;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetDirection]
	@directionId INT
AS
BEGIN
	DECLARE @direction [UDT_Direction];

	INSERT
	INTO @direction (
		[Id],
		[CafedraId],
		[Name]
	)
	SELECT
		[Id],
		[CafedraId],
		[Name]
	FROM [Direction]
	WHERE [Id] = @directionId;

	SELECT * FROM @direction;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetGroup]
	@groupId INT
AS
BEGIN
	DECLARE @group [UDT_Group];
	DECLARE @groupDetails [UDT_GroupDetails];

	INSERT
	INTO @group (
		[Id],
		[InstituteId],
		[CafedraId],
		[DirectionId],
		[CourseId],
		[Name]
	)
	SELECT
		[Id],
		[InstituteId],
		[CafedraId],
		[DirectionId],
		[CourseId],
		[Name]
	FROM [Group]
	WHERE [Id] = @groupId;

	INSERT
	INTO @groupDetails (
		[Id],
		[GroupId],
		[NumberStudentsShouldBe],
		[NumberRegisteredStudents]
	)
	SELECT
		[Id],
		[GroupId],
		[NumberStudentsShouldBe],
		[NumberRegisteredStudents]
	FROM [GroupDetails]
	WHERE [GroupId] = @groupId;

	SELECT * FROM @group;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetCourse]
	@courseId INT
AS
BEGIN
	DECLARE @course [UDT_Course];

	INSERT
	INTO @course (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Course]
	WHERE [Id] = @courseId;

	SELECT * FROM @course;
END

CREATE PROCEDURE [InstituteDetailsRepository_GetDegree]
	@degreeId INT
AS
BEGIN
	DECLARE @degree [UDT_Degree];

	INSERT
	INTO @degree (
		[Id],
		[Name]
	)
	SELECT
		[Id],
		[Name]
	FROM [Degree]
	WHERE [Id] = @degreeId;

	SELECT * FROM @degree;
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

CREATE PROCEDURE [UserRepository_GetUserById]
	@id INT
AS
BEGIN
	DECLARE @user [UDT_User];

	INSERT
	INTO @user (
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	)
	SELECT
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	FROM [User]
	WHERE [Id] = @id;

	SELECT * FROM @user;
END

CREATE PROCEDURE [UserRepository_AddOrUpdateUser]
	@user [UDT_User] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [User] AS [dest]
	USING @user AS [src]
	ON [dest].[Id] = [src].[Id]
		OR [dest].[Email] = [src].[Email]
		
	WHEN NOT MATCHED THEN
		INSERT (
			[FirstName],
			[SecondName],
			[LastName],
			[Email],
			[Phone],
			[EmailConfirmed]
		) VALUES (
			[src].[FirstName],
			[src].[SecondName],
			[src].[LastName],
			[src].[Email],
			[src].[Phone],	
			[src].[EmailConfirmed]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[FirstName] = [src].[FirstName],
			[dest].[SecondName] = [src].[SecondName],
			[dest].[LastName] = [src].[LastName],
			[dest].[Email] = [src].[Email],
			[dest].[Phone] = [src].[Phone],
			[dest].[EmailConfirmed] = [src].[EmailConfirmed]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @userId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @userId;
END

CREATE PROCEDURE [UserRepository_GetUsers]
AS
BEGIN
	DECLARE @users [UDT_User];

	INSERT
	INTO @users (
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	) 
	SELECT
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	FROM [User];

	SELECT * FROM @users;
END

CREATE PROCEDURE [UserRepository_GetUsersByIds]
	@ids [UDT_Integer] READONLY
AS
BEGIN
	DECLARE @users [UDT_User];

	INSERT
	INTO @users (
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	) 
	SELECT
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone],
		[EmailConfirmed]
	FROM [User]
	WHERE [Id] IN (
		SELECT [Id] FROM @ids
	);

	SELECT * FROM @users;
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
			[StudentId],
			[Generated],
			[Send],
			[Perceived],
			[Approved],
			[SendDate],
			[GeneratedDate],
			[PerceivedDate],
			[Comment]
		) VALUES (
			[src].[Path],
			[src].[StudentId],
			[src].[Generated],
			[src].[Send],
			[src].[Perceived],
			[src].[Approved],
			[src].[SendDate],
			[src].[GeneratedDate],
			[src].[PerceivedDate],
			[src].[Comment]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[Path] = [src].[Path],
			[dest].[StudentId] = [src].[StudentId],
			[dest].[Generated] = [src].[Generated],
			[dest].[Send] = [src].[Send],
			[dest].[Perceived] = [src].[Perceived],
			[dest].[Approved] = [src].[Approved],
			[dest].[SendDate] = [src].[SendDate],
			[dest].[GeneratedDate] = [src].[GeneratedDate],
			[dest].[PerceivedDate] = [src].[PerceivedDate],
			[dest].[Comment] = [src].[Comment]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @diaryId INT = (SELECT TOP 1 [Id] FROM [Diary]);

	SELECT @diaryId;
END

CREATE PROCEDURE [DiariesRepository_GetDiaries]
	@generated BIT = NULL
AS
BEGIN
	DECLARE @diaries [UDT_Diary];

	INSERT
	INTO @diaries (
		[Id],
		[Path],
		[Generated],
		[Send],
		[Perceived],
		[Approved],
		[SendDate],
		[GeneratedDate],
		[PerceivedDate],
		[StudentId],
		[Comment]
	)
	SELECT
		[Id],
		[Path],
		[Generated],
		[Send],
		[Perceived],
		[Approved],
		[SendDate],
		[GeneratedDate],
		[PerceivedDate],
		[StudentId],
		[Comment]
	FROM [Diary]
	WHERE (@generated IS NULL OR [Generated] = @generated);

	SELECT * FROM @diaries;
END

CREATE PROCEDURE [DiariesRepository_GetDiary]
	@studentId INT
AS
BEGIN
	DECLARE @diary [UDT_Diary];

	INSERT
	INTO @diary (
		[Id],
		[Path],
		[Generated],
		[Send],
		[Perceived],
		[Approved],
		[SendDate],
		[GeneratedDate],
		[PerceivedDate],
		[StudentId],
		[Comment]
	)
	SELECT
		[Id],
		[Path],
		[Generated],
		[Send],
		[Perceived],
		[Approved],
		[SendDate],
		[GeneratedDate],
		[PerceivedDate],
		[StudentId],
		[Comment]
	FROM [Diary]
	WHERE [StudentId] = @studentId;

	SELECT * FROM @diary;
END

CREATE PROCEDURE [InstituteDetailsRepository_AttachStudentToGroup]
	@studentGroup [UDT_Student_Group] READONLY
AS
BEGIN
	MERGE
	INTO [Student_Group] AS [dest]
	USING @studentGroup AS [src]
	ON [dest].[StudentId] = [src].[StudentId]
		AND [dest].[GroupId] = [src].[GroupId]
	WHEN NOT MATCHED THEN
		INSERT (
			[StudentId],
			[GroupId]
		) VALUES (
			[src].[StudentId],
			[GroupId]
		)
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

CREATE PROCEDURE [NotificationRepository_GetUserNotifications]
	@userForId INT,
	@watched BIT = NULL
AS
BEGIN
	DECLARE @userNotifications [UDT_User_Notification];

	INSERT
	INTO @userNotifications (
		[Id],
		[NotificationId],
		[UserFor],
		[Watched]
	)
	SELECT
		[Id],
		[NotificationId],
		[UserFor],
		[Watched]
	FROM [User_Notification]
	WHERE [UserFor] = @userForId
		AND (@watched IS NULL OR [Watched] = @watched);


	SELECT * FROM @userNotifications;
END

CREATE PROCEDURE [NotificationRepository_AddOrUpdateNotification]
	@notification [UDT_Notification] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [Notification] AS [dest]
	USING @notification AS [src]
	ON [dest].[Id] = [src].[Id]
	WHEN NOT MATCHED THEN
		INSERT (
			[Message],
			[Date]
		) VALUES (
			[src].[Message],
			[src].[Date]
		)
	WHEN MATCHED THEN 
		UPDATE
		SET
			[dest].[Message] = [src].[Message],
			[dest].[Date] = [src].[Date]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @notificationId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @notificationId;
END


CREATE PROCEDURE [NotificationRepository_AddOrUpdateUserNotification]
	@userNotification [UDT_User_Notification] READONLY
AS
BEGIN
	DECLARE @mergedIds TABLE([Id] INT);

	MERGE
	INTO [User_Notification] AS [dest]
	USING @userNotification AS [src]
	ON [dest].[Id] = [src].[Id]
	WHEN NOT MATCHED THEN
		INSERT (
			[NotificationId],
			[UserFor],
			[Watched]
		) VALUES (
			[src].[NotificationId],
			[src].[UserFor],
			[src].[Watched]
		)
	WHEN MATCHED THEN
		UPDATE
		SET
			[dest].[NotificationId] = [src].[NotificationId],
			[dest].[UserFor] = [src].[UserFor],
			[dest].[Watched] = [src].[Watched]
	OUTPUT INSERTED.ID INTO @mergedIds;

	DECLARE @userNotificationId INT = (SELECT TOP 1 [Id] FROM @mergedIds);

	SELECT @userNotificationId;
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

CREATE PROCEDURE [StudentRepository_GetStudentsByIds]
	@studentIds [UDT_Integer] READONLY
AS
BEGIN
	DECLARE @students [UDT_Student];

	INSERT
	INTO @students (
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone]
	)
	SELECT
		[Id],
		[FirstName],
		[SecondName],
		[LastName],
		[Email],
		[Phone]
	FROM [Student]
	WHERE [Id] IN (
		SELECT [Id] FROM @studentIds
	);

	SELECT * FROM @students;
END