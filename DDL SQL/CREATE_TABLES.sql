CREATE TABLE SYSTEM(
	SystemID INT IDENTITY(1,1) CONSTRAINT PK_System PRIMARY KEY,
	Name NVarChar(50) NOT NULL UNIQUE
	);

CREATE TABLE FACILITY(
	FacilityID INT IDENTITY(1,1) CONSTRAINT PK_Facility PRIMARY KEY,
	Name NVarChar(50) NOT NULL UNIQUE,
	NumberOfIncidents INT,
	TotalOverflow INT,
	UDL NVarChar(10),
	OBNumber INT UNIQUE,
	MinimumPoolSize NVarChar(500),
	SystemID Int,
	CONSTRAINT FK_Facility_System FOREIGN KEY (SystemID) REFERENCES SYSTEM(SystemID)
	);

CREATE TABLE RESTRICTION(
	RestrictionID INT IDENTITY(1,1) CONSTRAINT PK_Restriction PRIMARY KEY,
	StartDate Date NOT NULL,
	EndDate Date,
	AllowedAverageOverflowVolume Int,
	AllowedAverageOverflowPeriod Date,
	AllowedYearlyOverflowVolume Int,
	AllowedAverageIncidents Int,
	AllowedAverageIncidentsPeriod Int,
	AllowedYearlyIncidents Int,
	EquipmentRestriction NVarChar(500),
	MaintenanceRestriction NVarChar(500),
	MeasurementRestriction NVarChar(500),
	AdditionalRestriction NVarChar(500),
	FacilityID Int NOT NULL,
	CONSTRAINT FK_Restriction_Facility FOREIGN KEY (FacilityID) REFERENCES FACILITY(FacilityID)
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
	OverflowID INT IDENTITY(1,1) CONSTRAINT PK_Overflow PRIMARY KEY,
	OverflowVolume Int NOT NULL,
	StartTime DateTime NOT NULL,
	EndTime DateTime NOT NULL,
	FacilityID Int NOT NULL,
	IncidentID Int,
	CONSTRAINT FK1_Overflow_Facility FOREIGN KEY (FacilityID) REFERENCES FACILITY(FacilityID),
	CONSTRAINT FK2_Overflow_Incident FOREIGN KEY (IncidentID) REFERENCES INCIDENT(IncidentID)
	);