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