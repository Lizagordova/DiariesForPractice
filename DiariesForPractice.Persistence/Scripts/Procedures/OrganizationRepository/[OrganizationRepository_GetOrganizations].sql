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