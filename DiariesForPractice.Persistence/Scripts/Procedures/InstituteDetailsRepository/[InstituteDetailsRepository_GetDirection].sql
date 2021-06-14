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