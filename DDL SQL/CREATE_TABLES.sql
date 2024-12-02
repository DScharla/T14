USE VF;
DROP TABLE OVERFLOW;
DROP TABLE PERMIT;
DROP TABLE EQUIPMENTRESTRICTION;
DROP TABLE MAINTENANCERESTRICTION;
DROP TABLE MEASUREMENTRESTRICTION;
DROP TABLE INCIDENT;
DROP TABLE FACILITY;
DROP TABLE SYSTEM;


CREATE TABLE SYSTEM(
	SystemID Int IDENTITY(1,1) CONSTRAINT PK_System PRIMARY KEY,
	Text NVarChar(50) NOT NULL UNIQUE
	);

CREATE TABLE FACILITY(
	FacilityID Int IDENTITY(1,1) CONSTRAINT PK_Facility PRIMARY KEY,
	Name NVarChar(50) NOT NULL UNIQUE,
	NumberOfIncidents Int,
	TotalOverflow Int,
	UDLNumber NVarChar(20) NOT NULL,
	OBNumber NVarChar(20) UNIQUE NOT NULL,
	MinimumPoolSize NVarChar(500),
	SystemID Int,
	CONSTRAINT FK_Facility_System FOREIGN KEY (SystemID) REFERENCES SYSTEM(SystemID)
	);

CREATE TABLE EQUIPMENTRESTRICTION(
	EquipmentRestrictionID Int IDENTITY(1,1) CONSTRAINT PK_EquipmentRestriction PRIMARY KEY,
	Text NVarChar(500)
	);

CREATE TABLE MAINTENANCERESTRICTION(
	MaintenanceRestrictionID Int IDENTITY(1,1) CONSTRAINT PK_MaintenanceRestriction PRIMARY KEY,
	Text NVarChar(500)
	);

CREATE TABLE MEASUREMENTRESTRICTION(
	MeasurementRestrictionID Int IDENTITY(1,1) CONSTRAINT PK_MeasurementRestriction PRIMARY KEY,
	Text NVarChar(500)
	);


CREATE TABLE PERMIT(
	PermitID INT IDENTITY(1,1) CONSTRAINT PK_Permit PRIMARY KEY,
	StartDate Date NOT NULL,
	EndDate Date,
	AllowedAverageOverflowVolume Int,
	AllowedAverageOverflowPeriod Date,
	AllowedYearlyOverflowVolume Int,
	AllowedAverageIncidents Int,
	AllowedAverageIncidentsPeriod Date,
	AllowedYearlyIncidents Int,
	AdditionalRestriction NVarChar(500),
	EquipmentRestrictionID Int NOT NULL, 
	MaintenanceRestrictionID Int NOT NULL,
	MeasurementRestrictionID Int NOT NULL,
	FacilityID Int NOT NULL,
	CONSTRAINT FK1_Permit_Facility FOREIGN KEY (FacilityID) REFERENCES FACILITY(FacilityID),
	CONSTRAINT FK2_Permit_EquipmentRestriction FOREIGN KEY (EquipmentRestrictionID) REFERENCES EQUIPMENTRESTRICTION(EquipmentRestrictionID),
	CONSTRAINT FK3_Permit_MaintenanceRestriction FOREIGN KEY (MaintenanceRestrictionID) REFERENCES MAINTENANCERESTRICTION(MaintenanceRestrictionID),
	CONSTRAINT FK4_Permit_MeasurementRestriction FOREIGN KEY (MeasurementRestrictionID) REFERENCES MEASUREMENTRESTRICTION(MeasurementRestrictionID)
	);

CREATE TABLE INCIDENT(
	IncidentId Int IDENTITY(1,1) CONSTRAINT PK_Incident PRIMARY KEY,
	OverflowVolume Int NOT NULL,
	StartTime DateTime NOT NULL,
	EndTime DateTime NOT NULL,
	FacilityID Int NOT NULL,
	CONSTRAINT FK_Incident_Facility FOREIGN KEY (FacilityID) References FACILITY(FacilityID)
	);

CREATE TABLE OVERFLOW(
	OverflowID Int IDENTITY(1,1) CONSTRAINT PK_Overflow PRIMARY KEY,
	OverflowVolume Int NOT NULL,
	StartTime DateTime NOT NULL,
	EndTime DateTime NOT NULL,
	FacilityID Int NOT NULL,
	IncidentID Int,
	CONSTRAINT FK1_Overflow_Facility FOREIGN KEY (FacilityID) REFERENCES FACILITY(FacilityID),
	CONSTRAINT FK2_Overflow_Incident FOREIGN KEY (IncidentID) REFERENCES INCIDENT(IncidentID)
	);