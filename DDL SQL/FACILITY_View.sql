
  
CREATE VIEW vwFacility AS
SELECT        dbo.FACILITY.FacilityID, dbo.FACILITY.Name AS FacilityName, dbo.FACILITY.NumberOfIncidents, dbo.FACILITY.TotalOverflow, dbo.FACILITY.UDL, dbo.FACILITY.OBNumber, dbo.FACILITY.MinimumPoolSize, 
                         dbo.SYSTEM.Name AS SystemName
FROM            dbo.FACILITY INNER JOIN
                         dbo.SYSTEM ON dbo.FACILITY.SystemID = dbo.SYSTEM.SystemID;


CREATE VIEW vwPermit AS
SELECT dbo.PERMIT.PermitID, dbo.PERMIT.StartDate, dbo.PERMIT.EndDate, dbo.PERMIT.AllowedAverageOverflowVolume, dbo.PERMIT.AllowedAverageOverflowPeriod, dbo.PERMIT.AllowedYearlyOverflowVolume, 
                  dbo.PERMIT.AllowedAverageIncidents, dbo.PERMIT.AllowedAverageIncidentsPeriod, dbo.PERMIT.AllowedYearlyIncidents, dbo.PERMIT.AdditionalRestriction, dbo.EQUIPMENTRESTRICTION.Text AS [Equipment Restriction], 
                  dbo.MAINTENANCERESTRICTION.Text AS [Maintenance Restriction], dbo.MEASUREMENTRESTRICTION.Text AS [Measurement Restriction]
FROM     dbo.EQUIPMENTRESTRICTION INNER JOIN
                  dbo.PERMIT ON dbo.EQUIPMENTRESTRICTION.EquipmentRestrictionID = dbo.PERMIT.EquipmentRestrictionID INNER JOIN
                  dbo.FACILITY ON dbo.PERMIT.FacilityID = dbo.FACILITY.FacilityID INNER JOIN
                  dbo.MAINTENANCERESTRICTION ON dbo.PERMIT.MaintenanceRestrictionID = dbo.MAINTENANCERESTRICTION.MaintenanceRestrictionID INNER JOIN
                  dbo.MEASUREMENTRESTRICTION ON dbo.PERMIT.MeasurementRestrictionID = dbo.MEASUREMENTRESTRICTION.MeasurementRestrictionID INNER JOIN
                  dbo.SYSTEM ON dbo.FACILITY.SystemID = dbo.SYSTEM.SystemID