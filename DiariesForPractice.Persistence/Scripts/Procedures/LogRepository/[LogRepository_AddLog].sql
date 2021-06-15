CREATE PROCEDURE [LogRepository_AddLog]
	@log [UDT_Log] READONLY
AS
BEGIN
    INSERT
    INTO [Log] (
        [Date],
        [CustomMessage],
        [Message],
        [LogType],
    [LogLevel]
    )
    SELECT
        [Date],
        [CustomMessage],
        [Message],
        [LogType],
        [LogLevel]
    FROM @log
END