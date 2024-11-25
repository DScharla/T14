CREATE PROCEDURE uspAddSystem 
	@NewSystem NVarChar(50)
AS
BEGIN
	INSERT INTO SYSTEM (Name)
	Values (@NewSystem);
END;

CREATE PROCEDURE uspAddFacility 
	@Name NVarChar(50),
	@NumberOfIncidents Int = NULL,
	@TotalOverflow Int = NULL,
	@UDL Int = NULL,
	@OBNumber Int = NULL,
	@MinimumPoolSize NVarChar(500) = NULL,
	@SystemName NVarChar(500) = NULL
AS
BEGIN
	IF EXISTS(SELECT SystemID FROM SYSTEM WHERE Name=@SystemName)
		BEGIN
			DECLARE @NYVariabel Int;
			SELECT @NYVariabel = SystemID
			From SYSTEM
			WHERE NAME=@SystemName;

			INSERT INTO FACILITY
			VALUES (
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


CREATE PROCEDURE uspAddPermit
	@StartDate Date,
	@EndDate Date = NULL,
	@AllowedAverageOverflowVolume Int = NULL,
	@AllowedAverageOverflowPeriod Date = NULL,
	@AllowedAverageYearlyOverflowVolume Int = NULL,
	@AllowedAverageIncidents Int = NULL,
	@AllowedAverageIncidentsPeriod Date = NULL,
	@AllowedYearlyIncidents Int = NULL,
	@EquipmentRestriction NVarChar(500) = NULL,
	@MaintenanceRestriction NVarChar(500) = NULL,
	@MeasurementRestriction NVarChar(500) = NULL,
	@AdditionalRestriction NVarChar(500) = NULL,
	@FacilityName NVarChar(500)
AS
BEGIN
	INSERT INTO PERMIT
	VALUES (
		@StartDate,
		@EndDate,
		@AllowedAverageOverflowVolume,
		@AllowedAverageOverflowPeriod,
		@AllowedAverageYearlyOverflowVolume,
		@AllowedAverageIncidents,
		@AllowedAverageIncidentsPeriod,
		@AllowedYearlyIncidents,
		@EquipmentRestriction,
		@MaintenanceRestriction,
		@MeasurementRestriction,
		@AdditionalRestriction,
		(SELECT FacilityID FROM FACILITY WHERE Name=@FacilityName)
		);
END


CREATE PROCEDURE uspAddOverflow  
	@OverflowVolume Int,
	@StartTime DateTime,
	@EndTime DateTime,
	@FacilityID Int
	-- IncidentID? 
AS
BEGIN
	INSERT INTO OVERFLOW (
		OverflowVolume,
		StartTime,
		EndTime,
		FacilityID
		)
	VALUES (
		@OverflowVolume,
		@StartTime,
		@EndTime,
		@FacilityID
	);
END


CREATE PROCEDURE uspAddIncident  
	@OverflowVolume Int,
	@StartTime DateTime,
	@EndTime DateTime,
	@FacilityID Int
AS
BEGIN
	INSERT INTO INCIDENT (
		OverflowVolume,
		StartTime,
		EndTime,
		FacilityID
		)
	VALUES (
		@OverflowVolume,
		@StartTime,
		@EndTime,
		@FacilityID
	);

DECLARE @NumberOfIncidents Int;

SELECT @NumberOfIncidents = 
	Count(*)
	FROM INCIDENT
	WHERE FacilityID = @FacilityID

UPDATE FACILITY
SET NumberOfIncidents = @NumberOfIncidents
WHERE FacilityID = @FacilityID
END

