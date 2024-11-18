-- SYSTEMER
EXEC uspAddSystem @NewSystem = 'Model'
EXEC uspAddSystem @NewSystem = 'S2'
EXEC uspAddSystem @NewSystem = 'Blue North'

-- FACILITIES
EXEC uspAddFacility @Name = 'Stadionvej', @TotalOverflow = 3000, @NumberOfIncidents = 4, @UDL = 500, @OBNumber = 104, @SystemName = 'S2'
EXEC uspAddFacility @Name = 'Glejbjerg, Glejbjergvej', @TotalOverflow = 41819, @NumberOfIncidents = 18, @UDL = 215, @OBNumber = 203, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Borgergade', @TotalOverflow = 15630, @NumberOfIncidents = 4, @UDL = 216, @OBNumber = 204, @SystemName = 'Blue North'
EXEC uspAddFacility @Name = 'Glejbjerg, Grenevej', @TotalOverflow = 44831, @NumberOfIncidents = 66, @UDL = 214, @OBNumber = 205, @SystemName = 'Blue North'

-- RESTRICTIONS
EXEC uspAddRestriction @StartDate = '2024/01/01', @AllowedAverageYearlyOverflowVolume = 3250, @AllowedYearlyIncidents = 7, @MeasurementRestriction = 'Mangler måleudstyr, fast installeret (Det er muligvis installeret)', @FacilityName = 'Stadionvej'
EXEC uspAddRestriction @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedAverageYearlyOverflowVolume = 7100, @AllowedYearlyIncidents = 45, @EquipmentRestriction = 'Udstyr til registrering af overløbsmængde og antal overløb, rist og skumbræt', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overløbsmængde, samt antal for normalåret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Glejbjergvej'
EXEC uspAddRestriction @StartDate = '2027/01/01', @AllowedAverageYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 35, @EquipmentRestriction = 'Udstyr til registrering af overløbsmængde og antal overløb, rist og skumbræt', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overløbsmængde, samt antal for normalåret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Glejbjergvej'
EXEC uspAddRestriction @StartDate = '2024/01/01', @AllowedAverageYearlyOverflowVolume = 3500, @AllowedYearlyIncidents = 20, @EquipmentRestriction = 'Udstyr til registrering af overløbsmængde og antal overløb, rist og skumbræt', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overløbsmængde, samt antal for normalåret senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Borgergade'
EXEC uspAddRestriction @StartDate = '2024/01/01', @EndDate = '2026/12/31', @AllowedAverageYearlyOverflowVolume = 13500, @AllowedYearlyIncidents = 60, @EquipmentRestriction = 'Overløbsbygværket skal være forsynet med rist og skumbræt', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overløbsmængde, samt antal for normalåret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Grenevej'
EXEC uspAddRestriction @StartDate = '2027/01/01', @AllowedAverageYearlyOverflowVolume = 600, @AllowedYearlyIncidents = 5, @EquipmentRestriction = 'Overløbsbygværket skal være forsynet med rist og skumbræt', @MeasurementRestriction = 'Ja', @MaintenanceRestriction = 'Jævnlig tilsyn samt regelmæssig rengøring og vedligholdelse', @AdditionalRestriction = 'Indselse af ny beregnet overløbsmængde, samt antal for normalåret (900mm) senest den 15 februar 2027', @FacilityName = 'Glejbjerg, Grenevej'

