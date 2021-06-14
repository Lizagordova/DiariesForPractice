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