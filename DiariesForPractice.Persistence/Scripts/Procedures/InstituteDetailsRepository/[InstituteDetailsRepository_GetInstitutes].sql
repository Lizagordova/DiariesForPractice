CREATE PROCEDURE [InstituteDetailsRepository_GetInstitutes]
AS
BEGIN
	DECLARE @institutes [UDT_Institute];

INSERT
INTO @institutes (
[Id],
    [Name]
)
SELECT
    [Id],
    [Name]
FROM [Institute];

SELECT * FROM @institutes;
END