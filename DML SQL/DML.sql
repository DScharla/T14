-- SYSTEMER
EXEC uspAddSystem @NewSystem = 'Model'
EXEC uspAddSystem @NewSystem = 'S2'
EXEC uspAddSystem @NewSystem = 'Blue North'

-- FACILITIES
EXEC uspAddFacility @Name = 'Stadionvej', @TotalOverflow = 3000, @NumberOfIncidents = 4, @UDL = 500, @OBNumber = 104, @SystemName = 'S2'
EXEC uspAddFacility @Name = 'Glejbjerg, Glejbjergvej', @TotalOverflow = 41819, @NumberOfIncidents = 18, @UDL = 215, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 203, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Borgergade', @TotalOverflow = 15630, @NumberOfIncidents = 4, @UDL = 216, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 204, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Grenevej', @TotalOverflow = 44831, @NumberOfIncidents = 66, @UDL = 214, @MinimumPoolSize = '980 m3 i betonbassin + 750 m3 i to jordbassiner', @OBNumber = 205, @SystemName = 'Blue North'

-- PERMITS
EXEC uspAddPermit @StartDate = '2024/01/01', @AllowedAverageYearlyOverflowVolume = 3250, @AllowedYearlyIncidents = 7, @MeasurementRestriction = 'Mangler m�leudstyr, fast installeret (Det er muligvis installeret)', @FacilityName = 'Stadionvej'
EXEC uspAddPermit @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedAverageYearlyOverflowVolume = 7100, @AllowedYearlyIncidents = 45, @EquipmentRestriction = 'Udstyr til registrering af overl�bsm�ngde og antal overl�b, rist og skumbr�t', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Glejbjergvej'
EXEC uspAddPermit @StartDate = '2027/01/01', @AllowedAverageYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 35, @EquipmentRestriction = 'Udstyr til registrering af overl�bsm�ngde og antal overl�b, rist og skumbr�t', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Glejbjergvej'
EXEC uspAddPermit @StartDate = '2024/01/01', @AllowedAverageYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 20, @EquipmentRestriction = 'Udstyr til registrering af overl�bsm�ngde og antal overl�b, rist og skumbr�t', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Borgergade'
EXEC uspAddPermit @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedAverageYearlyOverflowVolume = 13500, @AllowedYearlyIncidents = 60, @EquipmentRestriction = 'Overl�bsbygv�rket skal v�re forsynet med rist og skumbr�t', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Grenevej'
EXEC uspAddPermit @StartDate = '2027/01/01', @AllowedAverageYearlyOverflowVolume = 600, @AllowedYearlyIncidents = 5, @EquipmentRestriction = 'Overl�bsbygv�rket skal v�re forsynet med rist og skumbr�t', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'J�vnlig tilsyn samt regelm�ssig reng�ring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overl�bsm�ngde, samt antal for normal�ret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Grenevej'

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
