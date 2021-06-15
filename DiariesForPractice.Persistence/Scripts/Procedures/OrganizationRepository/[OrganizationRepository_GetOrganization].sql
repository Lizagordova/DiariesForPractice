CREATE PROCEDURE [OrganizationRepository_GetOrganization]
	@organizationId INT
AS
BEGIN
	DECLARE @organization [UDT_Organization];

    INSERT
    INTO @organization (
    [Id],
        [Name],
        [LegalAddress]
    )
    SELECT
        [Id],
        [Name],
        [LegalAddress]
    FROM [Organization]
    WHERE [Id] = @organizationId;
    
    SELECT * FROM @organization;
END
