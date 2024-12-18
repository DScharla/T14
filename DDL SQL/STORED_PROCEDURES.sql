DROP PROCEDURE uspAddEquipmentRestriction;
DROP PROCEDURE uspAddMaintenanceRestriction;
DROP PROCEDURE uspAddMeasurementRestriction;
DROP PROCEDURE uspAddFacility;
DROP PROCEDURE uspAddIncident;
DROP PROCEDURE uspAddOverflow;
DROP PROCEDURE uspAddPermit;
DROP PROCEDURE uspAddSystem;
DROP PROCEDURE uspUpdateFacility;
DROP PROCEDURE uspRemoveFacility;
DROP PROCEDURE uspRemovePermit;
DROP PROCEDURE uspUpdateIncident;
DROP PROCEDURE uspUpdateOverflowWithIncidentID;


GO

CREATE PROCEDURE uspAddSystem 
	@NewSystem NVarChar(50)
AS
BEGIN
	INSERT INTO SYSTEM (Text)
	Values (@NewSystem);
END;
GO

CREATE PROCEDURE uspAddFacility 
	@Name NVarChar(50),
	@UDLNumber NVarChar(20),
	@OBNumber NVarChar(20),
	@MinimumPoolSize NVarChar(500) = NULL,
	@SystemID Int = NULL,
	@FacilityID Int OUTPUT
AS
BEGIN
	BEGIN
		INSERT INTO FACILITY (
			Name,
			UDLNumber,
			OBNumber,
			MinimumPoolSize,
			SystemID)
		VALUES (
			@Name,
			@UDLNumber,
			@OBNumber,
			@MinimumPoolSize,
			@SystemID
			);
		Set @FacilityID = SCOPE_IDENTITY();
	END;
END;

GO



CREATE PROCEDURE uspAddPermit
	@StartDate Date,
	@EndDate Date = NULL,
	@AllowedYearlyOverflowVolume Int = NULL,
	@AllowedYearlyIncidents Int = NULL,
	@AdditionalRestriction NVarChar(500) = NULL,
	@EquipmentRestrictionID Int,
	@MaintenanceRestrictionID Int,
	@MeasurementRestrictionID Int,
	@FacilityID Int,
	@PermitID Int OUTPUT
AS
BEGIN
	INSERT INTO PERMIT
	VALUES (
		@StartDate,
		@EndDate,
		@AllowedYearlyOverflowVolume,
		@AllowedYearlyIncidents,
		@AdditionalRestriction,
		@EquipmentRestrictionID,
		@MaintenanceRestrictionID,
		@MeasurementRestrictionID,		
		@FacilityID);
		Set @PermitID = SCOPE_IDENTITY();
END

GO

CREATE PROCEDURE uspAddEquipmentRestriction
@NewRestriction NVarChar(500)
AS
BEGIN
	INSERT INTO EQUIPMENTRESTRICTION(Text)
	Values (@NewRestriction);
END;

GO

CREATE PROCEDURE uspAddMaintenanceRestriction
@NewRestriction NVarChar(500)
AS
BEGIN
	INSERT INTO MAINTENANCERESTRICTION(Text)
	Values (@NewRestriction);
END;

GO

CREATE PROCEDURE uspAddMeasurementRestriction
@NewRestriction NVarChar(500)
AS
BEGIN
	INSERT INTO MEASUREMENTRESTRICTION(Text)
	Values (@NewRestriction);
END;

GO

CREATE PROCEDURE uspAddOverflow  
	@OverflowVolume Decimal(15, 7),
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


GO


CREATE PROCEDURE uspAddIncident  
	@OverflowVolume Decimal(15, 7),
	@StartTime DateTime,
	@EndTime DateTime,
	@FacilityID Int,
	@IncidentID Int OUTPUT
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
	Set @IncidentID = SCOPE_IDENTITY();

DECLARE @NumberOfIncidents Int;

SELECT @NumberOfIncidents = 
	Count(*)
	FROM INCIDENT
	WHERE FacilityID = @FacilityID

UPDATE FACILITY
SET NumberOfIncidents = @NumberOfIncidents
WHERE FacilityID = @FacilityID
END

GO

CREATE PROCEDURE uspUpdateFacility
	@FacilityID Int,
	@Name NVarChar(50),
	@UDLNumber NVarChar(20),
	@OBNumber NVarChar(20),
	@MinimumPoolSize NVarChar(500) = NULL,
	@NumberOfIncidents Int = NULL,
	@TotalOverflow Int = NULL,
	@SystemID Int
AS
BEGIN
	UPDATE FACILITY
	SET 
		Name = @Name,
		NumberOfIncidents =@NumberOfIncidents,
		TotalOverflow = @TotalOverflow,
		UDLNumber = @UDLNumber,
		OBNumber = @OBNumber,
		MinimumPoolSize = @MinimumPoolSize,
		SystemID = @SystemID
WHERE FacilityID=@FacilityID
END

GO


CREATE PROCEDURE uspRemoveFacility
	@FacilityID Int
AS
BEGIN
	DELETE FROM OVERFLOW WHERE [OVERFLOW].FacilityID=@FacilityID;
	DELETE FROM INCIDENT WHERE [INCIDENT].FacilityID=@FacilityID;
	DELETE FROM PERMIT WHERE [PERMIT].FacilityID=@FacilityID;
	DELETE FROM FACILITY WHERE FacilityID=@FacilityID;
	
END

GO

CREATE PROCEDURE uspRemovePermit
	@PermitID Int
AS
BEGIN
	DELETE FROM PERMIT WHERE PermitID=@PermitID;
END
GO

CREATE PROCEDURE uspUpdateIncident
	@OverflowVolume Decimal(15, 7),
	@EndTime DateTime,
	@FacilityID Int,
	@IncidentID Int
AS
BEGIN
	UPDATE INCIDENT
	SET
		OverflowVolume = @OverflowVolume,
		EndTime = @EndTime
WHERE IncidentId=@IncidentID
END
GO

CREATE PROCEDURE uspUpdateOverflowWithIncidentID
	@OverflowID Int,
	@IncidentID Int
AS
BEGIN
	UPDATE OVERFLOW
	SET
		IncidentID = @IncidentID
WHERE OverflowID = @OverflowID
END
GO

