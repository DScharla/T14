-- SYSTEMER
EXEC uspAddSystem @NewSystem = 'Ikke angivet'
EXEC uspAddSystem @NewSystem = 'Model'
EXEC uspAddSystem @NewSystem = 'S2'
EXEC uspAddSystem @NewSystem = 'Blue North'

-- EQUIPMENTRESTRICTIONS
EXEC uspAddEquipmentRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Rist og skumbræt'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Udstyr til registrering af overløbsmængde og antal overløb, rist, og skumbræt'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Udstyr til registrering af overløbsmængde og antal overløb'


-- MAINTENANCERESTRICTIONS
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Regelmæssig inspektion og vedligeholdelse'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligeholdelse'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Regelmæssig rengøring og vedligeholdelse'


-- MEASUREMENTRESTRICTIONS
EXEC uspAddMeasurementRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddMeasurementRestriction @NewRestriction = 'Ja'
EXEC uspAddMeasurementRestriction @NewRestriction = 'Nej'
EXEC uspAddMeasurementRestriction @NewRestriction = 'Måske'
SELECT * FROM vwPermit


-- Tilføj nogle bygværker med foruddefinerede Total overflow og Number of Incidents
--Bygværk 1 - COLOR1 - Green
INSERT INTO FACILITY 
VALUES ('Color1', 10, 2000, 800, 800, 5000, 2);

GO

INSERT INTO PERMIT(StartDate, EndDate, AllowedYearlyOverflowVolume, AllowedYearlyIncidents, EquipmentRestrictionID, MaintenanceRestrictionID, MeasurementRestrictionID, FacilityID)
VALUES ('2024/01/01', '2024/12/31', 5000, 15, 2, 1, 3, 1);

GO
--Bygværk  - COLOR2 - RED
INSERT INTO FACILITY 
VALUES ('Color2', 50, 5000, 801, 801, 3000, 3);

GO

INSERT INTO PERMIT(StartDate, EndDate, AllowedYearlyOverflowVolume, AllowedYearlyIncidents, EquipmentRestrictionID, MaintenanceRestrictionID, MeasurementRestrictionID, FacilityID)
VALUES ('2023/01/01', '2024/12/31', 4000, 15, 1, 3, 3, 2);

GO
SELECT * FROM vwPermit;
SELECT * FROM vwFacility;