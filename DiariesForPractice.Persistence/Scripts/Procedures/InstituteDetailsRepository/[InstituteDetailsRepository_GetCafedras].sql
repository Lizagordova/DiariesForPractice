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