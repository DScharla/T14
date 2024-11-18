SELECT TOP (1000) [OverflowID]
      ,[OverflowVolume]
      ,[StartTime]
      ,[EndTime]
      ,[FacilityID]
      ,[IncidentID]
  FROM [VF].[dbo].[OVERFLOW]
  
CREATE VIEW vwFacility AS
SELECT        dbo.FACILITY.FacilityID, dbo.FACILITY.Name AS FacilityName, dbo.FACILITY.NumberOfIncidents, dbo.FACILITY.TotalOverflow, dbo.FACILITY.UDL, dbo.FACILITY.OBNumber, dbo.FACILITY.MinimumPoolSize, 
                         dbo.SYSTEM.Name AS SystemName
FROM            dbo.FACILITY INNER JOIN
                         dbo.SYSTEM ON dbo.FACILITY.SystemID = dbo.SYSTEM.SystemID