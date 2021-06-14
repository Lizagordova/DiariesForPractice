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