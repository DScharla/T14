-- SYSTEMER
EXEC uspAddSystem @NewSystem = 'Model'
EXEC uspAddSystem @NewSystem = 'S2'
EXEC uspAddSystem @NewSystem = 'Blue North'

-- FACILITIES
EXEC uspAddFacility @Name = 'Stadionvej', @UDL = 500, @OBNumber = 104, @SystemName = 'S2'
EXEC uspAddFacility @Name = 'Glejbjerg, Glejbjergvej', @UDL = 215, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 203, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Borgergade', @UDL = 216, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 204, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Grenevej', @UDL = 214, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 205, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Kystb�k, Storegade', @UDL = 234, @OBNumber = 216, @MinimumPoolSize = 'Ikke angivet direkte, men der henvises til en samlet kapacitet for sparebassiner p� ca. 8000 m3', @SystemName = 'Blue North';
DECLARE @newFacilityID Int;
EXEC uspAddFacility @Name = 'Test3', @UDL = '1003', @OBNumber = '1004', @MinimumPoolSize = 'Ikke angivet direkte, men der henvises til en samlet kapacitet for sparebassiner p� ca. 8000 m3', @SystemName = 'Blue North', @FacilityID = @newFacilityID OUTPUT;
PRINT @newFacilityID;
-- EQUIPMENTRESTRICTIONS
EXEC uspAddEquipmentRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Rist og skumbr�t'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Udstyr til registrering af overl�bsm�ngde og antal overl�b, rist, og skumbr�t'
EXEC uspAddEquipmentRestriction @NewRestriction = 'Udstyr til registrering af overl�bsm�ngde og antal overl�b'


-- MAINTENANCERESTRICTIONS
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Regelm�ssig inspektion og vedligeholdelse'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligeholdelse'
EXEC uspAddMaintenanceRestriction @NewRestriction = 'Regelm�ssig reng�ring og vedligeholdelse'


-- MEASUREMENTRESTRICTIONS
EXEC uspAddMeasurementRestriction @NewRestriction = 'Ikke angivet'
EXEC uspAddMeasurementRestriction @NewRestriction = 'Ja'
EXEC uspAddMeasurementRestriction @NewRestriction = 'Nej'
EXEC uspAddMeasurementRestriction @NewRestriction = 'M�ske'
SELECT * FROM vwPermit

-- PERMITS
EXEC uspAddPermit @StartDate = '2024/01/01', @AllowedYearlyOverflowVolume = 3250, @AllowedYearlyIncidents = 7, @EquipmentRestrictionID = 1, @MaintenanceRestrictionID = 1, @MeasurementRestrictionID = 4, @FacilityID = 1
EXEC uspAddPermit @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedYearlyOverflowVolume = 7100, @AllowedYearlyIncidents = 45, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027',@FacilityID = 2
EXEC uspAddPermit @StartDate = '2027/01/01', @AllowedYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 35, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityID = 2
EXEC uspAddPermit @StartDate = '2024/01/01', @AllowedYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 20, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret senest den 15 februar 2027', @FacilityID = 3
EXEC uspAddPermit @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedYearlyOverflowVolume = 13500, @AllowedYearlyIncidents = 60, @EquipmentRestrictionID = 2, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityID = 4
EXEC uspAddPermit @StartDate = '2027/01/01', @AllowedYearlyOverflowVolume = 600, @AllowedYearlyIncidents = 5, @EquipmentRestrictionID = 2, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityID = 4
EXEC uspAddPermit @StartDate = '2024/01/01', @EndDate = '2024/12/31', @AllowedYearlyOverflowVolume = 3000, @AllowedYearlyIncidents = 37, @EquipmentRestrictionID = 1, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Den 15. februar 2030 skal Vejen Forsyning indsende ny beregnet overl�bsm�ngde samt antal for normal�ret (900 mm) baseret p� en opdateret afl�bsmodel for oplandet', @FacilityID = 5
EXEC uspAddPermit @StartDate = '2025/01/01', @AllowedYearlyOverflowVolume = 3000, @AllowedYearlyIncidents = 37, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Den 15. februar 2030 skal Vejen Forsyning indsende ny beregnet overl�bsm�ngde samt antal for normal�ret (900 mm) baseret p� en opdateret afl�bsmodel for oplandet', @FacilityID = 5
EXEC uspAddPermit @StartDate = '2025/01/01', @EndDate = null, @AllowedYearlyOverflowVolume = 3000, @AllowedYearlyIncidents = 37, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Den 15. februar 2030 skal Vejen Forsyning indsende ny beregnet overl�bsm�ngde samt antal for normal�ret (900 mm) baseret p� en opdateret afl�bsmodel for oplandet', @FacilityID = 6
EXEC uspAddPermit @StartDate = '2025-01-01', @EndDate = null, @AllowedYearlyOverflowVolume = 3000, @AllowedYearlyIncidents = 37, @EquipmentRestrictionID = 3, @MeasurementRestrictionID = 2, @MaintenanceRestrictionID = 3, @AdditionalRestriction = 'Den 15. februar 2030 skal Vejen Forsyning indsende ny beregnet overl�bsm�ngde samt antal for normal�ret (900 mm) baseret p� en opdateret afl�bsmodel for oplandet', @FacilityID = 10
-- OVERFLOW
-- Stadionvej: Volume og antal incidents passer med facility
EXEC uspAddOverflow @OverflowVolume=1000, @StartTime ='2024/11/18 00:00:00', @EndTime ='2024/11/18 00:30:00', @FacilityID = 1
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/18 01:00:00', @EndTime ='2024/11/18 01:30:00', @FacilityID = 1
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/17 00:00:00', @EndTime ='2024/11/17 00:30:00', @FacilityID = 1
EXEC uspAddOverflow @OverflowVolume=200, @StartTime ='2024/11/17 05:31:00', @EndTime ='2024/11/17 05:40:00', @FacilityID = 1
EXEC uspAddOverflow @OverflowVolume=200, @StartTime ='2024/11/16 05:31:00', @EndTime ='2024/11/16 05:40:00', @FacilityID = 1
EXEC uspAddOverflow @OverflowVolume=200, @StartTime ='2024/11/15 05:31:00', @EndTime ='2024/11/15 05:32:00', @FacilityID = 1
-- Glejbjergvej: Disse kommer "oveni" det der st�r der i forvejen fra uspAddFacility 
EXEC uspAddOverflow @OverflowVolume=1000, @StartTime ='2024/11/18 00:00:00', @EndTime ='2024/11/18 00:30:00', @FacilityID = 2
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/18 01:00:00', @EndTime ='2024/11/18 01:30:00', @FacilityID = 2
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/17 00:00:00', @EndTime ='2024/11/17 00:30:00', @FacilityID = 2
-- Borgergade: Disse kommer "oveni" det der st�r der i forvejen fra uspAddFacility 
EXEC uspAddOverflow @OverflowVolume=1000, @StartTime ='2024/11/18 00:00:00', @EndTime ='2024/11/18 00:30:00', @FacilityID = 3
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/18 01:00:00', @EndTime ='2024/11/18 01:30:00', @FacilityID = 3
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/17 00:00:00', @EndTime ='2024/11/17 00:30:00', @FacilityID = 3
-- Grenevej: Disse kommer "oveni" det der st�r der i forvejen fra uspAddFacility 
EXEC uspAddOverflow @OverflowVolume=1000, @StartTime ='2024/11/18 00:00:00', @EndTime ='2024/11/18 00:30:00', @FacilityID = 4
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/18 01:00:00', @EndTime ='2024/11/18 01:30:00', @FacilityID = 4
EXEC uspAddOverflow @OverflowVolume=800, @StartTime ='2024/11/17 00:00:00', @EndTime ='2024/11/17 00:30:00', @FacilityID = 4