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

EXEC uspAddFacility
	@Name = 'TEst2',
	@NumberOfIncidents = 0,
	@TotalOverflow = 3000,
	@UDL = 500,
	@OBNumber = 104,
	@MinimumPoolSize = '500',
	@SystemName = 'S2'

CREATE PROCEDURE uspAddRestriction
	@StartDate Date,
	@EndDate Date = NULL,
	@AllowedAverageOverflowVolume Int = NULL,
	@AllowedAverageOverflowPeriod Date = NULL,
	@AllowedAverageYearlyOverflowVolume Int = NULL,
	@AllowedAverageIncidents Int = NULL,
	@AllowedAverageIncidentsPeriod Date = NULL,
	@AllowedYearlyIncidents Int = NULL,
	@EquipmentRestriction Int = NULL,
	@MaintenanceRestriction NVarChar(500) = NULL,
	@MeasurementRestriction NVarChar(500) = NULL,
	@AdditionalRestriction NVarChar(500) = NULL,
	@FacilityName NVarChar(500)
AS
BEGIN
	INSERT INTO RESTRICTION
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

EXEC uspAddRestriction 
	@StartDate = '2023/12/31',
	@FacilityName='TEst2',
	@EndDate = '2025-12-31',
	@AllowedAverageOverflowVolume = 7000,
	@AllowedAverageOverflowPeriod = '2015-12-31',
	@AllowedYearlyOverflowVolume = 1000,
	@AllowedAverageIncidents = 5,
	@AllowedAverageIncidentsPeriod = '2020-12-31',
	@AllowedYearlyIncidents = 8,
	@EquipmentRestriction = 'Udstyr',
	@MaintenanceRestriction = 'Vedligeholdelse',
	@MeasurementRestriction = 'Måle',
	@AdditionalRestriction = 'Yderligere'

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

EXEC uspAddOverflow
	@OverflowVolume = 2000,
	@StartTime = '2024/11/15 10:15:00',
	@EndTime = '2024/11/15 10:21:00',
	@FacilityID = 1


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
END
