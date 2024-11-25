DROP TABLE OVERFLOW;
DROP TABLE PERMIT;
DROP TABLE INCIDENT;
DROP TABLE FACILITY;
DROP TABLE SYSTEM;

CREATE TABLE SYSTEM(
	SystemID Int IDENTITY(1,1) CONSTRAINT PK_System PRIMARY KEY,
	Name NVarChar(50) NOT NULL UNIQUE
	);

CREATE TABLE FACILITY(
	FacilityID Int IDENTITY(1,1) CONSTRAINT PK_Facility PRIMARY KEY,
	Name NVarChar(50) NOT NULL UNIQUE,
	NumberOfIncidents Int,
	TotalOverflow Int,
	UDL Int,
	OBNumber Int UNIQUE,
	MinimumPoolSize NVarChar(500),
	SystemID Int,
	CONSTRAINT FK_Facility_System FOREIGN KEY (SystemID) REFERENCES SYSTEM(SystemID)
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
	EquipmentRestriction NVarChar(500),
	MaintenanceRestriction NVarChar(500),
	MeasurementRestriction NVarChar(500),
	AdditionalRestriction NVarChar(500),
	FacilityID Int NOT NULL,
	CONSTRAINT FK_Permit_Facility FOREIGN KEY (FacilityID) REFERENCES FACILITY(FacilityID)
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