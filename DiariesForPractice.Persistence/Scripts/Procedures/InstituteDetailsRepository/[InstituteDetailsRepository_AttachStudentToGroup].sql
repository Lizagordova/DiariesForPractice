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
    );
END