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