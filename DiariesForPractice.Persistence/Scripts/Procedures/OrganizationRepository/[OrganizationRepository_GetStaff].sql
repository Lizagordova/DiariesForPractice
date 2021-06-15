CREATE PROCEDURE [OrganizationRepository_GetStaff]
	@staffId INT
AS
BEGIN
	DECLARE @staff [UDT_Staff];

    INSERT
    INTO @staff (
    [Id],
        [OrganizationId],
        [FullName],
        [Job],
        [Email],
        [Phone]
    )
    SELECT
        [Id],
        [OrganizationId],
        [FullName],
        [Job],
        [Email],
        [Phone]
    FROM [Staff]
    WHERE [Id] = @staffId;
    
    SELECT * FROM @staff;
END