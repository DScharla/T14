USE VF;

CREATE VIEW vwFacility AS
SELECT        dbo.FACILITY.FacilityID, dbo.FACILITY.Name AS FacilityName, dbo.FACILITY.NumberOfIncidents, dbo.FACILITY.TotalOverflow, dbo.FACILITY.UDLNumber, dbo.FACILITY.OBNumber, dbo.FACILITY.MinimumPoolSize, 
                         dbo.SYSTEM.Text AS SystemName
FROM            dbo.FACILITY INNER JOIN
                         dbo.SYSTEM ON dbo.FACILITY.SystemID = dbo.SYSTEM.SystemID;

GO

CREATE VIEW vwPermit AS
SELECT        dbo.EQUIPMENTRESTRICTION.Text AS EquipmentRestriction, dbo.FACILITY.Name AS FacilityName, dbo.FACILITY.FacilityID, dbo.MAINTENANCERESTRICTION.Text AS MaintenanceRestriction, 
                         dbo.MEASUREMENTRESTRICTION.Text AS MeasurementRestriction, dbo.PERMIT.PermitID, dbo.PERMIT.StartDate, dbo.PERMIT.EndDate, dbo.PERMIT.AllowedAverageOverflowVolume, 
                         dbo.PERMIT.AllowedAverageOverflowPeriod, dbo.PERMIT.AllowedYearlyOverflowVolume, dbo.PERMIT.AllowedAverageIncidents, dbo.PERMIT.AllowedAverageIncidentsPeriod, dbo.PERMIT.AllowedYearlyIncidents, 
                         dbo.PERMIT.AdditionalRestriction
FROM            dbo.EQUIPMENTRESTRICTION INNER JOIN
                         dbo.PERMIT ON dbo.EQUIPMENTRESTRICTION.EquipmentRestrictionID = dbo.PERMIT.EquipmentRestrictionID INNER JOIN
                         dbo.FACILITY ON dbo.PERMIT.FacilityID = dbo.FACILITY.FacilityID INNER JOIN
                         dbo.MAINTENANCERESTRICTION ON dbo.PERMIT.MaintenanceRestrictionID = dbo.MAINTENANCERESTRICTION.MaintenanceRestrictionID INNER JOIN
                         dbo.MEASUREMENTRESTRICTION ON dbo.PERMIT.MeasurementRestrictionID = dbo.MEASUREMENTRESTRICTION.MeasurementRestrictionID;
GO
