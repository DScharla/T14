CREATE PROCEDURE uspAddSystem 
	@NewSystem NVarChar(50)
AS
BEGIN
	INSERT INTO SYSTEM (Name)
	Values (@NewSystem);
END;

EXEC uspAddSystem
	@NewSystem = 'Model';
EXEC uspAddSystem
	@NewSystem = 'S2';

ALTER PROCEDURE uspAddFacility 
	@Name NVarChar(50),
	@NumberOfIncidents Int,
	@TotalOverflow Int,
	@UDL Int,
	@OBNumber Int,
	@MinimumPoolSize NVarChar(500),
	@SystemName NVarChar(500)
AS
BEGIN
	IF EXISTS(SELECT SystemID FROM SYSTEM WHERE Name=@SystemName)
		BEGIN
			DECLARE @NYVariabel Int;
			Select @NYVariabel = SystemID
			From SYSTEM
			Where Name=@SystemName;

			INSERT INTO FACILITY
			Values (
				@Name,
				@NumberOfIncidents,
				@TotalOverflow,
				@UDL,
				@OBNumber,
				@MinimumPoolSize,
				@NYVariabel
				);
		END;
END;

EXEC uspAddFacility
	@Name = 'TEst2',
	@NumberOfIncidents = 0,
	@TotalOverflow = 3000,
	@UDL = 500,
	@OBNumber = 104,
	@MinimumPoolSize = '500',
	@SystemName = 'S2'
